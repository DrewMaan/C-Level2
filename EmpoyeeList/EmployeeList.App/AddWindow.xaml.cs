using EmplyeeList.Data;
using System.Windows;

namespace EmployeeList.App
{
	/// <summary>
	/// Логика взаимодействия для AddWindow.xaml
	/// </summary>
	public partial class AddWindow : Window
	{
		public Employee Employee { get; private set; } = new Employee();
		public AddWindow()
		{
			InitializeComponent();
			employeeControlAW.Employee = Employee;
		}

		private void btnAWAdd_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}
	}
}
