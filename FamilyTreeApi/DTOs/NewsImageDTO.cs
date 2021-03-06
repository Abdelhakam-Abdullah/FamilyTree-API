﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class NewsImageDTO
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public int NewsId { get; set; }
        public bool IsMain { get; set; }
        public bool IsDelete { get; set; }
    }
}
