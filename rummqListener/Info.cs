using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rummqListener
{
  
        public class Info
        {
            public string name;
            // string wide_name;
            public string price;
            public string change;
            public string percent_change;
            //  Type type;

            public Info(string name, string price, string change, string percent_change)
            {
                this.name = name;
                // this.wide_name = wide_name;
                this.price = price;
                this.change = change;
                this.percent_change = percent_change;
            }
        
        }
}
