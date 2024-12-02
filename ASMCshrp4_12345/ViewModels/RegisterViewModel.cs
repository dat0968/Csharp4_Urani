using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự.")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        public string? HoTen { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }
        [StringLength(15, ErrorMessage = "Tên tài khoản không được vượt quá 15 ký tự.")]
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string? TenTaiKhoan { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
        public string? MatKhau { get; set; }
    }
}
