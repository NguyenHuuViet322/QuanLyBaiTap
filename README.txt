#Environment

1. Cài đặt .NET SDK. (https://dotnet.microsoft.com/en-us/download)
2. Sau khi Clone Source Code, Visual Studio sẽ báo những extension cần cài đặt để chạy.

Note: Kiểm tra bằng cách chạy lệnh "dotnet --info" trên CMD. 
      Nếu không tìm thấy .NET SDKs, hãy thử vào xóa folder dotnet trong C:\Program File (x86)

#SQL Server Setup

1. Cài đặt SQL Server
2. Thiết lập SA account
   Guide: https://www.youtube.com/watch?v=HDCcRdrZcKE (Thằng cha nghe đọc tiếng Anh có accent rất Việt Nam :))   
   Thiết lập: Account: sa
	      Pass:    123
3. Mở SQL Server Management
4. Chọn Authenication => SQL Server Authentication
   Login: sa
   Pass:  123
5. Nếu không đăng nhập được tức là đã làm thiếu hoặc sai bước. (Hãy thử restart service SQL Server hoặc reboot máy)

#Database Generator

1. Mở Project bằng Visual Studio
2. Chọn Tools => NuGet Package Manager => Package Manager Console
3. Nhập UPDATE-DATABASE
4. Kiểm tra lại SQL Server xem Database đã được tạo chưa.
5. Nếu lỗi thì hãy thực hiện lại từ bước 1.

Note: Trong trường hợp không thực hiện được => Sử dụng file backup trong folder Database

#Account

Tài khoản Admin:

Admin
123

Note: Admin có quyền truy cập vào tất cả các page.
      Account của các nhân tố sẽ được tự động tạo sau khi thêm nhân khẩu. (Pass mặc định là 123)

#Final

Hãy bắt đầu sử dụng Account ADMIN để có toàn quyền truy cập các chức năng. Sau đó mới tiếp tục sử dụng các Account khác.
Do phần phân quyền và đăng nhập bị Rush vội nên sẽ có "rất" nhiều bug xuất hiện thêm. Xin vui lòng báo lại cho người viết nếu gặp phải.

#Luồng dữ liệu

Kịch bản bình thường (Nên làm theo thứ tự này do vài object tạo sau cần thông tin của object tạo trước. VÍ DỤ: Không tạo giáo viên thì lúc tạo lớp sẽ không có giáo viên chủ nhiệm để chọnn)

=> Tạo môn học
=> Tạo giáo viên (Chuyên môn của giáo viên không ảnh hưởng đến môn dạy, một giáo viên có thể dạy nhiều môn)
=> Tạo lớp học
=> Tạo học sinh
=> Tạo thời khóa biểu

Trong phần tạo giáo viên có 3 phần quyền: 
Giáo viên giảng dạy bình thường
Giáo vụ quản lý các lớp và nghiệp vụ
Hiệu trưởng làm bố

Tài khoản của giáo viên học sinh sẽ đc tự tạo theo thứ tự tạo của người đó
Học sinh 1 thì tài khoản là HS1 pass 123
GIáo viên 1 thì là GV1 pass 123
Tương tự với hiệu trưởng và giáo vụ

#END

Chúc các bạn một ngày tốt lành và thuận lợi trong quá trình cài đặt.

Xin cảm ơn,
VietMK