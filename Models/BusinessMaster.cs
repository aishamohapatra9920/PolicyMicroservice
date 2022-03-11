﻿using System.ComponentModel.DataAnnotations;

namespace PolicyMicroservice.Models
{
    public partial class BusinessMaster
    {
        public BusinessMaster()
        {
            Businesses = new HashSet<Business>();
        }

        [Key]
        public int BusinessMasterId { get; set; }
        public int BusinessValue { get; set; }
        public int BusinessTurnOver { get; set; }
        public int CapitalInvest { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
    }
}
