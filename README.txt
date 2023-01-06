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

Có 3 tài khoản quản lý được sinh sẵn trong Database.

*, Account: 1111
   Pass:    123
   Role:    Quản lý nhân khẩu 

*, Account: 2222
   Pass:    123
   Role:    Quản lý nhà văn hóa

*, Account: 3333
   Pass:    123
   Role:    ADMIN

Note: Admin có quyền truy cập vào tất cả các page.
      Account của dân sẽ được tự động tạo sau khi thêm nhân khẩu. (Pass mặc định là 123)

#Final

Hãy bắt đầu sử dụng Account ADMIN để có toàn quyền truy cập các chức năng. Sau đó mới tiếp tục sử dụng các Account khác.
Do phần phân quyền và đăng nhập bị Rush vội nên sẽ có "rất" nhiều bug xuất hiện thêm. Xin vui lòng báo lại cho người viết nếu gặp phải.

#END

Chúc các bạn một ngày tốt lành và thuận lợi trong quá trình cài đặt.

Xin cảm ơn,
VietMK