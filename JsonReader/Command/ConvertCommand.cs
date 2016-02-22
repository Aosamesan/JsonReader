using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JsonReader.Command
{
    public class ConvertCommand : ICommand
    {
        public Action ConvertAction
        {
            get; set;
        }

        public static readonly DependencyProperty ConvertProperty
            = DependencyProperty.Register("ConvertAction", typeof(Action), typeof(ConvertCommand));

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ConvertAction?.Invoke();
        }
    }
}
