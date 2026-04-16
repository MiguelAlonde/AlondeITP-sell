using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sellModels;

namespace sellItemDL
{
    public interface Isell
    {
        void Add(smodel sell);
        void UpdatePrice(smodel sell);
        void Delete(Guid id);
        List<smodel> GetInventory();
        public smodel? GetBySeller(string seller);
    }
}
