using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Logging
{
    public class UseCaseLog
    {
        public int UserId { get; set; }
        public string UseCaseId { get; set; }
        public bool IsAuthorized { get; set; }
        public DateTime ExecutionDateTime { get; set; }
        public string Data { get; set; }
    }
}
