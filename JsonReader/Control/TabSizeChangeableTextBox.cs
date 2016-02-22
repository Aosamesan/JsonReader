using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JsonReader.Control
{
    public class TabSizeChangeableTextBox   : TextBox, INotifyPropertyChanged
    {
        private int tabSize;

        public int TabSize
        {
            get
            {
                return tabSize;
            }
            set
            {
                tabSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TabSize)));
            }
        }

        public string TabSpaces
        {
            get
            {
                return new string(' ', TabSize);
            }
        }
        public static readonly DependencyProperty TabSizeProperty
            = DependencyProperty.Register("TabSize", typeof(int), typeof(TabSizeChangeableTextBox));

        public event PropertyChangedEventHandler PropertyChanged;

        public TabSizeChangeableTextBox()   : base()
        {
            TabSize = 4;
        }

        protected void OnPaste(object sender, TextChangedEventArgs e)
            => Text = Text.Replace("\t", TabSpaces);

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                int caretPosition = CaretIndex;
                Text = Text.Insert(caretPosition, TabSpaces);
                CaretIndex = caretPosition + TabSize + 1;
                e.Handled = true;
            }
        }
    }
}
