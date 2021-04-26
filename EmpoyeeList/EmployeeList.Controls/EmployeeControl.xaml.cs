using EmplyeeList.Data;
using System;
using System.Linq;
using System.Windows.Controls;

namespace EmployeeList.Controls
{
	/// <summary>
	/// Логика взаимодействия для EmployeeControl.xaml
	/// </summary>
	public partial class EmployeeControl : UserControl
	{
		Employee employee;
		public EmployeeControl()
		{
			InitializeComponent();
			cbDepartment.ItemsSource = Enum.GetValues(typeof(Departments)).Cast<Departments>();
			cbShedule.ItemsSource = Enum.GetValues(typeof(Shedule)).Cast<Shedule>();
		}

		public void SetEmployeeData(Employee employee)
		{
			this.employee = employee;

			tbFirstName.Text = employee.FirstName;
			tbSecondName.Text = employee.SecondName;
			tbLastName.Text = employee.LastName;
			tbAge.Text = employee.Age.ToString();
			cbDepartment.SelectedItem = employee.Department;
			cbShedule.SelectedItem = employee.Shedule;
		}

		public Employee UpdateEmployeeData()
		{
			employee.FirstName = tbFirstName.Text;
			employee.SecondName = tbSecondName.Text;
			employee.LastName = tbLastName.Text;
			employee.Age = int.Parse(tbAge.Text);
			employee.Department = (Departments)cbDepartment.SelectedItem;
			employee.Shedule = (Shedule)cbShedule.SelectedItem;
			
			return employee;
		}
	}
}
