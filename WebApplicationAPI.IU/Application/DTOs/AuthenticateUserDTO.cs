namespace WebApplicationAPI.IU.Application.DTOs;

public class AuthenticateUserDTO
{
    #region Properties

    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    #endregion Properties
}