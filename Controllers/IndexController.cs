using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Kforce_HelloWorld.Controllers
{
    public class IndexController : Controller
    {
        // Method that gets the view info
        public ActionResult Index()
        {
            ViewBag.Message = GetHello(); // Call the GetHello method, this has the hello world value
            return View();
        }
        
        // Method that retrieves the hello text
        public string GetHello()
        {
            World world = new World(); // create an instance of the world object             
            // world.SayHello = "Hello World"; // another way to set the hello world text(Since I set the text in the World constuctor this statement is not needed)
            return world.SayHello; // return the SayHello value of the current instance of the World object.
        }

       //   Method that set the World's object SayHello Text value from a database, this method the sql database info from the web.config
       // Note:there is only one value in the database table, if the database table had more than one row, I'd use a List object of type World and have the method return a List instead of a string it'd look like public List<World> GetHelloValuesFromDB()
        public string GetHelloValueFromDB()
        {
            World world = new World(); // Create the current instance of the world object
            string con = ConfigurationManager.ConnectionStrings["SQL_Connection"].ConnectionString;
            using (var conn = new SqlConnection(con))
            {
                conn.Open(); // open the sql connection
                // Get the data from the database using a stored proc
                using (SqlCommand command = new SqlCommand("Up_Get_HelloWorld_Value"))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            world.SayHello = reader["text_value"].ToString();
                        }
                    }
                }
            }
            return world.SayHello;
        }
    }
}