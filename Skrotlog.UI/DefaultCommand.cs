using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Skrotlog.UI
{
    public class DefaultCommand : ICommand
    {
        Action targetExecuteMethod;
        Func<bool> targetCanExecuteMethod;

        public DefaultCommand(Action exeuteMethod)
        {
            targetExecuteMethod = exeuteMethod;
        }

        public DefaultCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : this(executeMethod)
        {
            targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (targetCanExecuteMethod != null)
                return targetCanExecuteMethod();

            if (targetExecuteMethod != null)
                return true;

            return false;
        }

        public void Execute(object parameter)
        {
            if (targetExecuteMethod != null)
                targetExecuteMethod();
        }
    }
}
