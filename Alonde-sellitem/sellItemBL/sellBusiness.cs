using System;
using AccountManagementDataService;
using sellItemDL;
using sellModels;
namespace sellItemBL
{
    public class sellBusiness
    {
        public sellInMemory sl = new sellInMemory();
        selldataservice sd = new selldataservice(new sellItemDBData());
        sellJson sj = new sellJson();   
        public void AddItems(string sellerName, string Items, int price)
        {
            var item = new smodel()
            {
                sellerId = Guid.NewGuid(),
                sellerName = sellerName,
                ItemId = Guid.NewGuid(),
                Items = Items,
                Price = price
            };

            sl.Add(item);
            sd.Add(item);
            sj.Add(item);
        }
        public List<smodel> GetInventory() 
        { 
            return sd.GetInventory();
            return sl.GetInventory(); 
        }
        public List<smodel> GetBySeller(string sellerName)
        {
            return sd.GetInventory()
                     .Where(x => x.sellerName == sellerName)
                     .ToList();
        }

        public void UpdatePrice(Guid itemId, int newPrice)
        {
            var item = sd.GetInventory().FirstOrDefault(x => x.ItemId == itemId);
            if (item != null)
            {
                item.Price = newPrice;
                sd.UpdatePrice(item);
                sj.UpdatePrice(item);
            }
        }

        public void DeleteItem(Guid itemId)
        {
            var item = sd.GetInventory();
              var items  = item.FirstOrDefault(x => x.ItemId == itemId);
            if (items != null)
            {
                item.Remove(items);
 ;                sd.Delete(itemId);

            }
            
        }
    }
}
