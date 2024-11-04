using ECommerce.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Actor : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profil Resmi")]
    [Required(ErrorMessage = "Profil Resmi Zorunludur.")]
    public string ProfilePictureUrl { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Ad Soyad Bilgisi Zorunludur.")]
    [StringLength(50
        , ErrorMessage = "İsim 3 ile 50 karakter arasında olmalıdır."
        , MinimumLength = 3)]
    public string FullName { get; set; }

    [Display(Name = "Biografi")]
    [Required(ErrorMessage = "Biyografi Bilgisi Zorunludur.")]
    public string Bio { get; set; }


    //Relationship

    [ValidateNever]
    public List<Actor_Movie> Actors_Movies { get; set; }
}
