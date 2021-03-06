﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyTreeApi.DTOs
{
    public class NewsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public string NewsType { get; set; }
        public int UserId { get; set; }
        public string NewsImage { get; set; }
        public string ByUser { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public int CommentCount { get; set; }
    }
}
