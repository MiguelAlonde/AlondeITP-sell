using System;
using System.Collections.Generic;
using System.Linq;
using sellModels;

namespace sellItemDL
{
    public class sellInMemory
    {
        public List<smodel> smodels = new List<smodel>();

     
        public void Add(smodel s)
        {
            smodels.Add(s);
        }

        
        public List<smodel> GetInventory()
        {
            return smodels;
        }

    
        public List<smodel> GetBySeller(string sellerName)
        {
            return smodels
                .Where(x => x.sellerName == sellerName)
                .ToList();
        }

      
        public bool UpdatePrice(Guid itemId, int newPrice)
        {
            var item = smodels.FirstOrDefault(x => x.ItemId == itemId);

            if (item == null)
                return false;

            item.Price = newPrice;
            return true;
        }

       
        public bool Delete(Guid itemId)
        {
            var item = smodels.FirstOrDefault(x => x.ItemId == itemId);

            if (item == null)
                return false;

            smodels.Remove(item);
            return true;
        }
    }
}