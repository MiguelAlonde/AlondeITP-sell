using System;
using sellModels;
namespace sellItemDL
{
    public class selldataservice:Isell
    {
        Isell _dataservice;

        public selldataservice(Isell iselldata)
        {
            _dataservice = iselldata;
        }
        public void Add(smodel sell)
        {
            _dataservice.Add(sell);
        }
        public void UpdatePrice(smodel sell)
        {
            _dataservice.UpdatePrice(sell);
        }
        public void Delete(Guid id)
        {
            _dataservice.Delete(id);
        }
        public smodel? GetBySeller(string seller)
        {
            return _dataservice.GetBySeller(seller);
        }

        public List<smodel> GetInventory()
        {
            return _dataservice.GetInventory();
        }
    }
}
