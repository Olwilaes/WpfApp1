using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class VariablesViewModel : ViewModelBase
    {
        public ObservableCollection<Variable> Variables { get; set; } = new();

        private string _toAddVariableName = string.Empty;

        public string ToAddVariableName
        {
            get { return _toAddVariableName; }
            set { _toAddVariableName = value; OnPropertyChanged(nameof(ToAddVariableName)); }
        }

        private string _toAddVariableValue = string.Empty;

        public string ToAddVariableValue
        {
            get => _toAddVariableValue;
            set
            {
                _toAddVariableValue = value;
                OnPropertyChanged(nameof(ToAddVariableValue));
            }
        }

        public ObservableCollection<Type> ToAddVariableType { get; set; } = new() { typeof(string), typeof(int) };

        private Type _toAddSelectedVariableType = typeof(string);

        public Type ToAddSelectedVariableType
        {
            get { return _toAddSelectedVariableType; }
            set { _toAddSelectedVariableType = value; OnPropertyChanged(nameof(ToAddSelectedVariableType)); }
        }

        public ICommand AddVariableCommand { get; }

        private void AddVariableToStore()
        {
            object value = Convert.ChangeType(
                ToAddVariableValue,
                ToAddSelectedVariableType
            );
            Variables.Add(new Variable(ToAddVariableName, ToAddSelectedVariableType, value));
        }



        public VariablesViewModel()
        {
            AddVariableCommand = new RelayCommand(AddVariableToStore);
        }
    }
}
