using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class CarModel : IEntity
    {
        public int CarModelId { get; set; }
        public int? BrandId { get; set; } // Foreign key to Brand
        public string? CarModelName { get; set; }
        public string? CarModelFuelType { get; set; }
        public string? CarModelEngineCapacity { get; set; }
        public string? CarModelPower { get; set; }
        public decimal? CarModelPrice { get; set; }
        public string? CarModelDescription { get; set; }
    }
}
