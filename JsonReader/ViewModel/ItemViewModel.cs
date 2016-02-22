using JsonReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JsonReader.ViewModel
{
    public class ItemViewModel : ViewModel
    {
        private ItemModel model;

        public string Header
        {
            get
            {
                return model.header;
            }
            set
            {
                model.header = value;
                OnPropertyChanged(nameof(Header));
            }
        }

        public Type Type
        {
            get
            {
                return model.type;
            }
            set
            {
                model.type = value;
                OnPropertyChanged(nameof(Header));
            }
        }

        public object Data
        {
            get
            {
                return model.data;
            }
            set
            {
                model.data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        public SolidColorBrush Foreground
        {
            get
            {
                return model.foreground;
            }
            set
            {
                model.foreground = value;
                OnPropertyChanged(nameof(Foreground));
            }
        }

        public ItemViewModel(string header, Type type, SolidColorBrush brush, object data)
        {
            model = new ItemModel();
            Header = header;
            Type = type;
            Data = data;
            Foreground = brush;
        }
    }
}
