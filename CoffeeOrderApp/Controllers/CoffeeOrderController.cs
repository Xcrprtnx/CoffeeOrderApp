using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;

namespace CoffeeOrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeOrderAppController : ControllerBase

    {
        private readonly IConfiguration _configuration;

        public CoffeeOrderAppController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        [HttpGet]
        public JsonResult GetProducts() 
        {
            string query = "select * from products";

            DataTable table= new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoffeeOrderApp");
            NpgsqlDataReader productReader;
            using (NpgsqlConnection productConn = new NpgsqlConnection(sqlDataSource))
            {
                productConn.Open();
                using (NpgsqlCommand productCommand =new NpgsqlCommand(query,productConn))
                {
                    productReader = productCommand.ExecuteReader();
                    table.Load(productReader);

                    productReader.Close();
                    productConn.Close();
                }

            }



                return new JsonResult(table);
        }


    }

    
}
