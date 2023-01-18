namespace QuanLyNhanKhau.Models
{
    public class ErrorViewModel
    {
        public List<string> noiDung;

        public ErrorViewModel()
        {
            noiDung = new List<string>();
            noiDung.Add("Có lỗi xảy ra");
        }

        public ErrorViewModel(string noiDung)
        {
            this.noiDung = new List<string>();
            this.noiDung.Add(noiDung);
        }

        public ErrorViewModel(List<string> noiDung)
        {
            this.noiDung = noiDung;
        }
    }
}