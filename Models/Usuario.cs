using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime dataNascimento { get; set; }
        public Usuario() : base() {}
    }
}
