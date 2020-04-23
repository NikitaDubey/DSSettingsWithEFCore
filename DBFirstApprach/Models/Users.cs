using System;
using System.Collections.Generic;

namespace DBFirstApprach.Models
{
    public partial class Users
    {
        public Users()
        {
            DuraPageMessages = new HashSet<DuraPageMessages>();
        }

        public int Id { get; set; }
        public string Encryption { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Realm { get; set; }
        public bool AllowAuthOffline { get; set; }
        public bool IsAdministrator { get; set; }

        public virtual ICollection<DuraPageMessages> DuraPageMessages { get; set; }
    }
}
