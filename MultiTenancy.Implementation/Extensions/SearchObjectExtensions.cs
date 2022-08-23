using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancy.Application.Exceptions;
using MultiTenancy.Application.Search;
using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Extensions
{
    public static class SearchObjectExtensions
    {
        private static IMapper Mapper => ServiceProviderActivator.Provider.GetService<IMapper>();

        public static object BuildDynamicQuery<T, TData>(this ISearchObject search, IQueryable<T> query)
        {
            query = search.BuildQuery(query);
            query = search.BuildOrderBy(query);

            if (search.Paginate)
            {
                return new PagedResponse<TData>
                {
                    Page = search.Page,
                    PerPage = search.PerPage,
                    TotalCount = query.Count(),
                    Items = Mapper.Map<IEnumerable<TData>>(query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).ToList())
                };
            }

            return Mapper.Map<IEnumerable<TData>>(query.ToList());
        }

        public static IQueryable<T> BuildQuery<T>(this ISearchObject search, IQueryable<T> query)
        {
            var searchObjProperties = search.GetType().GetProperties();

            foreach (var p in searchObjProperties)
            {
                var value = p.GetValue(search);

                if(value == null) continue;

                var attributes = p.GetCustomAttributes(true).Where(x => x is BaseSearchAttribute);

                foreach (var attr in attributes)
                {
                    if (attr is QueryPropertyAttribute qp)
                    {
                        var comparisonType = qp.ComparisonType;
                        var properties = qp.Properties;

                        List<string> expressions = new List<string>();

                        foreach (var prop in properties)
                        {
                            if(attr is WithAnyPropertyAttribute)
                            {
                                expressions.Add(GetComparisonStringAnyProperty(prop, value, comparisonType));
                                continue;
                            }

                            expressions.Add(GetComparisonString(prop, value, comparisonType));
                        }

                        string separator = attr is IAndAttribute ? " && " : " || ";

                        query = attr is WithAnyPropertyAttribute ? 
                            query.Where("y => " + string.Join(separator, expressions)) : 
                            query.Where("x => " + string.Join(separator, expressions));
                    }
                }
            }

            return query;
        }

        public static IEnumerable<TData> BuildQuery<T, TData>(this ISearchObject search, IQueryable<T> query)
        {
            query = search.BuildQuery(query);

            return Mapper.Map<IEnumerable<TData>>(query.ToList());
        }

        public static IQueryable<T> BuildOrderBy<T>(this ISearchObject search, IQueryable<T> query)
        {
            var sortByString = search.SortBy;

            if (!string.IsNullOrEmpty(sortByString))
            {
                var sortByArgs = sortByString.Split(',');
                string orderByClause = "";

                foreach(var arg in sortByArgs)
                {
                    var propAndDirection = arg.Split('.');

                    if(propAndDirection.Count() != 2)
                    {
                        throw new InvalidSortFormatException();
                    }

                    if (!SortDirections.Contains(propAndDirection[1]))
                    {
                        throw new InvalidSortDirectionException();
                    }

                    if (search.CustomSortBy.ContainsKey(propAndDirection[0]))
                    {
                        var customSortBy = search.CustomSortBy[propAndDirection[0]];

                        orderByClause += $"{customSortBy} {propAndDirection[1]},";
                        continue;
                    }

                    if(!typeof(T).GetProperties().Any(x => x.Name.ToLower() == propAndDirection[0].ToLower()))
                    {
                        throw new PropertyNotFoundException(propAndDirection[0]);
                    }

                    orderByClause += $"{propAndDirection[0]} {propAndDirection[1]},";
                }

                orderByClause = orderByClause.TrimEnd(',');

                query = query.OrderBy(orderByClause);
            }

            return query;
        }

        public static IEnumerable<TData> BuildOrderBy<T, TData>(this ISearchObject search, IQueryable<T> query)
        {
            query = search.BuildOrderBy(query);

            return Mapper.Map<IEnumerable<TData>>(query.ToList());
        }

        private static IEnumerable<string> SortDirections = new List<string> { "asc", "desc" };

        private static string GetComparisonString(string property, object value, ComparisonType comparisonType)
        {
            switch(comparisonType)
            {
                case ComparisonType.Equals:
                    return $"x.{property} == {FormatValue(value)}";
                    break;
                case ComparisonType.Contains:
                    return $"x.{property}.Contains({FormatValue(value)})";
                    break;
                case ComparisonType.LessThan:
                    return $"x.{property} < {FormatValue(value)}";
                    break;
                case ComparisonType.LessThanOrEqual:
                    return $"x.{property} <= {FormatValue(value)}";
                    break;
                case ComparisonType.GreaterThan:
                    return $"x.{property} > {FormatValue(value)}";
                    break;
                case ComparisonType.GreaterThanOrEqual:
                    return $"x.{property} >= {FormatValue(value)}";
                    break;
                default:
                    return $"x.{property} == {FormatValue(value)}";
            }
        }

        private static string GetComparisonStringAnyProperty(string property, object value, ComparisonType comparisonType)
        {
            string originalProp = property.Substring(0, property.IndexOf('.'));
            string nestedProps = property.Substring(property.IndexOf('.') + 1);

            return $"y.{originalProp}.Any({GetComparisonString(nestedProps, value, comparisonType)})";
        }

        private static object FormatValue(object value)
        {
            if (value is string) return $"\"{value}\"";

            return value;
        }
    }
}
