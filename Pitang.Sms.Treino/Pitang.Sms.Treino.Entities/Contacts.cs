using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitang.Sms.Treino.Entities
{
    public class Contacts : BaseEntity
    {
        [Required]
        public virtual UserModel Owner { get; set; }

        public virtual ICollection<UserModel> ContactBook { get; set; }
    }
}
