using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class DealerPoint : IEntity
    {
        public int DealerPointId { get; set; }
        public int? DealerId { get; set; } // Foreign key to Dealer
        public int? UserId { get; set; } // Foreign key to User
        public int? Point { get; set; }
        public string? DealerPointCode { get; set; }
    }
}
