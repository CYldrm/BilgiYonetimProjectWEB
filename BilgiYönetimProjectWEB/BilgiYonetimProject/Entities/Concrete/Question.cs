using Core.Entities;


namespace Entities.Concrete
{
    public class Question:IEntity
    {
        public int QuestionId { get; set; }
        public int? QuestionGroupId { get; set; }
        public string? QuestionName { get; set; }
        public string? QuestionDescription { get; set; }
        public decimal? QuestionWeight { get; set; }
        public bool? QuestionIsMandatory { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
    }
}
 