using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Models
{
    [Table("Company")]
    public class CompanyModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string companyId { get; set; }  // No need for Varchar, Guid is handled as its own type.

        [Column(TypeName = "Varchar(150)")]
        public string? companyName { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? companyDescription { get; set; }

        public bool companyActive { get; set; }  // No need for Varchar, bool is a boolean type.
    }
}
