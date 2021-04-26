using System.Windows;
using System.Windows.Controls;
using EmplyeeList.Data;

namespace EmployeeList.App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private EmployeeListDatabase database = new EmployeeListDatabase();
		public MainWindow()
		{
			InitializeComponent();
			UpdateBinding();
		}

		private void UpdateBinding()
		{
			employeeDataGrid.ItemsSource = null;
			employeeDataGrid.ItemsSource = database.Employees;
		}

		private void employeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(e.AddedItems.Count > 0)
			{
				employeeControl.SetEmployeeData((Employee)e.AddedItems[0]);
			}
		}

		private void btnApply_Click(object sender, RoutedEventArgs e)
		{
			if (employeeDataGrid.SelectedItems.Count < 1)
				return;

			employeeControl.UpdateEmployeeData();
			UpdateBinding();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (employeeDataGrid.SelectedItems.Count < 1)
				return;

			if(MessageBox.Show("Вы действительно желаете удалить работника из списка?", "Удаление сотрудника из списка",
				MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				database.Employees.Remove((Employee)employeeDataGrid.SelectedItems[0]);
				UpdateBinding();
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			AddWindow addWindow = new AddWindow();
			addWindow.Owner = this;
			if(addWindow.ShowDialog() == true)
			{
				database.Employees.Add(addWindow.Employee);
				UpdateBinding();
				MessageBox.Show("Сотрудник добавлен.", "Результат добавления сотрудника", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Добавление сотрудника отменнено.", "Результат добавления сотрудника", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}
