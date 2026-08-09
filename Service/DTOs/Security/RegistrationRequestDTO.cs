using Service.Validation;

namespace Service.DTOs.Security
{
    public class RegistrationRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
        public string EmailConfirm { get; set; }


        public void Validate()
        {
            ValidationHelper.ValidateSequence(
                () =>
                {
                    if (Password != PasswordConfirm)
                        throw new ValidationException("Passwords are different");
                },
                () =>
                {
                    if (Email != EmailConfirm)
                        throw new ValidationException("Emails are different");
                }
                );
        }
    }
}
