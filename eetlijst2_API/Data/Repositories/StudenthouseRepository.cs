using System.Collections.Generic;
using Data.Interfaces;
using Model;

namespace Data.Repositories
{
    public class StudenthouseRepository : IStudenthouseContext
    {
        readonly IStudenthouseContext _studenthuisContext;

        public StudenthouseRepository(IStudenthouseContext studentenhousecontext)
        {
            _studenthuisContext = studentenhousecontext;
        }
        
        public List<StudentHouse> GetallStudenthouses()
        {
            return _studenthuisContext.GetallStudenthouses();
        }

        public StudentHouse GetAllResedens(int studenthuisId)
        {
            return _studenthuisContext.GetAllResedens(studenthuisId);
        }

        public List<ResidentCredit> AllActiveStudentCredits(int studenthouseID)
        {
            return _studenthuisContext.AllActiveStudentCredits(studenthouseID);
        }

        public QueryFeedback AddResident(int userID, int studenthouseID)
        {
            return _studenthuisContext.AddResident(userID, studenthouseID);
        }

        public bool DeleteResident(User user)
        {
            return _studenthuisContext.DeleteResident(user);
        }

        public StudentHouse GetCurrentStudenthouse(int userID)
        {
            return _studenthuisContext.GetCurrentStudenthouse(userID);
        }

        public QueryFeedback MakeNewStudententhouse(string nameNewStudenthouse)
        {
            return _studenthuisContext.MakeNewStudententhouse(nameNewStudenthouse);
        }

        public List<Activity> GetListAtivityStudenthouse(int studenthouseID)
        {
            return _studenthuisContext.GetListAtivityStudenthouse(studenthouseID);
        }

        public Question GetQuestionStudenthouse(int studenthouseID)
        {
            return _studenthuisContext.GetQuestionStudenthouse(studenthouseID);
        }

        public QueryFeedback AddQuestionWithStudenthouse(int studenthouseID, Question theQuestion)
        {
            return _studenthuisContext.AddQuestionWithStudenthouse(studenthouseID, theQuestion);
        }

        public StudentHouse GetStudenthouseIDFromStudenthouseName(string studenthouseName)
        {
            return _studenthuisContext.GetStudenthouseIDFromStudenthouseName(studenthouseName);
        }

        public QueryFeedback CheckAnswer(int studetnhouseID, string theAnswer)
        {
            return _studenthuisContext.CheckAnswer(studetnhouseID, theAnswer);
        }

        public ResidentCredit CheckCredits(int studenthouseID, int currentUserID)
        {
            return _studenthuisContext.CheckCredits(studenthouseID, currentUserID);
        }

        public QueryFeedback UnsubscrbeStudenthouse(int studenthouseID, int userID)
        {
            return _studenthuisContext.UnsubscrbeStudenthouse(studenthouseID, userID);
        }
    }
}