using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UserManager userManager = new UserManager(new EfUserDal ());
            Console.WriteLine(userManager.GetById(1).Data.UserName);
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.CreateDate); 
            }
        }
        private static void SurveyDetail()
        {
            SurveyManager surveyManager = new SurveyManager(new EfSurveyDal());
            Console.WriteLine(surveyManager.GetById(1).Data.SurveyId);
            var result = surveyManager.GetSurveyDetails();
            if (result.Success)
            {
                foreach (var survey in surveyManager.GetSurveyDetails().Data)
                {
                    Console.WriteLine("Survey ID: " + survey.SurveyId, "\nSoru Grup Name: " + survey.QuestionGroupName + "\nProcess Aciklama: " + survey.ProcessDescription +
                                        "Process Name: " + survey.ProcessName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}