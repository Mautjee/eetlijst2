using System.Collections.Generic;
using Data.Interfaces;
using Model.ModelOld;

namespace Data.Contexts
{
    public class StudenthouseMemoryContext : IStudenthouseContext
    {
        private List<StudentHouse> studenthouses = new List<StudentHouse>();
        private int studenthouseID = 1;
        private User defaultUser = new User();
        
        public StudenthouseMemoryContext()
        {
            List<User> listOfResidents = new List<User>();

            if (studenthouses.Count == 0)
            {
                studenthouses.Add(new StudentHouse() {StudenthouseId = studenthouseID++, Name = "HV NIOS", Residents = listOfResidents });
                studenthouses.Add(new StudentHouse() { StudenthouseId = studenthouseID++, Name = "Asome Huis" });
            }
           
        }
        
        public List<StudentHouse> GetallStudenthouses()
        {
            throw new System.NotImplementedException();
        }

        public StudentHouse GetAllResedens(int studenthuisId)
        {
            throw new System.NotImplementedException();
        }

        public List<ResidentCredit> AllActiveStudentCredits(int studenthouseID)
        {
            throw new System.NotImplementedException();
        }

        public QueryFeedback AddResident(int userID, int studenthouseID)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteResident(User user)
        {
            throw new System.NotImplementedException();
        }

        public StudentHouse GetCurrentStudenthouse(int userID)
        {
            throw new System.NotImplementedException();
        }

        public QueryFeedback MakeNewStudententhouse(string nameNewStudenthouse)
        {
            throw new System.NotImplementedException();
        }

        public List<Activity> GetListAtivityStudenthouse(int studenthouseID)
        {
            throw new System.NotImplementedException();
        }

        public Question GetQuestionStudenthouse(int studenthouseID)
        {
            throw new System.NotImplementedException();
        }

        public QueryFeedback AddQuestionWithStudenthouse(int studenthouseID, Question theQuestion)
        {
            throw new System.NotImplementedException();
        }

        public StudentHouse GetStudenthouseIDFromStudenthouseName(string studenthouseName)
        {
            throw new System.NotImplementedException();
        }

        public QueryFeedback CheckAnswer(int studetnhouseID, string theAnswer)
        {
            throw new System.NotImplementedException();
        }

        public ResidentCredit CheckCredits(int studenthouseID, int currentUserID)
        {
            throw new System.NotImplementedException();
        }

        public QueryFeedback UnsubscrbeStudenthouse(int studenthouseID, int userID)
        {
            throw new System.NotImplementedException();
        }
    }
}