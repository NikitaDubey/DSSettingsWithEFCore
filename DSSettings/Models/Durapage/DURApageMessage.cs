using DSSettings.Models.UserPermission;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DSSettings.Models.durapage
{
    public class DURApageMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

    }
}
