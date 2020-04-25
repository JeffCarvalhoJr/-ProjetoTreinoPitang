using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitang.Sms.Treino.Entities
{
    public class Story : BaseEntity
    {
        public string UserMessage { get; set; }

        [Required]
        public int IdOwner { get; set; }
        public DateTime PostDate { get; set; }
        public short Type { get; set; }
    }
}
