using CSB.Business.Interfaces;
using CSB.GUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSB.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEmployeeService _employeeService;

        public MainWindow(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            var vm = new MainEmployeeViewModel(_employeeService);
            DataContext = vm;
        }

        #region old
        //public void LoadAll()
        //{
        //    var employee = _employeeService.GetById(1);
        //    lblFName.Content = employee.FirstName;
        //    lblLName.Content = employee.LastName;
        //    lblGender.Content = employee.Gender.ToString();
        //    lblDateOfBirth.Content = employee.DateOfBirth.ToString("dd.MM.yyyy");
        //    lblEmail.Content = employee.Email;
        //    //await Task.Delay(10000);
        //    Task.Delay(5000)
        //        .ContinueWith(_ =>
        //        {
        //            this.Dispatcher.Invoke(() =>
        //            {
        //                lblFName.Content = "firstname";
        //            });
        //        });//.GetAwaiter().GetResult();
        //}

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadAll();
        //}

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("CLICKED");
        //}
        #endregion
    }
}
