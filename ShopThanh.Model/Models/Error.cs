using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopThanh.Model.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ID { get; set; }

        public string MessageError { get; set; }

        public DateTime CreateDate { get; set; }

        public string StackTrace { get; set; }
    }
}