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

        //[HttpGet]
        //public JsonResult GetProducts() 
        //{
        //    string query = "select * from products";

        //    DataTable resultTable= new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("CoffeeOrderApp");
        //    NpgsqlDataReader productReader;
        //    using (NpgsqlConnection productConn = new NpgsqlConnection(sqlDataSource))
        //    {
        //        productConn.Open();
        //        using (NpgsqlCommand productCommand =new NpgsqlCommand(query,productConn))
        //        {
        //            productReader = productCommand.ExecuteReader();
        //            resultTable.Load(productReader);

        //            productReader.Close();
        //            productConn.Close();
        //        }

        //    }
        //        return new JsonResult(resultTable);
        //}


        [HttpGet]
        public JsonResult Products()
        {

            string query = @"
                select *
                from Products";
                
            DataTable resultTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoffeeOrderApp");
            NpgsqlDataReader productReader;
            using (NpgsqlConnection productConn = new NpgsqlConnection(sqlDataSource))
            {
                productConn.Open();
                using (NpgsqlCommand productCommand = new NpgsqlCommand(query, productConn))
                {
                    productReader = productCommand.ExecuteReader();
                    resultTable.Load(productReader);

                    productReader.Close();
                    productConn.Close();
                }

            }
            return new JsonResult(resultTable);
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult ProductId(int id)
        {

            string query = @"
                select *
                from Products where id =" + id;

            DataTable resultTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CoffeeOrderApp");
            NpgsqlDataReader productReader;
            using (NpgsqlConnection productConn = new NpgsqlConnection(sqlDataSource))
            {
                productConn.Open();
                using (NpgsqlCommand productCommand = new NpgsqlCommand(query, productConn))
                {
                    productReader = productCommand.ExecuteReader();
                    resultTable.Load(productReader);

                    productReader.Close();
                    productConn.Close();
                }

            }
            return new JsonResult(resultTable);
        }

    }

    
}
