using System.Collections.Generic;
using Model.ModelOld;

namespace Data.Interfaces
{
    public interface IStudenthouseContext
    {
        List<StudentHouse> GetallStudenthouses();
        StudentHouse GetAllResedens(int studenthuisId);
        List<ResidentCredit> AllActiveStudentCredits(int studenthouseID);
        QueryFeedback AddResident(int userID, int studenthouseID);
        bool DeleteResident(User user);
        StudentHouse GetCurrentStudenthouse(int userID);
        QueryFeedback MakeNewStudententhouse(string nameNewStudenthouse);
        List<Activity> GetListAtivityStudenthouse(int studenthouseID);
        Question GetQuestionStudenthouse(int studenthouseID);
        QueryFeedback AddQuestionWithStudenthouse(int studenthouseID, Question theQuestion);
        StudentHouse GetStudenthouseIDFromStudenthouseName(string studenthouseName);
        QueryFeedback CheckAnswer(int studetnhouseID, string theAnswer);
        ResidentCredit CheckCredits(int studenthouseID,int currentUserID);
        QueryFeedback UnsubscrbeStudenthouse(int studenthouseID, int userID);
    }
}