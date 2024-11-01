using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Producer: IEntityBase 
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; }

    [Display(Name = "Biografi")]
    public string Bio { get; set; }

    [Display(Name = "Profil Resmi")]
    public string ProfilePictureUrl { get; set; }
}
