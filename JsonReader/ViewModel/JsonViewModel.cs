using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonReader.Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows;

namespace JsonReader.ViewModel
{
    public class JsonViewModel : ViewModel
    {
        private JsonModel model;

        public Action ConvertAction
        {
            get
            {
                return Convert;
            }
        }

        public string JsonString
        {
            get
            {
                return model.jsonString;
            }
            set
            {
                model.jsonString = value;
                OnPropertyChanged(nameof(JsonString));
            }
        }

        public ObservableCollection<TreeViewItem> Items
        {
            get
            {
                return model.items;
            }
            set
            {
                model.items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public JsonViewModel()
        {
            model = new JsonModel();
        }

        private void Convert()
        {
            try {
                object obj = JsonConvert.DeserializeObject(JsonString);
                Items.Clear();
                Items.Add(ConvertItem("JSON", obj));
            }
            catch(Exception e)
            {

            }
        }

        private static TreeViewItem ConvertItem(string name, object obj)
        {
            TreeViewItem item = new TreeViewItem();
            SolidColorBrush foreground = new SolidColorBrush(Colors.Black);
            string header = "null";
            Type type = obj?.GetType();

            item.IsExpanded = true;

            if (obj is JValue)
                obj = (obj as JValue).Value;

            if (obj is JObject)
            {
                IDictionary<string, object> dict = (obj as JObject).ToObject<IDictionary<string, object>>();
                foreach (var pair in dict)
                {
                    item.Items.Add(ConvertItem(pair.Key, pair.Value));
                }
                header = $"{{}} {name}";
            }
            else if (obj is JArray)
            {
                List<object> list = (obj as JArray).ToList<object>();
                int idx = 0;
                foreach (var o in list)
                {
                    item.Items.Add(ConvertItem($"{idx++}", o));
                }
                foreground = new SolidColorBrush(Colors.DarkSeaGreen);
                header = $"[] {name}";
            }
            else if (obj is string)
            {
                header = $"{name} : {obj}";
                foreground = new SolidColorBrush(Colors.Green);
            }
            else if(obj is long || obj is double)
            {
                header = $"{name} : {obj}";
                foreground = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                foreground = new SolidColorBrush(Colors.Red);
            }

            ItemViewModel model = new ItemViewModel(header, type, foreground, obj);
            item.DataContext = model;
            item.SetBinding(TreeViewItem.HeaderProperty, "Header");
            item.SetBinding(TreeViewItem.ForegroundProperty, "Foreground");
            
            return item;
        }
    }
}
