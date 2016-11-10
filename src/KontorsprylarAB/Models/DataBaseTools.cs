﻿using KontorsprylarAB.Models;
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

        public static List<Product> GetSpecifiedProduct(int id)
        {
            var oneProduct = new List<Product>();


            SqlConnection myConnection = new SqlConnection(CON_STR);
            SqlCommand myCommand;
            myCommand = new SqlCommand($"SELECT * FROM Products where 'id' = '{id}'", myConnection);


            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    string hej = myReader["Name"].ToString();

                    oneProduct.Add(new Product
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

            return oneProduct;
        }


    }

}

