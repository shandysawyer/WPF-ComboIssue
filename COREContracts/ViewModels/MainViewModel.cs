using COREContracts.Base;
using System.Threading.Tasks;

namespace COREContracts.ViewModels
{
public class MainViewModel : Observable
{
    public INavigationViewModel NavigationViewModel { get; }
    public IContractEditViewModel ContractEditViewModel { get; }

    public MainViewModel(INavigationViewModel navigationViewModel, IContractEditViewModel contractEditViewModel)
    {
        NavigationViewModel = navigationViewModel;
        ContractEditViewModel = contractEditViewModel;
    }

    public async Task LoadAsync()
    {
        await NavigationViewModel.LoadAsync();
    }
}
}
