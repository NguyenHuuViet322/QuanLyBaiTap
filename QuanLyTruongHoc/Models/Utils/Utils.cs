using Microsoft.CodeAnalysis.Options;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Reflection;

namespace QuanLyTruongHoc.Models.Utils
{
    public class Utils
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static string getKiHoc()
        {
            var hienTai = DateTime.Now;
            var kiHoc = "";
            if (hienTai.Month <= 6)
            {
                kiHoc = (hienTai.Year - 1).ToString() + ".2";
            }
            else
            {
                kiHoc = (hienTai.Year).ToString() + ".1";
            }
            return kiHoc;
        }

        public static string TimeToString(DateTime? time)
        {
            string str;
            if (time.HasValue)
            {
                str = time.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                str = "Không có";
            }
            return str;
        }
    }
}
