using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class LogService
    {
        public ObservableCollection<LogMessage> LogMessages { get; set; } = new();

        public void Log(string message)
        {
            LogMessages.Add(new LogMessage(message));
        }
    }
}
