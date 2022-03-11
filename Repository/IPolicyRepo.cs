using PolicyMicroservice.Models;

namespace PolicyMicroservice.Repository
{
    public interface IPolicyRepo
    {
        public Task<string> CreatePolicy(int PropertyId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);

        public dynamic ViewPolicyById(int PolicyId);

        //  public Task<Quotes> GetQuote(int BusinessValue, int PropertyValue);

        public  int GetQuote(int BusinessValue, int PropertyValue);
        public dynamic GetProperties();

        public dynamic GetPolicies();

    }
}
