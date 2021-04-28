using EmplyeeList.Data;
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
using System.Windows.Shapes;

namespace EmployeeList.App
{
	/// <summary>
	/// Логика взаимодействия для AddWindow.xaml
	/// </summary>
	public partial class AddWindow : Window
	{
		public Employee Employee { get; private set; }
		public AddWindow()
		{
			InitializeComponent();
			employeeControlAW.SetEmployeeData(new Employee());
		}

		private void btnAWAdd_Click(object sender, RoutedEventArgs e)
		{
			Employee = employeeControlAW.UpdateEmployeeData();
			DialogResult = true;
		}
	}
}
