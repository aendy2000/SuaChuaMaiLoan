﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuaChuaMaiLoan.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public int Sale { get; set; }
        public int ID_Categories { get; set; }
        public int ID_Flavour { get; set; }
    }
}