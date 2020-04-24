using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.Sms.Treino.Entities
{
    public class Message : BaseEntity
    {
        public int IdSource { get; set; }
        public int IdTarget { get; set; }
        public DateTime Date { get; set; }
        public string UserMessage { get; set; }
        public short MessageStatusSource { get; set; }
        public short MessageStatusTarget { get; set; }

    }
}
