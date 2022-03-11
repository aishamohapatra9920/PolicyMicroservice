using Microsoft.EntityFrameworkCore;
using PolicyMicroservice.Models;

namespace PolicyMicroservice.Repository
{
    public class PolicyRepo : IPolicyRepo
    {
        private readonly InsureityPortalDatabaseContext context;

        public PolicyRepo(InsureityPortalDatabaseContext policyDBContext)
        {
            context = policyDBContext;
        }

        public virtual async Task<string> CreatePolicy(int PropertyId)
        {
            string PolicyStatus;
            try
            { 
                var property = context.Properties
                    //.Include(b => b.PropertyId)
                    .Include(b => b.Business)
                    .Include(b => b.Business.BusinessMaster)
                    .Include(b => b.PropertyMaster)
                    .SingleOrDefault(b => b.PropertyId == PropertyId);
                if (property == null)
                {
                    PolicyStatus = "No such Property exists. Hence, Policy was not created.";
                    return PolicyStatus;
                }

                int quote = GetQuote(property.Business.BusinessMaster.BusinessValue, property.PropertyMaster.PropertyValue);
                if (quote == null)
                {
                    PolicyStatus = "No such Quote exists. Hence, Policy was not created.";
                    return PolicyStatus;
                }

                PolicyMaster pm = context.PolicyMasters
                    .Where(pm => pm.BusinesssValue == property.Business.BusinessMaster.BusinessValue)
                    .SingleOrDefault();
                if (pm == null)
                {
                    PolicyStatus = "No such PolicyMaster exists. Hence, Policy was not created.";
                    return PolicyStatus;
                }

                PolicyStatus = "Initiated";

                ConsumerPolicy policy = new ConsumerPolicy
                {
                    
                    PropertyId = PropertyId,
                    PolicyStatus = PolicyStatus,
                    QuoteId = quote,
                    PolicyMasterId = pm.PolicyMasterId
                };

                context.ConsumerPolicies.Add(policy);
                await context.SaveChangesAsync();
                return "Policy has been created with Policy Status \'" + PolicyStatus + "\'.";
            }
            catch
            {
                PolicyStatus = "Policy was not created.";
                return PolicyStatus;
            }
        }

        public virtual async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            try
            {
                if (PaymentDetails == "Paid")
                {
                    ConsumerPolicy policy = context.ConsumerPolicies.SingleOrDefault(p => p.PolicyId == PolicyId);
                    if (policy == null)
                    {
                        return "No Policy exists with ID " + PolicyId + ".";
                    }
                    if (policy.PolicyStatus == "Issued")
                    {
                        return "Policy has already been Issued.";
                    }
                    policy.PolicyStatus = "Issued";
                    await context.SaveChangesAsync();
                    return "Policy has been " + policy.PolicyStatus + " for Policy ID " + policy.PolicyId + ".";
                }
                return "No Payment was made. Hence, Policy was not Issued.";
            }
            catch
            {
                return "Policy was not Issued.";
            }
        }

        public   int GetQuote(int BusinessValue,int PropertyValue)
        {
             List<Quotes> quotes = context.Quotes.ToList();
              if (BusinessValue >= 0 && BusinessValue <= 10 && PropertyValue >= 0 && PropertyValue <= 10)
              {
                  foreach (Quotes q in quotes)
                  {
                      if (BusinessValue >= q.BusinesssValueFrom && BusinessValue <= q.BusinesssValueTo &&
                          PropertyValue >= q.PropertyValueFrom && PropertyValue <= q.PropertyValueTo)
                      {
                        // return await context.Quotes.FindAsync(q.QuoteId);
                        return q.QuoteId;
                      }
                  }
              }
            return 0;  
           
        }


        public virtual dynamic ViewPolicyById(int PolicyId)
        {
            try
            {
                var policy = context.ConsumerPolicies
                    .Include(c => c.Property).Include(c => c.PolicyMaster).Include(c => c.Quote)
                    .Where(cp => cp.PolicyId == PolicyId)
                    .Select(cp => new
                    {
                        PolicyId = cp.PolicyId,
                        BuildingType = cp.Property.BuildingType,
                        PolicyStatus = cp.PolicyStatus,
                        PropertyId = cp.PropertyId,
                        PropertyType = cp.PolicyMaster.PropertyType,
                        PropertyValue = cp.Property.PropertyMaster.PropertyValue,
                        BusinessValue = cp.Property.Business.BusinessMaster.BusinessValue,
                        QuoteValue = cp.Quote.QuoteValue,
                        ConsumerId = cp.Property.Business.ConsumerId,
                        ConsumerName = cp.Property.Business.Consumer.ConsumerName
                    }).FirstOrDefault();
                return policy;
            }
            catch
            {
                return null;
            }
        }

        public virtual dynamic GetProperties()
        {
            try
            {
                var properties = context.Properties
                    .Include(p => p.Business).Include(p => p.PropertyMaster)
                    .Select(p => new
                    {
                        PropertyId = p.PropertyId,
                        BuildingType = p.BuildingType,
                        BuildingAge = p.BuildingAge,
                        BuildingStoreys = p.BuildingStoreys,
                        PropertyValue = p.PropertyMaster.PropertyValue,
                        BusinessId = p.BusinessId,
                        BusinessValue = p.Business.BusinessMaster.BusinessValue,
                        ConsumerId = p.Business.ConsumerId,
                        ConsumerName = p.Business.Consumer.ConsumerName
                    }).ToList();
                return properties;
            }
            catch
            {
                return null;
            }
        }

        public virtual dynamic GetPolicies()
        {
            try
            {
                var policies = context.ConsumerPolicies
                    .Include(c => c.Property).Include(c => c.PolicyMaster).Include(c => c.Quote)
                    .Select(cp => new
                    {
                        PolicyId = cp.PolicyId,
                        BuildingType = cp.Property.BuildingType,
                        PolicyStatus = cp.PolicyStatus,
                        PropertyId = cp.PropertyId,
                        PropertyType = cp.PolicyMaster.PropertyType,
                        PropertyValue = cp.Property.PropertyMaster.PropertyValue,
                        BusinessValue = cp.Property.Business.BusinessMaster.BusinessValue,
                        QuoteValue = cp.Quote.QuoteValue,
                        ConsumerId = cp.Property.Business.ConsumerId,
                        ConsumerName = cp.Property.Business.Consumer.ConsumerName
                    }).ToList();
                return policies;
            }
            catch
            {
                return null;
            }

        }
    }
}

