using System.ComponentModel.DataAnnotations;

namespace ASMCshrp4_12345.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(15, ErrorMessage = "Tên tài khoản không được vượt quá 15 ký tự.")]
        public string? TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự.")]
        public string MatKhau { get; set; }
        [Display(Name = "Nhớ mật khẩu?")]
        public bool RememberMe { get; set; }
    }
}
