using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("Request")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdRequest { get; set; }

        [Required]
        public int? IdNhanKhau { get; set; }

        [Required]
        [Range(0, 5)]
        public int requestTime { get; set; }

        [Required]
        public DateTime requestDay { get; set; }

        [Required]
        public Boolean status { get; set; }

        public string ghiChu { get; set; }


        [ForeignKey("IdNhanKhau")]
        public NhanKhau? nhanKhau { get; set; }
    }
}
