using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumScrapper
{
    [Serializable]
    class AssembledInfo
    {
        public List<Info> assembledInfoPerOneScrap;
        public AssembledInfo(List<Info> inf)
        {
            assembledInfoPerOneScrap = new List<Info>();
            foreach (var item in inf)
                assembledInfoPerOneScrap.Add(item);            
        }
    }
}
