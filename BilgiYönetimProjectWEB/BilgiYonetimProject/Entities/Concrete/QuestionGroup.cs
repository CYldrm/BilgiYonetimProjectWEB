using Core.Entities;


namespace Entities.Concrete
{
    public class QuestionGroup:IEntity
    {
        public int QuestionGroupId { get; set; }
        public int? QuestionProcessId { get; set; }
        public string? QuestionGroupName { get; set; }
        public string? QuestionGroupDescription { get; set; }
        public bool? QuestionIsDefault { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
    }
}
 