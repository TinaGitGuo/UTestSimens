using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC;
using WebMVC.Controllers;

namespace WebMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            Role a=new Role();
            a.Name = "1";
            Assert.AreEqual("1",a.Name);
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index2()
        {
            string connectionString = GetConnectionString();
            // Open a sourceConnection to the AdventureWorks database.
            using (SqlConnection sourceConnection =
                       new SqlConnection(connectionString))
            {
                sourceConnection.Open();

                //  Delete all from the destination table.         
                //SqlCommand commandDelete = new SqlCommand();
                //commandDelete.Connection = sourceConnection;
                //commandDelete.CommandText =
                //    "DELETE FROM dbo.Users";
                //commandDelete.ExecuteNonQuery();

                //  Add a single row that will result in duplicate key         
                //  when all rows from source are bulk copied.         
                //  Note that this technique will only be successful in          
                //  illustrating the point if a row with ProductID = 446           
                //  exists in the AdventureWorks Production.Products table.          
                //  If you have made changes to the data in this table, change         
                //  the SQL statement in the code to add a ProductID that         
                //  does exist in your version of the Production.Products         
                //  table. Choose any ProductID in the middle of the table         
                //  (not first or last row) to best illustrate the result.         
                //SqlCommand commandInsert = new SqlCommand();
                //commandInsert.Connection = sourceConnection;
                //commandInsert.CommandText =
                //    "SET IDENTITY_INSERT dbo.Users ON;" +
                //    "INSERT INTO " + "dbo.Users " +
                //    "([Id], [Name] ,[Age],[CellPhone]) " +
                //    "VALUES(446, 'Lock23','10','LN-3');" +
                //    "SET IDENTITY_INSERT dbo.Users OFF";
                //commandInsert.ExecuteNonQuery();

                // Perform an initial count on the destination table.
                SqlCommand commandRowCount = new SqlCommand(
                    "SELECT COUNT(*) FROM dbo.Users;",
                    sourceConnection);
                long countStart = System.Convert.ToInt32(
                    commandRowCount.ExecuteScalar());
                Debug.WriteLine("Starting row count = {0}", countStart);

                //  Get data from the source table as a SqlDataReader.         
                //SqlCommand commandSourceData = new SqlCommand(
                //    "SELECT [Id], [Name] ,[Age],[CellPhone] " +
                //    "FROM dbo.Users;", sourceConnection);
                //SqlDataReader reader = commandSourceData.ExecuteReader();
                  DataTable dt=new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Age");
                dt.Columns.Add("CellPhone");

                for (var i = 1; i < 10; i++)
                    dt.Rows.Add(i , "Name " + i + 1,i,"LN");
              
                //Set up the bulk copy object inside the transaction. 
                using (SqlConnection destinationConnection =
                           new SqlConnection(connectionString))
                {
                    destinationConnection.Open();

                    using (SqlTransaction transaction =
                               destinationConnection.BeginTransaction())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                                   destinationConnection, SqlBulkCopyOptions.KeepIdentity,
                                   transaction))
                        {
                            bulkCopy.BatchSize = 10;
                            bulkCopy.DestinationTableName =
                                "dbo.Users";

                            // Write from the source to the destination.
                            // This should fail with a duplicate key error.
                            try
                            {
                            //bulkCopy.WriteToServer(reader);
                                bulkCopy.WriteToServer(dt);
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message);
                                transaction.Rollback();
                            }
                            //finally
                            //{
                            //    reader.Close();
                            //}
                        }
                    }
                }

                // Perform a final count on the destination 
                // table to see how many rows were added.
                long countEnd = System.Convert.ToInt32(
                    commandRowCount.ExecuteScalar());
                Debug.WriteLine("Ending row count = {0}", countEnd);
                Debug.WriteLine("{0} rows were added.", countEnd - countStart);
                Debug.WriteLine("Press Enter to finish.");
                 
            }
        }

        
 
    private static string GetConnectionString()
    // To avoid storing the sourceConnection string in your code, 
    // you can retrieve it from a configuration file. 
    {
        return @"data source=STKWX32543\SQLEXPRESS;initial catalog=DemoDB;integrated security=True;";
    //return "Data Source=(local); " +" Integrated Security=true;" +"Initial Catalog=AdventureWorks;";
}
    [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
