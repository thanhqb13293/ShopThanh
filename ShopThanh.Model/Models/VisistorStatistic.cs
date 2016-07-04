using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopThanh.Model.Models
{
    [Table("VisistorStatistics")]
    public class VisistorStatistic
    {
        [Key]
        public Guid ID { set; get; }

        [Required]
        public DateTime VisistDate { get; set; }

        [MaxLength(50)]
        public string IpAdress { get; set; }
    }
}