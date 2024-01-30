using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdf.Bll.Models
{
    public class JwtSettings 
    {
        public string SecurityKey { get; set; } = null!;
        public int AccessTokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationMinutes { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string SecurityAlgorithms { get; set; } = null!;
    }
}