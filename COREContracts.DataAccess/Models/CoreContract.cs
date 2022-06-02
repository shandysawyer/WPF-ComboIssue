using System;
using System.Collections.Generic;

#nullable disable

namespace COREContracts.DataAccess.Models
{
    public partial class CoreContract
    {
        public int ContractId { get; set; }
        public int CarrierId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TermDate { get; set; }

        public virtual CoreCarrier Carrier { get; set; }
    }
}
