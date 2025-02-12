using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Visitor : IEntity
    {
        public int VisitorId { get; set; }
        public int? CarModelId { get; set; } // Foreign key to CarModel
        public string? VisitorName { get; set; }
        public string? VisitorSurname { get; set; }
        public int? VisitorAge { get; set; }
        public string? VisitorMail { get; set; }
        public string? VisitorComment { get; set; }
        public int? VisitorComfort { get; set; }
        public int? VisitorFuelefficiency { get; set; }
        public int? VisitorPricePerformance { get; set; }
        public int? VisitorDesign { get; set; }
        public int? VisitorDurability { get; set; }
        public string? VisitorCode { get; set; }
        public DateTime? VisitorDatetime { get; set; }
    }
}
