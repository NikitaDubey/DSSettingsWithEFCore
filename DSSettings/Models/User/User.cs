using DSSettings.Models.durapage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSSettings.Models.UserPermission
{
    public class User
    {
		public User()
		{
			DuraPageMessages = new List<DURApageMessage>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Encryption { get; set; }

		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }

		public string Realm { get; set; }

		public Boolean AllowAuthOffline { get; set; }

		public Boolean IsAdministrator { get; set; }

		public virtual ICollection<DURApageMessage> DuraPageMessages { get; set; }

	}
}
