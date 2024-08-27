using Microsoft.AspNetCore.Identity;
using My_Little_Dictionary___Anniversary_Edition.Interfaces;

namespace My_Little_Dictionary___Anniversary_Edition.Model
{
    public class RefreshToken : BaseModel
    {
        public IdentityUser User { get; set; }
        public Guid Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Expires { get; set; }
        public bool Used { get; set; }
        public bool Valid => !Used && Expires > DateTime.Now;

        public RefreshToken()
        {
            
        }

        public RefreshToken(IdentityUser user, IConfiguration configuration) : base()
        {
            float interval = float.Parse(configuration["RefreshToken:Expires"]);

            User = user;
            Token = Guid.NewGuid();
            Used = false;
            CreatedOn = DateTime.Now;
            Expires = DateTime.Now.AddHours(interval);
        }

        public Guid? Use()
        {
            if (!Valid)
                return null;

            Used |= true;
            return Token;
        }
    }
}
