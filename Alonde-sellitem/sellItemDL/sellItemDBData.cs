using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using sellModels;
namespace sellItemDL
{
    public class sellItemDBData:Isell
    {
       
         private string connectionString
            = "Data Source=.;Initial Catalog = sellerDatabase; Integrated Security = True; TrustServerCertificate=True;";
        private SqlConnection sqlConnection;
        public sellItemDBData() {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = GetInventory();
            if (existing.Count == 0)
            {
                smodel sell = new smodel
                {
                    sellerId = Guid.NewGuid(),
                    sellerName = "Thomas",
                    ItemId = Guid.NewGuid(),
                    Items = "Pencil",
                    Price = 20
                };
                Add(sell);

            }
        }

        public void Add(smodel sell)
        {
            var insertStatement = "INSERT INTO tbl_sell VALUES (@sellerId,@sellerName,@ItemId,@Items,@Price)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@sellerId", sell.sellerId);
            insertCommand.Parameters.AddWithValue("@sellerName", sell.sellerName);
            insertCommand.Parameters.AddWithValue("@ItemId", sell.ItemId);
            insertCommand.Parameters.AddWithValue("@Items", sell.Items);
            insertCommand.Parameters.AddWithValue("@Price", sell.Price);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdatePrice(smodel sell)
        {

            sqlConnection.Open();

            var updateStatement = $"UPDATE tbl_sell SET sellerId = @sellerId, sellerName = @sellerName, ItemId = @ItemId, Items = @Items,Price = @Price WHERE sellerId = @sellerId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@sellerId", sell.sellerId);
            updateCommand.Parameters.AddWithValue("@sellerName", sell.sellerName);
            updateCommand.Parameters.AddWithValue("@ItemId", sell.ItemId);
            updateCommand.Parameters.AddWithValue("Items", sell.Items);
            updateCommand.Parameters.AddWithValue("@Price", sell.Price);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public void Delete(Guid id)
        {
            sqlConnection.Open();
            var updateStatement = $"DELETE FROM tbl_sell WHERE ItemId = @ItemId";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@ItemId", id);


            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<smodel> GetInventory()
        {
            var selectStatement = "SELECT sellerId,sellerName,ItemId,Items,Price FROM tbl_sell";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            var sell = new List<smodel>();
            while (reader.Read())
            {
                smodel s = new smodel();
                s.sellerId = Guid.Parse(reader["sellerId"].ToString());
                s.sellerName = reader["sellerName"].ToString();
                s.ItemId = Guid.Parse(reader["ItemId"].ToString());
                s.Items = reader["Items"].ToString();
                s.Price = Convert.ToInt32(reader["Price"].ToString());


                sell.Add(s);
            }

            sqlConnection.Close();

            return sell;
        }

        public smodel? GetBySeller(string seller)
        {
            return GetInventory().FirstOrDefault(s => s.sellerName == seller);
        }


    }
}


    


