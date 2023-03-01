using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIWorkspace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

    public class AllActiveEmployeesController : ControllerBase
    {
        private readonly string _connectionString;

        public AllActiveEmployeesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("tempDB");
        }


        [HttpGet]
        public string GetAllEmployees()
        {
            SqlDataAdapter da = new SqlDataAdapter("exec GetAllEmployees", _connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return JsonConvert.SerializeObject(dt);
        }
    }
}
