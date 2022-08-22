using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancy.Application;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Exceptions;
using MultiTenancy.Application.Logging;
using MultiTenancy.Application.Search;
using MultiTenancy.Application.UseCases;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases
{
    public class UseCaseMediator
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _provider;
        private readonly IApplicationActor _user;
        private readonly IUseCaseLogger _logger;
        public UseCaseMediator(ShopDbContext context, IMapper mapper, IServiceProvider provider, IApplicationActor user, IUseCaseLogger logger)
        {
            _context = context;
            _mapper = mapper;
            _provider = provider;
            _user = user;
            _logger = logger;
        }

        public object Search<TUseCase, TSearch, TData, TEntity>(TUseCase useCase)
            where TUseCase : UseCase<TSearch>
            where TSearch : ISearchObject
            where TData : BaseDto
            where TEntity : class
        {
            ValidateAndLog<TUseCase, TSearch>(useCase);

            return _context.Set<TEntity>().Select(x => _mapper.Map<TData>(x)).ToList();
        }

        public TData Find<TUseCase, TData, TEntity>(TUseCase useCase)
            where TUseCase : UseCase<int>
            where TEntity : class
        {
            ValidateAndLog<TUseCase, int>(useCase);

            var dataFromDb = _context.Set<TEntity>().Find(useCase.Data);

            if (dataFromDb == null)
            {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<TData>(dataFromDb);
        }

        public void Insert<TUseCase, TData, TEntity>(TUseCase useCase)
            where TUseCase : UseCase<TData>
            where TEntity : class
        {
            ValidateAndLog<TUseCase, TData>(useCase);

            var mappedData = _mapper.Map<TData, TEntity>(useCase.Data);

            _context.Set<TEntity>().Add(mappedData);

            _context.SaveChanges();
        }

        public void Update<TUseCase, TData, TEntity>(TUseCase useCase)
            where TUseCase : UseCase<TData>
            where TData : BaseDto
            where TEntity : class
        {
            ValidateAndLog<TUseCase, TData>(useCase);

            var dataFromDb = _context.Set<TEntity>().Find(useCase.Data.Id);

            if (dataFromDb == null)
            {
                throw new EntityNotFoundException();
            }

            _mapper.Map(useCase.Data, dataFromDb);

            _context.SaveChanges();
        }

        public void Delete<TUseCase, TEntity>(TUseCase useCase)
            where TUseCase : UseCase<int>
            where TEntity : class
        {
            ValidateAndLog<TUseCase, int>(useCase);

            var dataFromDb = _context.Set<TEntity>().Find(useCase.Data);

            if (dataFromDb == null)
            {
                throw new EntityNotFoundException();
            }

            _context.Set<TEntity>().Remove(dataFromDb);

            _context.SaveChanges();
        }

        public object Execute<TUseCase, TData, TOut>(TUseCase useCase)
            where TUseCase : UseCase<TData>
        {
            ValidateAndLog<TUseCase, TData>(useCase);

            var handler = _provider.GetService<IUseCaseHandler<TUseCase, TOut>>();

            if(handler == null)
            {
                throw new HandlerNotFoundException();
            }

            return handler.Handle(useCase);
        }

        private void ValidateAndLog<TUseCase, TData>(TUseCase useCase) where TUseCase : UseCase<TData>
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            var log = new UseCaseLog
            {
                UserId = _user.UserId,
                UseCaseId = useCase.Id,
                IsAuthorized = isAuthorized,
                ExecutionDateTime = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(useCase.Data)
            };

            _logger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseException(useCase.Id, _user.UserId.ToString());
            }

            var validator = _provider.GetService<AbstractValidator<TUseCase>>();

            if (validator != null)
            {
                validator.ValidateAndThrow(useCase);
            }
        }
    }
}
