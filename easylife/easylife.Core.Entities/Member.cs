using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Entities
{
    public class Member
    {
        public int    Memeber_id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Memeber_Since { get; set; }
        public string Last_Logged_In { get; set; }
        public float  Total_Purchase { get; set; }
    }
}
