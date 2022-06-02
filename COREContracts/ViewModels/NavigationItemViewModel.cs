using COREContracts.Base;
using COREContracts.DataAccess.Models;

namespace COREContracts.ViewModels
{
public class NavigationItemViewModel : Observable
{
    private CoreContract _contract;

    public NavigationItemViewModel(CoreContract contract)
    {
        _contract = contract;
    }
        
    public int ContractId
    {
        get { return _contract.ContractId; }
        set
        {
            _contract.ContractId = value;
            OnPropertyChanged();
        }
    }

    public string CarrierName
    {
        get { return _contract.Carrier.CarrierName; }
        set
        {
            _contract.Carrier.CarrierName = value;
            OnPropertyChanged();
        }
    }
}
}
