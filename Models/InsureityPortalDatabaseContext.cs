using Microsoft.EntityFrameworkCore;

namespace PolicyMicroservice.Models
{
    public partial class InsureityPortalDatabaseContext:DbContext
    {
        public InsureityPortalDatabaseContext()
        {
        }

        public InsureityPortalDatabaseContext(DbContextOptions<InsureityPortalDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessMaster> BusinessMasters { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<ConsumerPolicy> ConsumerPolicies { get; set; }
        public virtual DbSet<PolicyMaster> PolicyMasters { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyMaster> PropertyMasters { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
    }
}
