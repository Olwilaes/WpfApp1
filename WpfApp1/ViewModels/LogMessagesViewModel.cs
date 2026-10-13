using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class LogMessagesViewModel
    {
        private readonly LogService _logService;

        public ObservableCollection<LogMessage> LogMessages
        {
            get
            {
                return _logService.LogMessages;
            }
        }
        public LogMessagesViewModel(LogService logService)
        {
            _logService = logService;
            logService.Log("Ich bin die erste LogMessage.");
        }
    }
}
