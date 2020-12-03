using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public DateTime LastLoginDate { get; set; }
        public DateTime CreateDate { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
