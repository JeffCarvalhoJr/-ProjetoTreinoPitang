using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitang.Sms.Treino.Entities
{
    public class Chat : BaseEntity
    {
        [Required]
        public virtual ICollection<UserModel> Users { get; set; }
        
        public ICollection<Message>Messages { get; set; }

    }
}
