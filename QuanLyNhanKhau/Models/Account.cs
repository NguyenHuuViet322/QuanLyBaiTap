using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("Account")]
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAccount {get; set;}

        [Required]
        public int Password { get; set;}

        public string CMND { get; set;}

        public int nhanKhauId { get; set;}

        [ForeignKey("nhanKhauId")]
        public NhanKhau nhanKhau { get; set;}
    }
}
