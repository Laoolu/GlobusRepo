﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class User
    {
        public int id { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string lga { get; set; }
    }
}
