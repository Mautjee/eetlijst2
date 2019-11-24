using System;
using System.Collections.Generic;
using System.Linq;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;

namespace Data.Repositories
{
    public class StudenthouseRepository : IStudenthouseContext
    {
        private readonly mauro_sqlContext _mauroContext;
        
        public StudenthouseRepository(mauro_sqlContext mauro_SqlContext)
        {
            _mauroContext = mauro_SqlContext;
        }
        
        public List<Studenthouse> GetallStudenthouses()
        {
            return _mauroContext.Studenthouse.ToList();
        }

        public Studenthouse GetAllResedens(int studenthuisId)
        {
            return new Studenthouse();
        }

        public List<VwActiveStudenthouseAccount> AllActiveStudentCredits(int studenthouseID)
        {
            var view = _mauroContext.VwActiveStudenthouseAccount
                .Where(s => s.StudenthouseId == studenthouseID)
                .ToList();
            
            return view;
        }

        public QueryFeedback AddResident(int userID, int studenthouseID)
        {
            var feedback = new QueryFeedback();
            try
            {
                var accountActivaty = _mauroContext.AccountActivaty.FirstOrDefault(a =>
                    a.AccountId == userID && a.StudenthouseId == 0);

                accountActivaty.StudenthouseId = studenthouseID;
                accountActivaty.In = DateTime.Now;

                var credits = _mauroContext.Credits.FirstOrDefault(c => c.AccountId == userID);

                credits.StudenthouseId = studenthouseID;

                //feedback.Message("Resident is correctly added to the house");

                feedback.Succes = true;
                return feedback;
            }
            catch
            {
                //feedback.Message("Somthing went wron adding the user to the house");
                feedback.Succes = false;
                return feedback;
            }
        }

        public bool DeleteResident(Account user)
        {
            return false;
        }

        public VwActiveStudenthouseAccount GetCurrentStudenthouse(int userID)
        {
            try
            {
                return _mauroContext.VwActiveStudenthouseAccount.FirstOrDefault(s => s.AccountId == userID);


            }
            catch(Exception e)
            {
                return new VwActiveStudenthouseAccount();
            }
        }

        public QueryFeedback MakeNewStudententhouse(string nameNewStudenthouse)
        {
            var feedback = new QueryFeedback();
            try
            {
                var studhouse = new Studenthouse();
                studhouse.Name = nameNewStudenthouse;
                
                _mauroContext.Studenthouse.Add(studhouse);

                _mauroContext.SaveChanges();

                feedback.Succes = true;
                feedback.Message = "Studenthouse is added";
            }
            catch
            {
                feedback.Succes = false;
                feedback.Message = "Somthing went wrong adding this Studenthouse";
            }
            return feedback;
        }

        public List<Activaty> GetListAtivityStudenthouse(int studenthouseID)
        {
            try
            {
                var listActivaty = _mauroContext.Activaty
                    .Where(a => a.StudenthouseId == studenthouseID).ToList();
                return listActivaty;
            }
            catch(Exception e)
            {
                //e.Message();
                return new List<Activaty>();
            }
        }

        public Question GetQuestionStudenthouse(int studenthouseID)
        {
            try
            {
                var question = _mauroContext.Question.FirstOrDefault(q => q.StudenthouseId == studenthouseID);
                return question;
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return new Question();
            }

            
        }

        public QueryFeedback AddQuestionWithStudenthouse(Question theQuestion)
        {
            var feedback = new QueryFeedback();
            try
            {
                
                _mauroContext.Question.Add(theQuestion);

                _mauroContext.SaveChanges();

                feedback.Succes = true;
                feedback.Message = "Question is added";
            }
            catch
            {
                feedback.Succes = false;
                feedback.Message = "Somthing went wrong adding the question";
            }
            return feedback;
        }

        public Studenthouse GetStudenthouseIDFromStudenthouseName(string studenthouseName)
        {
             
            try
            {
                var house = _mauroContext.Studenthouse
                    .FirstOrDefault(s => s.Name == studenthouseName);
                 return house;
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                return new Studenthouse();
            }

            
            
            
        }

        public QueryFeedback CheckAnswer(int studetnhouseID, string theAnswer)
        {
            var feedback = new QueryFeedback();
            try
            {
               
                
                var question =_mauroContext.Question
                    .FirstOrDefault(q => q.StudenthouseId == studetnhouseID && q.Answer == theAnswer);

                if (question != null)
                {
                    feedback.Succes = true;
                    feedback.Message = "Answer is correct";
                }
                else
                {
                    feedback.Succes = false;
                    feedback.Message = "Wrong answer";
                }
               
              
                

              
            }
            catch
            {
                feedback.Succes = false;
                feedback.Message = "Somthing went wrong Checking the answer";
            }
            return feedback;
        }

        public Credits CheckCredits(int studenthouseID, int currentUserID)
        {
           
            try
            {

                var credits =_mauroContext.Credits
                    .FirstOrDefault(c => c.StudenthouseId == studenthouseID && c.AccountId == currentUserID);
                return credits;

            }
            catch
            {
                return new Credits();
            }
        }

        public QueryFeedback UnsubscrbeStudenthouse(int studenthouseID, int userID)
        {
            var feedback = new QueryFeedback();
            try
            {
                var credits =
                    _mauroContext.Credits.FirstOrDefault(c =>
                        c.AccountId == userID && c.StudenthouseId == studenthouseID);

                credits.StudenthouseId = 0;
                credits.Credit = 0;

                var accountActivaty = _mauroContext.AccountActivaty.FirstOrDefault(a =>
                    a.StudenthouseId == studenthouseID && a.AccountId == userID);

                accountActivaty.Out = DateTime.Now;

                var newAccount = new AccountActivaty();

                newAccount.AccountId = userID;
                newAccount.In = DateTime.Now;
                newAccount.StudenthouseId = 0;

                _mauroContext.AccountActivaty.Add(newAccount);
                
                _mauroContext.SaveChanges();
                
            }
            catch(Exception e)
            {

                feedback.Succes = false;
                return new QueryFeedback();
            }
            
            
            feedback.Succes = true;
            return feedback;

        }
    }
}