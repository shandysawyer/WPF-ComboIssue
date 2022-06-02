using COREContracts.DataAccess.Models;
using System;

namespace COREContracts.Wrappers
{
    public class ContractWrapper : ModelWrapper<CoreContract>
    {
        public ContractWrapper(CoreContract model) : base(model)
        {
        }

        public int ContractId
        {
            get => GetValue<int>(nameof(ContractId));
            set => SetValue(value);
        }

        public string GroupNo
        {
            get => GetValue<string>(nameof(GroupNo));
            set => SetValue(value);
        }

        public int CarrierId
        {
            get => GetValue<int>(nameof(CarrierId));
            set => SetValue(value);
        }

        public string AgentId
        {
            get => GetValue<string>(nameof(AgentId));
            set => SetValue(value);
        }

        public DateTime EffectiveDate
        {
            get => GetValue<DateTime>(nameof(EffectiveDate));
            set => SetValue(value);
        }

        public DateTime TermDate
        {
            get => GetValue<DateTime>(nameof(TermDate));
            set => SetValue(value);
        }

        
    }
}
