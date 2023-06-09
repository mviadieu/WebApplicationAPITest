using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.IU.Application.DTOs;
using WebApplicationAPI.IU.Application.JWT;
using WebApplicationAPI.IU.ExtentionsMethods;
using WebApplicationAPICore.Recipies.Domain;
using WebApplicationAPICore.Recipies.Infrastructure.Datas;

namespace WebApplicationAPI.IU.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    #region fields
    
    private UserManager<IdentityUser> _userManager = null;
    private readonly IWebHostEnvironment _cWebHostEnvironment = null;
    private IConfiguration _configuration = null;
    private ILogger<AuthenticateController> _logger = null;
    
    #endregion fields
    
    #region constructors
    public AuthenticateController(ILogger<AuthenticateController> logger, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        this._userManager = userManager;
        this._cWebHostEnvironment = webHostEnvironment;
        this._configuration = configuration;
        this._logger = logger;
    }
    
    #endregion constructors
    
    #region public methods
    
    [HttpPost(Name = "Register")]
    [EnableCors(SecurityMethods.DEFAULT_POLICY_2)]
    public async Task<IActionResult> Register([FromBody]AuthenticateUserDTO dtoUser)
    {
        IActionResult result = BadRequest();
        var user = new IdentityUser(dtoUser.Login);
        user.Email = dtoUser.Login;
        user.NormalizedUserName = dtoUser.Name;
        var success = await this._userManager.CreateAsync(user, dtoUser.Password); // success renvoit ici un identity result
        
        if(success.Succeeded) // Gestion des erreurs 
        {
            dtoUser.Token = GenerateToken.GenerateJwtToken(user, _configuration);
            result = this.Ok(dtoUser);
        } 
        
        
        return result;
    }
    
    
    [HttpPost(Name = "Login")]
    public async Task<IActionResult> Login([FromBody]AuthenticateUserDTO dtoUser)
    {
        IActionResult result = BadRequest();
        var user = await this._userManager.FindByEmailAsync(dtoUser.Login);
        if (user != null)
        {
            var accountVerification = await this._userManager.CheckPasswordAsync(user, dtoUser.Password);
            if (accountVerification)
            {
                result = this.Ok(new AuthenticateUserDTO()
                {
                    Login = user.Email,
                    Name = user.UserName,
                    Token = GenerateToken.GenerateJwtToken(user, _configuration)
                });
                
                this._logger.LogDebug("Your login is successfull");
            }
        }
        return result;
    }
    
    #endregion public methods
    

    
}

