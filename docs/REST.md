# Kiến Trúc Rest và Restful API

Rest là một kiến trúc giao thức truyền tải dữ liệu, sử dụng các phương thức HTTP để truy cập và thao tác các tài nguyên (resources) trên máy chủ.

Restful API là một cách triển khai cụ thể của Rest, tuân thủ các nguyên tắc và quy tắc của Rest.

## Nguyên Tắc và Quy Tắc của Restful API:

1. **Tài nguyên (resources):** Mỗi đối tượng được lưu trữ trên máy chủ được gọi là một tài nguyên.

2. **Định dạng dữ liệu (representations):** Dữ liệu của tài nguyên được biểu diễn dưới dạng các định dạng dữ liệu tiêu chuẩn, chẳng hạn như JSON, XML.

3. **Phương thức HTTP:** Mỗi thao tác đối với tài nguyên được thực hiện bằng một phương thức HTTP khác nhau, chẳng hạn như GET, POST, PUT, DELETE.

4. **URI:** Mỗi tài nguyên được ánh xạ tới một URI (Uniform Resource Identifier) duy nhất.

## Ví dụ:

- Để lấy danh sách sản phẩm từ máy chủ, ta có thể sử dụng phương thức HTTP GET với URI /products.

- Để thêm một sản phẩm mới vào danh sách, ta có thể sử dụng phương thức HTTP POST với URI /products.

- Để cập nhật thông tin một sản phẩm trong danh sách, ta có thể sử dụng phương thức HTTP PUT với URI /products/[id], trong đó [id] là ID của sản phẩm.

- Để xóa một sản phẩm khỏi danh sách, ta có thể sử dụng phương thức HTTP DELETE với URI /products/[id].

## Ưu Điểm của Restful API:

- **Dễ sử dụng và tương thích:** Restful API sử dụng các phương thức HTTP tiêu chuẩn, do đó dễ sử dụng và tương thích với nhiều ngôn ngữ lập trình và nền tảng khác nhau.

- **Tính mở rộng:** Restful API có thể được mở rộng dễ dàng để hỗ trợ các yêu cầu mới.

- **Tính bảo mật:** Restful API có thể được sử dụng để bảo vệ dữ liệu bằng các phương thức mã hóa.

## Nhược Điểm của Restful API:

- **Có thể phức tạp:** Restful API có thể phức tạp nếu cần phải triển khai các yêu cầu phức tạp.

## Kết Luận:

Restful API là một kiến trúc giao thức truyền tải dữ liệu phổ biến, được sử dụng rộng rãi trong việc xây dựng các ứng dụng web và di động.
