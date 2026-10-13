using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class MethodsViewModel : ViewModelBase
    {
        public ObservableCollection<Method> Methods { get; set; } = new();

        private string _resultVariableName = string.Empty;
        public string ResultVariableName
        {
            get { return _resultVariableName; }
            set { _resultVariableName = value; OnPropertyChanged(nameof(ResultVariableName));  }
        }

        public MethodsViewModel(RepositoryReaderService repositoryReaderService)
        {
            foreach (var method in repositoryReaderService.ReadDirectory())
            {
                Methods.Add(new Method(method.Name, method.ReturnType, method));
            }
        }
    }
}
