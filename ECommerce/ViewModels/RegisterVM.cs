using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels;

public class RegisterVM
{
    [Required(ErrorMessage = "Ad soyad gereklidir.")]
    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "EPosta adresi gereklidir.")]
    [Display(Name = "EPosta Adresi")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Şifre gereklidir.")]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Şifre tekrarı gereklidir.")]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre tekrar")]
    [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor.")]
    public string ConfirmePassword { get; set; }
}
