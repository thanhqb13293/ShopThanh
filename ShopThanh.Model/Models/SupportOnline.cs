﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopThanh.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Departement { get; set; }

        [MaxLength(50)]
        public string Skype { get; set; }

        [MaxLength(50)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Yahoo { get; set; }

        [MaxLength(50)]
        public string Facebook { get; set; }

        public string Status { get; set; }

        public int? DisplayOrder { get; set; }
    }
}