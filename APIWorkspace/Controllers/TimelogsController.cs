using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIWorkspace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimelogsController : ControllerBase
    {
        private readonly string _connectionString;

        public TimelogsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("tempDB");
        }

        [HttpGet]
        [Route("GetTimelogs")]
        public string GetTimelogs()
        {
            SqlDataAdapter da = new SqlDataAdapter("exec GetTimelog", _connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return JsonConvert.SerializeObject(dt);
        }


        [HttpGet]
        [Route("GetEmployeeTimelogs")]
        public string GetEmployeeTimelogs(string employeeID)
        {
            SqlDataAdapter da = new SqlDataAdapter("exec GetEmployeeTimelog @employeeID =" + employeeID, _connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return JsonConvert.SerializeObject(dt);
        }
    }
}
