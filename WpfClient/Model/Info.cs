using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient.Model
{
  public class Info : INotifyPropertyChanged
    {

        public string Id { get; set; }
        public string name { get; set; }
        // string wide_name;
        public string price { get; set; }
        public string change { get; set; }
        public string perentage_changed { get; set; }
        //  Type type;

        public Info(string name, string price, string change, string percent_change)
        {
            this.name = name;
            this.price = price;
            this.change = change;
            this.perentage_changed = percent_change;
        }
    

    public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
