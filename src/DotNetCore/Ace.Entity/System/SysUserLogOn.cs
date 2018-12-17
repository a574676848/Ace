using Chloe.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ace.Entity.System
{
    [Table("sys_userlogon")]
    public class SysUserLogOn
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserSecretkey { get; set; }
        public DateTime? PreviousVisitTime { get; set; }
        public DateTime? LastVisitTime { get; set; }
        public int LogOnCount { get; set; }
        public string Token { get; set; }
        public decimal? Expiresin { get; set; }
        public decimal? ExpiresinTime { get; set; }
        public string RefreshToken { get; set; }
    }

}
