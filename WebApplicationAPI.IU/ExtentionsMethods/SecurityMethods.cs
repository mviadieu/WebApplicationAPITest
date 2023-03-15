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
        services.AddCors(option =>
        {
            option.AddPolicy( DEFAULT_POLICY, builder =>
            {
                builder
                    .WithOrigins(configuration["Cors:OriginClient"])
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
                    .WithOrigins(configuration["Cors:OriginClient"])
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