using Core.Entities;


namespace Entities.Concrete
{
    public class Process:IEntity
    {
        public int ProcessId { get; set; }
        public string? ProcessName { get; set; }
        public string? ProcessDescription { get; set; }
        public bool? ProcessStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
    }
}