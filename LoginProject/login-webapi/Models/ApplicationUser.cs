using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace login_webapi.Models
{
    /*
        Caso eu queira adicionar mais campos para a tabela IdentityUser eu vou colocar os dados nessa classe
     */
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName="nvarchar(150)")]
        public string Fullname { get; set; }

    }
}