using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Models
{
    [Table("Renewal")]
    public class RenewalModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string renewalId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string customerId { get; set; }

        [ForeignKey("customerId")]
        public CustomerModel? customer { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string customer_name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string companyId { get; set; }

        [ForeignKey("companyId")]
         public CompanyModel? company { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string policyId { get; set; }

        [ForeignKey("policyId")]
        public PolicyModel? policy { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string policy_no { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string policy_for { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public DateTime renewal_date { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string duration_months { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public DateTime next_renewal { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string amount { get; set; }

        [Column(TypeName = "Varchar(300)")]
        public string? description { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string GroupId { get; set; }


    }
}
