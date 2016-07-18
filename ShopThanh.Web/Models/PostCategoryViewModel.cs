using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThanh.Web.Models
{
    public class PostCategoryViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }


        public string Image { get; set; }

        public string Description { get; set; }

        public int? DisplayOrder { get; set; }
        public int? ParentID { get; set; }
        public DateTime? CreateDate { set; get; }

        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string UpdatedBy { get; set; }

        public string MetaKeyWord { get; set; }

        public string MetaDescription { get; set; }
        public bool status { get; set; }

        public int? HomeFlag { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}