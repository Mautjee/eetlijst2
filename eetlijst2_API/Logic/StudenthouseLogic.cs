using System;
using System.Collections.Generic;
using Model.ModelOld;
using Data;
using Data.Repositories;

namespace Logic
{
    public class StudenthouseLogic : IStudenthouseLogic
    {
        private StudenthouseRepository _studenthouseRepository;
        
        public StudenthouseLogic(StudenthouseRepository studenthouseRepository)
        {
            _studenthouseRepository = studenthouseRepository;
        }

        public QueryFeedback AddQuestionStudenthouse(int studenthouseID, Question question)
        {
            return _studenthouseRepository.AddQuestionWithStudenthouse(studenthouseID, question);
        }

        public QueryFeedback AddResident(int userID, int studenthouseID)
        {
            return _studenthouseRepository.AddResident(userID, studenthouseID);
        }

        public QueryFeedback CheckAnswer(int studenthouseID, string TheAnswer)
        {
            return _studenthouseRepository.CheckAnswer(studenthouseID, TheAnswer);
        }

        public bool DeleteResident(User user)
        {
            return _studenthouseRepository.DeleteResident(user);
        }

        public List<Activity> GetActivatysStudenthouse(int studenthouseID)
        {
            return _studenthouseRepository.GetListAtivityStudenthouse(studenthouseID);
        }

        public StudentHouse GetallResidents(int studenthouseID)
        {
            return _studenthouseRepository.GetAllResedens(studenthouseID);
        }

        public List<StudentHouse> GetallStudenthouses()
        {
            return _studenthouseRepository.GetallStudenthouses();
        }

        public StudentHouse GetCurrentStudenthouse(int UserID)
        {
            return _studenthouseRepository.GetCurrentStudenthouse(UserID);
        }

        public Question GetQuestionStudenthouse(int studenthouseID)
        {
            return _studenthouseRepository.GetQuestionStudenthouse(studenthouseID);
        }

        public StudentHouse GetStudenthouseIDFromStudenthouseName(string StudenthouseN)
        {
            return _studenthouseRepository.GetStudenthouseIDFromStudenthouseName(StudenthouseN);
        }

        public QueryFeedback MakeNewStudenthouse(string NameNewStudenthouse)
        {
            return _studenthouseRepository.MakeNewStudententhouse(NameNewStudenthouse);
        }

        public List<ResidentCredit> AllActiveStudentCredits(int studenthouseID)
        {
            return _studenthouseRepository.AllActiveStudentCredits(studenthouseID);
        }

        public QueryFeedback UnsubscibeStudenthouse(int studenthouseID, int CurrentUser)
        {
            QueryFeedback feedback = new QueryFeedback();
            ResidentCredit residentCredit = _studenthouseRepository.CheckCredits(studenthouseID, CurrentUser);

            if(residentCredit != null)
            {
                if(residentCredit.Credit >= 0)
                {
                    QueryFeedback unsubscibe = _studenthouseRepository.UnsubscrbeStudenthouse(studenthouseID, CurrentUser);
                    if (unsubscibe.Succes)
                    {
                        feedback.Succes = true;
                        return feedback;
                    }
                    else
                    {
                        feedback.Succes = false;
                        feedback.Message = "Something went wrong executing this Query";
                        return feedback;
                    }
                    
                }
                else {
                    feedback.Succes = false;
                    feedback.Message = "You still have a debt";
                    return feedback;
                }
            }
            else
            {
                feedback.Succes = false;
                feedback.Message = "Something went wrong executing this Query";
                return feedback;
            }
        }
    }
}
