using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Kullanıcı Adı")]
    public string FullName { get; set; }
}
