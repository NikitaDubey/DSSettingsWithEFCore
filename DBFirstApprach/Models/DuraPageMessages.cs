using System;
using System.Collections.Generic;

namespace DBFirstApprach.Models
{
    public partial class DuraPageMessages
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
