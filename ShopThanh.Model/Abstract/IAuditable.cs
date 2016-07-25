using System;

namespace ShopThanh.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreateDate { set; get; }
        string CreatedBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdatedBy { get; set; }
        string MetaKeyWord { get; set; }
        string MetaDescription { get; set; }
        bool status { get; set; }
    }
}