using PolicyMicroservice.Models;

namespace PolicyMicroservice.Service
{
    public interface IPolicyService
    {
        public Task<string> CreatePolicy(int PropertyId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);

        public dynamic ViewPolicyById(int PolicyId);

        public int GetQuote(int BusinessValue, int PropertyValue);

        public dynamic GetProperties();

        public dynamic GetPolicies();
    }
}
