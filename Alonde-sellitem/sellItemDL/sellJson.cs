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
            _jsonFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonn.json");

            EnsureFileExists();  
            PopulateJsonFile();
        }

       
        private void EnsureFileExists()
        {
            if (!File.Exists(_jsonFileName))
            {
                File.WriteAllText(_jsonFileName, "[]");
            }
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (Jsonsell.Count <= 0)
            {
                Jsonsell.Add(new smodel
                {
                    sellerId = Guid.NewGuid(),
                    sellerName = "admin",
                    ItemId = Guid.NewGuid(),
                    Items = "Food",
                    Price = 10
                });

                SaveDataToJsonFile();
            }
        }

      
        private void SaveDataToJsonFile()
        {
            File.WriteAllText(_jsonFileName,
                JsonSerializer.Serialize(Jsonsell, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
        }

       
        private void RetrieveDataFromJsonFile()
        {
            EnsureFileExists(); 

            var json = File.ReadAllText(_jsonFileName);

            Jsonsell = JsonSerializer.Deserialize<List<smodel>>(json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<smodel>();
        }

        public void Add(smodel s)
        {
            RetrieveDataFromJsonFile();
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
            return Jsonsell.FirstOrDefault(x => x.sellerName == seller);
        }

        public void UpdatePrice(smodel s)
        {
            RetrieveDataFromJsonFile();

            var existing = Jsonsell.FirstOrDefault(x => x.sellerId == s.sellerId);

            if (existing != null)
            {
                existing.Price = s.Price;
                SaveDataToJsonFile();
            }
        }

        public void Delete(Guid id)
        {
            RetrieveDataFromJsonFile();

            var existing = Jsonsell.FirstOrDefault(x => x.sellerId == id);

            if (existing != null)
            {
                Jsonsell.Remove(existing);
                SaveDataToJsonFile();
            }
        }
    }
}