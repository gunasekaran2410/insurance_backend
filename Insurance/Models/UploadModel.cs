using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Models
{
    [Table("custome_upload")]
    public class UploadModel
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
