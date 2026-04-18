using System.Security.Principal;
using System.Text.Json;
using sellItemDL;
using sellModels;

namespace AccountManagementDataService
{
    public class sellJson : Isell
    {
        private List<smodel> Jsonsell = new List<smodel>();

        private string _jsonFileName;

        public sellJson()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/jsonn.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (Jsonsell.Count <= 0)
            {
                Jsonsell.Add(new smodel { sellerId = Guid.NewGuid(), sellerName = "admin", ItemId = Guid.NewGuid(), Items ="Food", Price = 10 });
           
                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<smodel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , Jsonsell);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.Jsonsell = JsonSerializer.Deserialize<List<smodel>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void Add(smodel s)
        {
            Jsonsell.Add(s);
            SaveDataToJsonFile();
        }

        public List<smodel> GetInventory()
        {
            RetrieveDataFromJsonFile();
            return Jsonsell;
        }

        public smodel? GetBySeller(string seller)
        {
            RetrieveDataFromJsonFile();
            return Jsonsell.Where(x => x.sellerName == seller).FirstOrDefault();
        }

        public void UpdatePrice(smodel s)
        {
            RetrieveDataFromJsonFile();

            var existing = Jsonsell.FirstOrDefault(x => x.sellerId == s.sellerId);

            if (existing != null)
            {

                existing.Price = s.Price;
            }

            SaveDataToJsonFile();
        }

        public void Delete(Guid id)
        {
            RetrieveDataFromJsonFile();

            var existing = Jsonsell.FirstOrDefault(x => x.sellerId == id);

            if (existing != null)
            {

                Jsonsell.Remove(existing);  
            }

            SaveDataToJsonFile();
        }




    }
}