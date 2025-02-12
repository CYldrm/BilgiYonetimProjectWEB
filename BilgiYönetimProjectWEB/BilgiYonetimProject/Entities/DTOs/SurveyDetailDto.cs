
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SurveyDetailDto:IDto
    {
        public int SurveyId { get; set; }
        public int? ProcessId { get; set; }
        public string? ProcessName { get; set; }
        public string? ProcessDescription { get; set; }
        public bool? ProcessStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUser { get; set; }
        public int? QuestionGroupId { get; set; }
        public int? QuestionProcessId { get; set; }
        public string? QuestionGroupName { get; set; }
        public string? QuestionGroupDescription { get; set; }
        public bool? QuestionIsDefault { get; set; }
        public string? AuditorName { get; set; }
        public DateTime? SurveyDate { get; set; }
        public decimal? SurveyScore { get; set; }
    }
}
