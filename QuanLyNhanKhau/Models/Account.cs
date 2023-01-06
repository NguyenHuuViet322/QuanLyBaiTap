using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhanKhau.Models
{
    [Table("Account")]
    public class Account
    {
        public Account(string password, string cMND, int? nhanKhauId)
        {
            Password = password;
            CMND = cMND;
            this.nhanKhauId = nhanKhauId;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAccount {get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}

        public string CMND { get; set;}

        public int role { get; set; }

        public int? nhanKhauId { get; set;}

        [NotMapped]
        public NhanKhau nhanKhau { get; set;}
    }
}
