using CSB.Business.Interfaces;
using CSB.Business.Models;
using CSB.GUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSB.GUI.ViewModels
{
    public class MainEmployeeViewModel : INotifyPropertyChanged
    {
        private List<GetEmployeeDto> employees;
        private readonly IEmployeeService _employeeService;

        public MainEmployeeViewModel(
            IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            GetEmployeesCommand = new GetEmployeesCommand(_employeeService, this);
        }

        public ICommand GetEmployeesCommand { get; private set; }

        public List<GetEmployeeDto> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
