using System;
using System.Windows.Input;

namespace PerformanceMonitor
{
    class RelayCommand : ICommand
    {
        private Action commandTask;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action workToDo)
        {
            commandTask = workToDo;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
