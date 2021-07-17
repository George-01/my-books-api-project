using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogService _logService;

        public LogsController(LogService logService)
        {
            _logService = logService;
        }

        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDb()
        {
            try
            {
                var allLogs = _logService.GetAllLogsFromDb();
                return Ok(allLogs);
            }
            catch (Exception)
            {
                return BadRequest("Could not load logs from the database");
            }
        }
    }
}
