using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Models
{
    [Table("Policy")]
    public class PolicyModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string policyId { get; set; }  // No need for Varchar, Guid is handled as its own type.

        [Column(TypeName = "Varchar(150)")]
        public string policyName { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? policyDescription { get; set; }

        public bool policyActive { get; set; }  // No need for Varchar, bool is a boolean type.
    }
}
