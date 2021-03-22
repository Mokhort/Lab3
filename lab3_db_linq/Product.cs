using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_db_linq
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cost { get; set; }
        public string vendor { get; set; }
        public List<Storehouse> Storehouses { get; set; }

    }
}
