using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pitang.Sms.Treino.Entities
{
    public class Message : BaseEntity
    {
        [Required]
        public Chat SourceChat { get; set; }
        public DateTime Date { get; set; }
        public string UserMessage { get; set; }
        public short MessageStatusSource { get; set; }
        public short MessageStatusTarget { get; set; }

    }
}
