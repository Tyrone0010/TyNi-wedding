using Microsoft.AspNet.Identity.EntityFramework;

namespace TyNi.Wedding.AuthApi
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
            
        }

    }
}