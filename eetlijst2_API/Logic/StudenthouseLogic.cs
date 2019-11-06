using System;
using System.Collections.Generic;
using Data;
using Data.Repositories;
using Model;

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

        public bool DeleteResident(Account user)
        {
            return _studenthouseRepository.DeleteResident(user);
        }

        public List<Activaty> GetActivatysStudenthouse(int studenthouseID)
        {
            return _studenthouseRepository.GetListAtivityStudenthouse(studenthouseID);
        }

        public Studenthouse GetallResidents(int studenthouseID)
        {
            return _studenthouseRepository.GetAllResedens(studenthouseID);
        }

        public List<Studenthouse> GetallStudenthouses()
        {
            return _studenthouseRepository.GetallStudenthouses();
        }

        public Studenthouse GetCurrentStudenthouse(int UserID)
        {
            return _studenthouseRepository.GetCurrentStudenthouse(UserID);
        }

        public Question GetQuestionStudenthouse(int studenthouseID)
        {
            return _studenthouseRepository.GetQuestionStudenthouse(studenthouseID);
        }

        public Studenthouse GetStudenthouseIDFromStudenthouseName(string StudenthouseN)
        {
            return _studenthouseRepository.GetStudenthouseIDFromStudenthouseName(StudenthouseN);
        }

        public QueryFeedback MakeNewStudenthouse(string NameNewStudenthouse)
        {
            return _studenthouseRepository.MakeNewStudententhouse(NameNewStudenthouse);
        }

        public List<Credits> AllActiveStudentCredits(int studenthouseID)
        {
            return _studenthouseRepository.AllActiveStudentCredits(studenthouseID);
        }

        public QueryFeedback UnsubscibeStudenthouse(int studenthouseID, int CurrentUser)
        {
            QueryFeedback feedback = new QueryFeedback();
            Credits residentCredit = _studenthouseRepository.CheckCredits(studenthouseID, CurrentUser);

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
