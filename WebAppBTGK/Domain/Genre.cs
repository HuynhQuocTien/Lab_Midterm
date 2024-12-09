﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; }
    }
}