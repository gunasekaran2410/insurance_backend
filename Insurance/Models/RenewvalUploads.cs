using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Models
{
    [Table("renewval_upload")]
    public class RenewvalUploads
    {
        [Key]
        [Column(TypeName = "Varchar(150)")]
        public string imgId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string GroupId { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string imgPath { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public string imgSource { get; set; }

        [Column(TypeName = "Varchar(150)")]
        public DateTime? CreatedDate { get; set; }
    }
}
