using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Admin : IEntity
    {
        public int AdminId { get; set; }
        public string? AdminName { get; set; }
        public string? AdminSurname { get; set; }
        public string? AdminMail { get; set; }
        public string? AdminPassword { get; set; }
        public DateTime AdminDatetime { get; set; }
    }
}
