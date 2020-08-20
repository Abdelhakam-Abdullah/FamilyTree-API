using System;
using System.Collections.Generic;

namespace FamilyTreeApi.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desctiption { get; set; }
        public string NewsPlace { get; set; }
        public DateTime CreatedDateM { get; set; }
        public DateTime CreatedDateH { get; set; }
        public int NewsTypeId { get; set; }
        public bool? IsAccepted { get; set; }
        public bool IsDelete { get; set; }
        public bool AllowComment { get; set; }
        public int? UserId { get; set; }
        //public int? RequestStatusId { get; set; }

        //public virtual RequestStatus RequestStatus { get; set; }
        public virtual User User { get; set; }
        public virtual NewsType NewsType { get; set; }
        public virtual ICollection<NewsComment> NewsComment { get; set; }
        public virtual ICollection<NewsImage> NewsImage { get; set; }
    }
}
