using System;
using System.ComponentModel.DataAnnotations;

namespace ASMCsharp4_12345.Models // Thay "YourProject" bằng namespace của bạn
{
    public class CustomAgeValidation : ValidationAttribute
    {
        private readonly int _minimumAge;

        public CustomAgeValidation(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (value is DateOnly dateOfBirth)
            {
                var today = DateOnly.FromDateTime(DateTime.Today); // Lấy ngày hiện tại dưới dạng DateOnly
                var age = today.Year - dateOfBirth.Year;

                if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
                {
                    age--; // Chưa đến sinh nhật trong năm nay, giảm tuổi đi 1
                }

                return age >= _minimumAge;
            }

            return false; // Nếu giá trị không phải là DateOnly, trả về false
        }
    }
}
