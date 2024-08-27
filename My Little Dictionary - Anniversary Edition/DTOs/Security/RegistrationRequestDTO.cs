using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.DTOs.Security
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string EmailConfirm { get; set; }


        public void Validate<T>(ValidationResponse<T> validation)
        {
            if (Password != PasswordConfirm)
            {
                validation.Errors.Add("Passwords are different");
            }

            if (Email != EmailConfirm)
            {
                validation.Errors.Add("Emails are different");
            }

        }
    }
}
