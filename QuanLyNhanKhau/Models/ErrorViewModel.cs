namespace QuanLyNhanKhau.Models
{
    public class ErrorViewModel
    {
        public string noiDung;

        public ErrorViewModel()
        {
            this.noiDung = "Có lỗi xảy ra";
        }

        public ErrorViewModel(string noiDung)
        {
            this.noiDung = noiDung;
        }
    }
}