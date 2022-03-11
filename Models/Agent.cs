using System.ComponentModel.DataAnnotations;

namespace PolicyMicroservice.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Consumers = new HashSet<Consumer>();
        }

        [Key]
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Consumer> Consumers { get; set; }
    }
}
