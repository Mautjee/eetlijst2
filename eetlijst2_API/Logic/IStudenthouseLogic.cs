using System;
using System.Collections.Generic;
using Model;

namespace Logic
{
    public interface IStudenthouseLogic
    {
        List<Studenthouse> GetallStudenthouses();
        Studenthouse GetallResidents(int studenthouseID);

        QueryFeedback AddResident(int userID, int studenthouseID);
        bool DeleteResident(Account user);
        QueryFeedback UnsubscibeStudenthouse(int studenthouseID, int CurrentUser);

        Studenthouse GetCurrentStudenthouse(int UserID);
        List<Credits> AllActiveStudentCredits(int studenthouseID);

        QueryFeedback MakeNewStudenthouse(string NameNewStudenthouse);
        List<Activaty> GetActivatysStudenthouse(int studenthouseID);

        Question GetQuestionStudenthouse(int studenthouseID);
        QueryFeedback AddQuestionStudenthouse(int studenthouseID, Question question);
        QueryFeedback CheckAnswer(int studenthouseID, string TheAnswer);

        Studenthouse GetStudenthouseIDFromStudenthouseName(string StudenthouseN);
            
    }
}
