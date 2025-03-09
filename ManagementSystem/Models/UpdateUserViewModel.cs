using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-30 karakter olmalıdır.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcı tipi zorunludur.")]
        public int UserType { get; set; }
    }
}
