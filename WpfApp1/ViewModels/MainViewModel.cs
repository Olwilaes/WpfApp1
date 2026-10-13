using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public LogMessagesViewModel LogMessagesViewModel { get; set; }
        public MethodsViewModel MethodsViewModel { get; set; }
        public VariablesViewModel VariablesViewModel { get; set; }
        private RepositoryReaderService repositoryReaderService { get; set; }
        private LogService logService { get; set; }
        public MainViewModel()
        {
            logService = new LogService();
            repositoryReaderService = new RepositoryReaderService(logService);
            MethodsViewModel = new MethodsViewModel(repositoryReaderService);
            LogMessagesViewModel = new LogMessagesViewModel(logService);
            VariablesViewModel = new VariablesViewModel();
            InvokeMethodCommand = new RelayCommand(InvokeMethod);
        }

        public ICommand InvokeMethodCommand { get; set; }

        public void InvokeMethod()
        {
            var selectedMethod = MethodsViewModel.Methods.Where(v => v.IsSelected).First();
            var selectedVariables = VariablesViewModel.Variables.Where(v => v.IsSelected).ToList();

            var parameters = selectedMethod.MethodInfo.GetParameters();

            if (parameters.Length != selectedVariables.Count)
            {
                logService.Log("Parameter count didn't match.");
                return;
            }

            var convertedVariables = selectedVariables
                .Select((v, i) => Convert.ChangeType(v.Value, parameters[i].ParameterType));

            object[] selectedvariablesArray = convertedVariables.ToArray();

            var result = selectedMethod.MethodInfo.Invoke(Activator.CreateInstance(selectedMethod.MethodInfo.DeclaringType), selectedvariablesArray);

            VariablesViewModel.Variables.Add(new Models.Variable(MethodsViewModel.ResultVariableName, result.GetType(), result));

            logService.Log($"Variable with name {MethodsViewModel.ResultVariableName} and type {result.GetType} added.");
        }
        
    }
}
