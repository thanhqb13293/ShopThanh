using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopThanh.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAdress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMessage { get; set; }

        [MaxLength(256)]
        public string PayementMethode { get; set; }

        public DateTime? CrateDate { set; get; }
        public string Crateby { get; set; }
        public string PayementStatus { get; set; }
        public bool Status { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}