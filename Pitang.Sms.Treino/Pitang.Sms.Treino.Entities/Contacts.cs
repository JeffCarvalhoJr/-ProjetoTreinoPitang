using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.Sms.Treino.Entities
{
    public class Contacts : BaseEntity
    {
        public int IdOwner { get; set; }
        public int IdTarget { get; set; }
    }
}
