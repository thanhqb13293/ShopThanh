using System.Collections.Generic;
using System.Linq;

namespace ShopThanh.Web.Infrastructure.Core
{
    public class paginationSet<T>
    {
        //Curent Page
        public int Page { set; get; }

        //Number of pages
        public int Count
        {
            get { return (items != null) ? items.Count() : 0; }
        }
        //Total of page in pagination
        public int TotalPages { set; get; }
        //Number of items
        public int TotalCount { set; get; }
        //Number of items to pagination
        public IEnumerable<T> items { set; get; }
    }
}