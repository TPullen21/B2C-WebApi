using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Claim = B2C_WebApi.Models.Claim;

namespace B2C_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    [Authorize]
    public class UserController : Controller
    {
        // GET: api/User
        [HttpGet]
        public string Get()
        {
            var userClaims = User.Claims;
            List<Claim> claims = new List<Claim>();
            foreach (var userClaim in userClaims)
            {
                claims.Add(new Claim
                {
                    name = userClaim.Type,
                    value = userClaim.Value
                });
            }
            var claimsJson = Newtonsoft.Json.JsonConvert.SerializeObject(claims);
            return claimsJson;
        }
    }
}
