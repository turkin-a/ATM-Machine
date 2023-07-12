using ATM_Machine.Models;
using ATM_Machine.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine.Commands
{
    public class UpdateStatusCommand : CommandBase
    {
        MainWindowViewModel _viewModel;
        MoneyVaultManager _manager;
        public UpdateStatusCommand(MainWindowViewModel viewModel, MoneyVaultManager manager)
        {
            _viewModel = viewModel;
            _manager = manager;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.StatusText = _manager.ATMStatus;
        }
    }
}
