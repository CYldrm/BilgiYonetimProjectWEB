using Core.Entities;


namespace Entities.Concrete
{
    public class Survey:IEntity
    {
        public int SurveyId { get; set; }
        public int? ProcessId { get; set; }
        public int? DealerId { get; set; }

        public int? QuestionGroupId { get; set; }
        public string? AuditorName { get; set; }
        public DateTime? SurveyDate { get; set; }
        public decimal? SurveyScore { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }

    }
}
 