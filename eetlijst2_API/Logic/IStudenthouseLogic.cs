using System;
using System.Collections.Generic;
using Model.ModelOld;
namespace Logic
{
    public interface IStudenthouseLogic
    {
        List<StudentHouse> GetallStudenthouses();
        StudentHouse GetallResidents(int studenthouseID);

        QueryFeedback AddResident(int userID, int studenthouseID);
        bool DeleteResident(User user);
        QueryFeedback UnsubscibeStudenthouse(int studenthouseID, int CurrentUser);

        StudentHouse GetCurrentStudenthouse(int UserID);
        List<ResidentCredit> AllActiveStudentCredits(int studenthouseID);

        QueryFeedback MakeNewStudenthouse(string NameNewStudenthouse);
        List<Activity> GetActivatysStudenthouse(int studenthouseID);

        Question GetQuestionStudenthouse(int studenthouseID);
        QueryFeedback AddQuestionStudenthouse(int studenthouseID, Question question);
        QueryFeedback CheckAnswer(int studenthouseID, string TheAnswer);

        StudentHouse GetStudenthouseIDFromStudenthouseName(string StudenthouseN);
            
    }
}
