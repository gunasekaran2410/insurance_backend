using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Models
{
    [Table("customer")]
    public class CustomerModel
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string customerId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? fatherName { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? motherName { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public DateTime? dateofBirth { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? qualification { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? bloodGroup { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string? graduation { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string? gender { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string mobileNumber { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? alternativeNo { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public string? EmailId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? aadharNo { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string permanent_address_street { get; set; }

        [Column(TypeName = "Varchar(250)")]
        public string? permanent_address_area { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? permanent_location { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? permanent_city { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public bool? same_as_permanent_address { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? present_address_street { get; set; }

        [Column(TypeName = "Varchar(250)")]
        public string? present_address_area { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? present_location { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? present_city { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public bool? married_Uncheck_for_single { get; set; }


        [Column(TypeName = "Varchar(150)")]
        public DateTime? dateofWedding { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? spouse_name { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public DateTime? spouse_dateofbirth { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string? children { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string GroupId { get; set; }

    }
}
