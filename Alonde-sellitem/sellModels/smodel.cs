namespace sellModels
{
    public class smodel
    {
       public Guid sellerId { get; set; }
        public Guid ItemId { get; set; }
       public string sellerName { get; set; } 
       public string Items { get; set; }
        public int Price { get; set; } = 0;

    }
}
