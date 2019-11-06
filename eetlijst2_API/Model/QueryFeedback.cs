using System;
namespace Model
{
    public class QueryFeedback
    {

            public bool Succes { get; set; }
            public string Message { get; set; }

            public QueryFeedback(bool succes, string message)
            {
                Succes = succes;
                Message = message;
            }

            public QueryFeedback()
            {

            }
        
    }
}
