using COREContracts.DataAccess.Models;

namespace COREContracts.Wrappers
{
    public class CarrierWrapper : ModelWrapper<CoreCarrier>
    {
        public CarrierWrapper(CoreCarrier model) : base(model)
        {
        }

        public int CarrierId
        {
            get => GetValue<int>(nameof(CarrierId));
            set => SetValue(value);
        }

        public string CarrierName
        {
            get => GetValue<string>(nameof(CarrierName));
            set => SetValue(value);
        }

        public string CarrierType
        {
            get => GetValue<string>(nameof(CarrierType));
            set => SetValue(value);
        }
    }
}
