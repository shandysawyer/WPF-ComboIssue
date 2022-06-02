using COREContracts.Base;
using COREContracts.DataAccess.Models;
using COREContracts.DataAccess.Repositories;
using COREContracts.Events;
using COREContracts.Wrappers;
using Notifications.Wpf;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace COREContracts.ViewModels
{
    public class LookupItem
    {
        public int Id { get; set; }
        public string DisplayValue { get; set; }
    }

    public class ContractEditViewModel : Observable, IContractEditViewModel
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IEventAggregator _eventAggregator;
        private CoreContract _contract;
        private IEnumerable<LookupItem> _carriers;

        public CoreContract Contract
        {
            get => _contract;
            set
            {
                _contract = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<LookupItem> CarrierLookup
        {
            get { return _carriers; }
            set
            {
                _carriers = value;
                OnPropertyChanged();
            }
        }

        public ContractEditViewModel(ICoreRepository coreRepository, IEventAggregator eventAggregator)
        {
            _coreRepository = coreRepository;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenContractEditViewEvent>()
                .Subscribe(OnOpenContractView);
        }

        public async Task LoadAsync(int ContractId)
        {
            var carriers = await _coreRepository.GetAllCarriersAsync();
            CarrierLookup = carriers.Select(c =>
                new LookupItem
                {
                    Id = c.CarrierId,
                    DisplayValue = c.CarrierName
                });

            Contract = await _coreRepository.FindContractByIdAsync(ContractId);
        }

        private async void OnOpenContractView(int contractId)
        {
            await LoadAsync(contractId);
        }
    }
}
