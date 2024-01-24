# Repository Design Pattern

Repository Design Pattern là một mẫu thiết kế phần mềm giúp tách biệt logic truy cập dữ liệu khỏi logic ứng dụng. Mẫu thiết kế này cung cấp một lớp trung gian giữa các lớp ứng dụng và lớp truy cập dữ liệu.

## Lợi Ích của Repository Design Pattern

Sử dụng Repository Design Pattern mang lại nhiều lợi ích cho các ứng dụng, bao gồm:

- **Tăng Độ Bền:** Mẫu thiết kế này giúp tách biệt logic truy cập dữ liệu khỏi logic ứng dụng, giảm tác động của các thay đổi đối với logic truy cập dữ liệu đối với logic ứng dụng.

- **Tăng Khả Năng Mở Rộng:** Mẫu thiết kế này giúp dễ dàng thay đổi lớp truy cập dữ liệu mà không ảnh hưởng đến logic ứng dụng.

- **Tăng Khả Năng Test:** Mẫu thiết kế này giúp dễ dàng test logic truy cập dữ liệu mà không cần test logic ứng dụng.

## Cách Triển Khai Repository Design Pattern

Để triển khai Repository Design Pattern, chúng ta cần thực hiện các bước sau:

1. Tạo một lớp Repository cho mỗi bảng trong cơ sở dữ liệu.

2. Lớp Repository sẽ cung cấp các phương thức để truy vấn, thêm, cập nhật và xóa dữ liệu trong bảng đó.

3. Các lớp ứng dụng sẽ sử dụng các phương thức của lớp Repository để truy cập dữ liệu.

## Ví dụ về Repository Design Pattern

Dưới đây là một ví dụ về cách triển khai Repository Design Pattern cho bảng Users trong cơ sở dữ liệu:

```csharp
public class UsersRepository
{
    private readonly IDataAccessContext _dataAccessContext;

    public UsersRepository(IDataAccessContext dataAccessContext)
    {
        _dataAccessContext = dataAccessContext;
    }

    public IEnumerable<User> GetUsers()
    {
        return _dataAccessContext.Get<User>();
    }

    public User GetUser(int id)
    {
        return _dataAccessContext.Get<User>(id);
    }

    public void AddUser(User user)
    {
        _dataAccessContext.Add(user);
    }

    public void UpdateUser(User user)
    {
        _dataAccessContext.Update(user);
    }

    public void DeleteUser(int id)
    {
        _dataAccessContext.Delete(id);
    }
}
```
Lớp UsersRepository cung cấp các phương thức để truy vấn, thêm, cập nhật và xóa dữ liệu trong bảng Users. Các lớp ứng dụng có thể sử dụng các phương thức này để truy cập dữ liệu trong bảng Users.
## Kết Luận
Repository Design Pattern là một công cụ hữu ích giúp tách biệt logic truy cập dữ liệu khỏi logic ứng dụng. Mẫu thiết kế này mang lại nhiều lợi ích cho các ứng dụng, bao gồm tăng độ bền, khả năng mở rộng và khả năng test.
