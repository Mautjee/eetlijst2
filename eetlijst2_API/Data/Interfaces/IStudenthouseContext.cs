using System.Collections.Generic;
using Model;

namespace Data.Interfaces
{
    public interface IStudenthouseContext
    {
        List<Studenthouse> GetallStudenthouses();
        Studenthouse GetAllResedens(int studenthuisId);
        List<Credits> AllActiveStudentCredits(int studenthouseID);
        QueryFeedback AddResident(int userID, int studenthouseID);
        bool DeleteResident(Account user);
        Studenthouse GetCurrentStudenthouse(int userID);
        QueryFeedback MakeNewStudententhouse(string nameNewStudenthouse);
        List<Activaty> GetListAtivityStudenthouse(int studenthouseID);
        Question GetQuestionStudenthouse(int studenthouseID);
        QueryFeedback AddQuestionWithStudenthouse(int studenthouseID, Question theQuestion);
        Studenthouse GetStudenthouseIDFromStudenthouseName(string studenthouseName);
        QueryFeedback CheckAnswer(int studetnhouseID, string theAnswer);
        Credits CheckCredits(int studenthouseID,int currentUserID);
        QueryFeedback UnsubscrbeStudenthouse(int studenthouseID, int userID);
    }
}