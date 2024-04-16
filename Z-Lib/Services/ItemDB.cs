using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Z_Lib.Exceptions;
using Z_Marked.Model;
using Z_Marked.Services;

namespace Z_Lib.Services
{
    public class ItemDB : IItemSource
    {
        public ItemDB(bool mockdata = false)
        {
            if (mockdata) {
                foreach (var item in MockItems.GetMockItems())
                {
                    AddItem(item);
                }
            }
            
            
        }
        private string ConnectionString = Secret.ConnectionString;

        public Item AddItem(Item item)
        {
            string query = "insert into Z_Item values (@pName, @pPrice, @pDescription, @pCategory, @pNContent, @pImagePath)";
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pName", item.Name);
                cmd.Parameters.AddWithValue("@pPrice", item.Price);
                cmd.Parameters.AddWithValue("@pDescription", item.Description);
                cmd.Parameters.AddWithValue("@pCategory", item.Category);
                cmd.Parameters.AddWithValue("@pNContent", item.NutritionalContent);
                cmd.Parameters.AddWithValue("@pImagePath", item.ImagePath);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ItemDBException(item.Name);
                }
                
            }
            return item;

        }

        public Item Delete(Item item)
        {
            string query = "delete from Z_Item where Name = @pName";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pName", item.Name);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ItemDBException(item.Name, "slettet");
                }

            }
            return item;
        }

        public Item GetItem(int id)
        {
            Item? item = null; 
            string query = "select * from Z_Item where ID = @pItem";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pItem", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item = ReadItemFromDB(reader);
                }

            }
            if (item == null) {
                throw new ItemDBException(id);
            }
            return item;
        }

        private Item ReadItemFromDB(SqlDataReader reader)
        {
            return new Item(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
        }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            
            string query = "select * from Z_Item ";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(ReadItemFromDB(reader));
                }
            }
            
            return items;
        }

        public Item Update(int id, Item item)
        {
            string query = "update Z_Item " +
                "set Name = @pName," +
                "Price = @pPrice," +
                "Description = @pDescription," +
                "Category = @pCategory," +
                "[Nutritional Content] = @pNContent," +
                "ImagePath = @pIPath " +
                "where ID = @pID";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@pName", item.Name);
                cmd.Parameters.AddWithValue("@pPrice", item.Price);
                cmd.Parameters.AddWithValue("@pDescription", item.Description);
                cmd.Parameters.AddWithValue("@pCategory", item.Category);
                cmd.Parameters.AddWithValue("@pNContent", item.NutritionalContent);
                cmd.Parameters.AddWithValue("@pIPath", item.ImagePath);
                cmd.Parameters.AddWithValue("@pID", id);
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ItemDBException(item.Name, "opdateret");
                }

            }
            return item;
        }

    }
}
