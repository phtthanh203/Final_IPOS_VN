# Final_IPOS_VN

Ứng dụng **IPOS** (C#) – dự án cuối kỳ / bài final, xây dựng theo mô hình phân lớp (Presentation / Business / DataAccess) và có kèm script database.

## Công nghệ sử dụng
- **C# / .NET (Windows Forms)**
- **SQL Server** (có file script tạo DB: `IPOS/DB.sql`)

## Cấu trúc thư mục (tóm tắt)
- `IPOS/IPOS.sln` – Solution
- `IPOS/IPOS.csproj` – Project WinForms
- `IPOS/Presentation/` – Tầng giao diện
- `IPOS/Business/` – Tầng xử lý nghiệp vụ
- `IPOS/DataAccess/` – Tầng truy cập dữ liệu
- `IPOS/DB.sql` – Script tạo database/bảng dữ liệu
- `IPOS/Form_SignIn.*` – Màn hình đăng nhập
- `IPOS/App.config` – Cấu hình ứng dụng (connection string, ...)

## Yêu cầu môi trường
- Visual Studio (khuyến nghị 2019/2022)
- .NET Framework (phụ thuộc theo cấu hình trong project)
- SQL Server (LocalDB/Express/Developer đều được)

## Cách chạy project
### 1) Clone repository
```bash
git clone https://github.com/phtthanh203/Final_IPOS_VN.git
```

### 2) Tạo database
- Mở file `IPOS/DB.sql`
- Chạy script trên SQL Server để tạo database và dữ liệu cần thiết

> Lưu ý: Tên DB / user / mật khẩu có thể cần chỉnh lại cho đúng với máy bạn.

### 3) Cấu hình Connection String
- Mở `IPOS/App.config`
- Cập nhật `connectionString` cho đúng thông tin SQL Server của bạn (Server, Database, User/Password hoặc Trusted_Connection)

### 4) Mở solution và chạy
- Mở `IPOS/IPOS.sln` bằng Visual Studio
- Chọn **Start** để chạy chương trình

## Tính năng (mô tả ngắn)
- Đăng nhập (Form `Form_SignIn`)
- Các chức năng nghiệp vụ khác nằm trong các màn hình thuộc `Presentation/` và xử lý qua `Business/` + `DataAccess/`

## Ảnh minh h��a
Một số ảnh trong repo:
- `IPOS/Screenshot 2025-05-29 145920.png`
- `IPOS/take.png`
- `IPOS/takeaway.png`
- `IPOS/takeaway1.png`

## Ghi chú
- Repo hiện có thư mục `.vs/` và `bin/`, `obj/` trong `IPOS/`. Thông thường nên đưa các thư mục build/cache này vào `.gitignore` để repo gọn hơn.
- Nếu bạn muốn mình viết README chi tiết hơn (mô tả đầy đủ chức năng, luồng màn hình, tài khoản mẫu, ERD DB), hãy gửi thêm:
  - Chuỗi connection string mẫu / tên DB
  - Các màn hình chính trong `Presentation/`
  - Tài khoản test (nếu có)
