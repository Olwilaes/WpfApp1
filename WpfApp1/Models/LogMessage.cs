using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Models
{
    public class LogMessage
    {
        public LogMessage(string message)
        {
            Message = message;
            TimeStamp = DateTime.Now;
        }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
    }
}
