namespace MultiTenancy.Api.Core.Exceptions
{
    public class TenantIdNotProvidedException : Exception
    {
        public TenantIdNotProvidedException() : base("Tenant Id is not provided.")
        {

        }
    }
}
