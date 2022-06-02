using System;
using System.Collections.Generic;

#nullable disable

namespace COREContracts.DataAccess.Models
{
    public partial class CoreCarrier
    {
        public CoreCarrier()
        {
            CoreContracts = new HashSet<CoreContract>();
        }

        public int CarrierId { get; set; }
        public string CarrierName { get; set; }

        public virtual ICollection<CoreContract> CoreContracts { get; set; }
    }
}
