using Core.Entities;


namespace Entities.Concrete
{
    public class Answer:IEntity
    {
        public int AnswerId { get; set; }
        public int? AnswerSurveyId { get; set; }
        public int? QuestionGroupId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerChoose { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
    }
}
 