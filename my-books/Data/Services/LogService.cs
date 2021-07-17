using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class LogService
    {
        private AppDbContext _context;
        public LogService(AppDbContext context)
        {
            _context = context;
        }

        public List<Log> GetAllLogsFromDb() => _context.Logs.ToList();
    }
}
