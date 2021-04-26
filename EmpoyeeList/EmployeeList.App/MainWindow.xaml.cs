using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using EmplyeeList.Data;

namespace EmployeeList.App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private EmployeeListDatabase database = new EmployeeListDatabase();
		private ObservableCollection<Employee> employeeList;
		private Departments department;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<Employee> EmployeeList
		{
			get => employeeList;
			set
			{
				employeeList = value;
				NotifyPropertyCahnged();
			}
		}

		public ObservableCollection<Departments> DepartmentList { get; set; }

		public Employee SelectedEmployee { get; set; }

		public Departments Department
		{
			get => department;
			set
			{
				department = value;
				NotifyPropertyCahnged();
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			EmployeeList = database.Employees;

			DepartmentList = new ObservableCollection<Departments>();
			DepartmentList.Add(Departments.None);
			DepartmentList.Add(Departments.HumanResources);
			DepartmentList.Add(Departments.Logistics);
			DepartmentList.Add(Departments.IT);
			DepartmentList.Add(Departments.Finance);
			DepartmentList.Add(Departments.Accounting);
			DepartmentList.Add(Departments.Legal);
		}

		private void employeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(e.AddedItems.Count > 0)
			{
				employeeControl.Employee = (Employee)SelectedEmployee.Clone();
			}
		}

		private void btnApply_Click(object sender, RoutedEventArgs e)
		{
			if (employeeDataGrid.SelectedItems.Count < 1)
				return;

			EmployeeList[EmployeeList.IndexOf(SelectedEmployee)] = employeeControl.Employee;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (employeeDataGrid.SelectedItems.Count < 1)
				return;

			if(MessageBox.Show("Вы действительно желаете удалить работника из списка?", "Удаление сотрудника из списка",
				MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				database.Employees.Remove((Employee)employeeDataGrid.SelectedItems[0]);
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			AddWindow addWindow = new AddWindow();
			addWindow.Owner = this;
			if(addWindow.ShowDialog() == true)
			{
				database.Employees.Add(addWindow.Employee);
				MessageBox.Show("Сотрудник добавлен.", "Результат добавления сотрудника", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Добавление сотрудника отменнено.", "Результат добавления сотрудника", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if ((Departments)cbDepartment.SelectedItem != Departments.None)
			{
				EmployeeList = new ObservableCollection<Employee>(database.Employees.Where(x => x.Department == (Departments)cbDepartment.SelectedItem));
			}
			else
			{
				EmployeeList = database.Employees;
			}
		}

		private void NotifyPropertyCahnged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
