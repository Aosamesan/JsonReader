using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace JsonReader.Model
{
    public class JsonModel
    {
        public string jsonString;
        public ObservableCollection<TreeViewItem> items;

        public JsonModel()
        {
            items = new ObservableCollection<TreeViewItem>();
        }
    }
}
