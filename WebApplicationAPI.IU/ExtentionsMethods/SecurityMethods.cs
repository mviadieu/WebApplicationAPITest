using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplicationAPICore.Recipies.Infrastructure.Configuration;

namespace WebApplicationAPI.IU.ExtentionsMethods;

/// <summary>
/// About security (CORS + JWT)
/// </summary>
public static class SecurityMethods
{
    #region constants
    /// <summary>
    /// Avoir plusieurs POLICY permet de bloquer certaines partie de l'API au client. Voir controller pour param.
    /// </summary>
    public const string DEFAULT_POLICY = "DEFAULT_POLICY";
    public const string DEFAULT_POLICY_2 = "DEFAULT_POLICY_2"; 

    
    #endregion constants
    
    #region public methods
    /// <summary>
    /// configure CORS options for Angular frontend
    /// </summary>
    /// <param name="services"></param>
    
    public static void AddCustomSecurity( this IServiceCollection services , IConfiguration configuration)
    {
        services.AddCustomCors(configuration);
        services.AddCustomAuthentification(configuration);
    }
    
    
    public static void AddCustomAuthentification( this IServiceCollection services , IConfiguration configuration)
    {
        SecurityOption securityOption = new SecurityOption();
        configuration.GetSection("Jwt").Bind(securityOption); // on va chercher dans le app seting la section qui correspond a Cors. Evite de note en dur le json
        
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            string myKey = securityOption.Key; 
            option.SaveToken = true;
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateLifetime = true, // POUR METTRE UN JETON QUI A UNE DUREE DE VIE ++ SECURITY
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(myKey)) // ON ATTRIBUE UNE CLEF. C'EST LA CLEF QUI PERMET DE COMMUNIQUER ENTRE CLIENT ET SERVEUR. 
            };
        });
    }
    public static void AddCustomCors( this IServiceCollection services , IConfiguration configuration)
    {
        CorsOption corsOption = new CorsOption();
        configuration.GetSection("Cors").Bind(corsOption); // on va chercher dans le app seting la section qui correspond a Cors. Evite de note en dur le json : .WithOrigins(configuration["Cors:OriginClient"])
        
        services.AddCors(option =>
        {
            option.AddPolicy( DEFAULT_POLICY, builder =>
            {
                builder
                    // .WithOrigins(configuration["Cors:OriginClient"])
                    .WithOrigins(corsOption.OriginClient) // plus propre
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
            });
        });
        services.AddCors(option =>
        {
            option.AddPolicy( DEFAULT_POLICY_2, builder =>
            {
                builder
                    .WithOrigins(corsOption.OriginClient)
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithMethods("GET","PUT", "POST", "DELETE", "OPTIONS")
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
            });
        });
    }
    
    #endregion public methods
}