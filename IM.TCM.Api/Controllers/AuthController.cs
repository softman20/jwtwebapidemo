using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Exceptionless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace IM.TCM.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        [HttpPost("token")]
        public IActionResult Index()
        {
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic")){

                var credvalue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credvalue));
                var usernameAndPass = usernameAndPassenc.Split(":");
                if (usernameAndPass[0] == "admin" && usernameAndPass[1] == "pass")
                {
                    var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]) };
                    string secretKey = "HilelHilelHilelHilelHilelHilelHilelHilelHilelHilel";
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                    var signincred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                    var token = new JwtSecurityToken(
                        issuer: "hilel.com",
                        audience: "hilel.com",
                        expires: DateTime.Now.AddMinutes(100),
                        claims: claimsdata,
                        signingCredentials: signincred);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    ExceptionlessClient.Default.SubmitLog("log");
                    ExceptionlessClient.Default.SubmitLog("source","log");
                    ExceptionlessClient.Default.SubmitLog("log warning", Exceptionless.Logging.LogLevel.Warn);


                   // throw new NullReferenceException();
                    _logger.LogDebug("Debug Token was generated for ");
                    _logger.LogError("Error no error while generating token");
                    _logger.LogInformation("information no error while generating token");
                    _logger.LogWarning("warning no error while generating token");
                    _logger.LogTrace("trace no error while generating token");
                    ExceptionlessClient.Default.CreateLog("token").SetProperty("JSON", token).SetUserIdentity("H7707132").Submit();
                    ExceptionlessClient.Default.CreateLog("tokenString").SetProperty("JSON", tokenString).Submit();
                    return Ok(tokenString);
                }
            } 
                return Unauthorized();
            
        }
    }
}