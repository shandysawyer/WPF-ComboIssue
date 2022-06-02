using COREContracts.Base;
using COREContracts.DataAccess.Repositories;
using COREContracts.Events;
using COREContracts.Wrappers;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace COREContracts.ViewModels
{
public class NavigationViewModel : Observable, INavigationViewModel
{
    private readonly ICoreRepository _coreRepository;
    private readonly IEventAggregator _eventAggregator;
    private NavigationItemViewModel _selectedNavigationItem;

    public ObservableCollection<NavigationItemViewModel> NavigationItems { get; set; }

    public NavigationItemViewModel SelectedNavigationItem
    {
        get { return _selectedNavigationItem; }
        set
        {
            _selectedNavigationItem = value;
            OnPropertyChanged();
            if (_selectedNavigationItem != null)
            {
                _eventAggregator.GetEvent<OpenContractEditViewEvent>()
                    .Publish(_selectedNavigationItem.ContractId);
            }
        }
    }

    public NavigationViewModel(ICoreRepository coreRepository, IEventAggregator eventAggregator)
    {
        _coreRepository = coreRepository;
        _eventAggregator = eventAggregator;
        NavigationItems = new ObservableCollection<NavigationItemViewModel>();
    }

    public async Task LoadAsync()
    {
        NavigationItems.Clear();
        foreach (var contract in await _coreRepository.GetAllContractsAsync())
        {
            NavigationItems.Add(new NavigationItemViewModel(contract));
        }
    }
}
}
