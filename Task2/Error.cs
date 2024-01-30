using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Error
    {
        public int Id { get; set; }
        public int AlterId { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Request { get; set; }
        public StatusCode Status { get; set; }
    }
}
