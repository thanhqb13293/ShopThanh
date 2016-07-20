using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThanh.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        //register 
        public int Page { get; set; }
        public int Count {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
                }
        //register number of page
        public int TotalPage { set; get; }
        //register number of 
        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}