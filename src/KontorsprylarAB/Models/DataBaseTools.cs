using KontorsprylarAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KontorsprylarAB
{
    public static class DataBaseTools
    {

        const string CON_STR = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=blixthalka;Integrated Security=True;Pooling=False";

        public static List<Product> GetAllProducts(int id)
        {
            var allProducts = new List<Product>();


            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand;
            if (id != 0)
            {

                myCommand = new SqlCommand($"SELECT * FROM Products where category = '{id}'", myConnection);
            }
            else
            {
                myCommand = new SqlCommand("SELECT * FROM Products", myConnection);
            }


            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string hej = myReader["Name"].ToString();

                    allProducts.Add(new Product
                    {
                        Id = int.Parse(myReader["Id"].ToString()),
                        ArticleNumber = myReader["ArticleNumber"].ToString(),
                        Name = myReader["Name"].ToString(),
                        Stock = int.Parse(myReader["Stock"].ToString()),
                        ListPrice = double.Parse(myReader["ListPrice"].ToString()),
                        Description = myReader["Description"].ToString() ?? "test",
                        Image = myReader["Image"].ToString() ?? "test",
                        Category = int.Parse(myReader["Category"].ToString())
                    });
                }
            }
            catch (Exception exception)
            {

            }
            finally
            {
                myConnection.Close();
            }

            return allProducts;
        }

        public static Product GetSpecifiedProduct(int id)
        {
            var oneProduct = new Product();


            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand;
            myCommand = new SqlCommand($"SELECT * FROM Products where id = '{id}'", myConnection);


            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {




                    oneProduct.Id = int.Parse(myReader["Id"].ToString());
                    oneProduct.ArticleNumber = myReader["ArticleNumber"].ToString();
                    oneProduct.Name = myReader["Name"].ToString();
                    oneProduct.Stock = int.Parse(myReader["Stock"].ToString());
                    oneProduct.ListPrice = double.Parse(myReader["ListPrice"].ToString());
                    oneProduct.Description = myReader["Description"].ToString() ?? "test";
                    oneProduct.Image = myReader["Image"].ToString() ?? "test";
                    oneProduct.Category = int.Parse(myReader["Category"].ToString());
                    
                }
            }
            catch (Exception exception)
            {

            }
            finally
            {
                myConnection.Close();
            }

            return oneProduct;
        }


        public static List<Product> GetPopularProducts()
        {
            var popularProducts = new List<Product>();


            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand;
          
                myCommand = new SqlCommand("SELECT * FROM Products", myConnection);
            


            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string hej = myReader["Name"].ToString();

                    popularProducts.Add(new Product
                    {
                        Id = int.Parse(myReader["Id"].ToString()),
                        ArticleNumber = myReader["ArticleNumber"].ToString(),
                        Name = myReader["Name"].ToString(),
                        Stock = int.Parse(myReader["Stock"].ToString()),
                        ListPrice = double.Parse(myReader["ListPrice"].ToString()),
                        Description = myReader["Description"].ToString() ?? "test",
                        Image = myReader["Image"].ToString() ?? "test",
                        Category = int.Parse(myReader["Category"].ToString())
                    });
                }
            }
            catch (Exception exception)
            {

            }
            finally
            {
                myConnection.Close();
            }

            return popularProducts;
        }

        public static void AddProduct(AddProductVM viewModel)
        {
            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand;
            myCommand = new SqlCommand($"INSERT INTO Products (ArticleNumber, Name, Stock, ListPrice, Description, Image, Category) VALUES ('{viewModel.ArticleNumber}', '{viewModel.Name}', {viewModel.Stock}, {viewModel.ListPrice}, '{viewModel.Description}', '{viewModel.Image}', {viewModel.Category})", myConnection);


            try
            {
                myConnection.Open();

                var result = myCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
        }
    }

}

