using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Infrastructure.Identity.Models
{
    public class PlatformRole : IdentityRole
    {
        public PlatformRole(string roleName) : base(roleName) { }
        public PlatformRole() : base() { }
    }

}
