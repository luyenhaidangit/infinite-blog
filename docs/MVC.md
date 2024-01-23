# Mô hình Kiến trúc MVC

MVC là viết tắt của Model - View - Controller, là một mô hình kiến trúc phần mềm phổ biến trong lập trình web. Mô hình này tách biệt ứng dụng thành ba thành phần chính:

**Model:** Chịu trách nhiệm lưu trữ và xử lý dữ liệu.

**View:** Chịu trách nhiệm hiển thị dữ liệu cho người dùng.

**Controller:** Chịu trách nhiệm xử lý yêu cầu từ người dùng và điều phối giữa Model và View.

## Luồng Hoạt Động của MVC:

1. Người dùng gửi yêu cầu đến ứng dụng qua trình duyệt web.
2. Controller tiếp nhận yêu cầu và xác định loại yêu cầu.
3. Nếu yêu cầu cần xử lý dữ liệu, controller sẽ gọi đến Model để lấy dữ liệu.
4. Model xử lý dữ liệu và trả về cho controller.
5. Controller trả dữ liệu cho view để hiển thị cho người dùng.

### Ví dụ:

Khi người dùng truy cập vào trang web danh sách sản phẩm, trình duyệt web sẽ gửi yêu cầu đến ứng dụng web. Controller sẽ tiếp nhận yêu cầu và xác định loại yêu cầu là truy cập trang danh sách sản phẩm. Sau đó, controller sẽ gọi đến Model để lấy dữ liệu danh sách sản phẩm. Model sẽ kết nối với cơ sở dữ liệu để lấy dữ liệu và trả về cho controller. Controller sẽ trả dữ liệu cho view để hiển thị cho người dùng.

## Ưu điểm của MVC:

- Mô hình MVC giúp phân tách ứng dụng thành các thành phần riêng biệt, giúp cho việc phát triển, bảo trì và mở rộng ứng dụng dễ dàng hơn.
- Mô hình MVC giúp tăng tính bảo mật của ứng dụng, do dữ liệu và giao diện người dùng được tách biệt.
- Mô hình MVC giúp tăng tính tái sử dụng của mã nguồn, do các thành phần của ứng dụng có thể được sử dụng lại trong các ứng dụng khác.

## Nhược điểm của MVC:

- Mô hình MVC có thể khiến ứng dụng trở nên phức tạp hơn, do cần phải quản lý nhiều thành phần.
- Mô hình MVC có thể khiến ứng dụng chạy chậm hơn, do cần phải truyền dữ liệu giữa các thành phần.
