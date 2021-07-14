using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        public string Name { get; set; }

        //Nav props
        public List<Book> Books { get; set; }
    }
}
