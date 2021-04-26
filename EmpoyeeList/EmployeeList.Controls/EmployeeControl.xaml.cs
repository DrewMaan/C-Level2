using EmplyeeList.Data;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace EmployeeList.Controls
{
	/// <summary>
	/// Логика взаимодействия для EmployeeControl.xaml
	/// </summary>
	public partial class EmployeeControl : UserControl, INotifyPropertyChanged
	{
		Employee employee;
		public event PropertyChangedEventHandler PropertyChanged;

		public Employee Employee
		{
			get => employee;
			set
			{
				employee = value;
				NotifyPropertyChanged();
			}
		}

		public ObservableCollection<Departments> DepartmentList { get; set; } = new ObservableCollection<Departments>();
		public ObservableCollection<Schedule> SheduleList { get; set; } = new ObservableCollection<Schedule>();

		public EmployeeControl()
		{
			InitializeComponent();
			DataContext = this;

			DepartmentList.Add(Departments.HumanResources);
			DepartmentList.Add(Departments.Logistics);
			DepartmentList.Add(Departments.IT);
			DepartmentList.Add(Departments.Finance);
			DepartmentList.Add(Departments.Accounting);
			DepartmentList.Add(Departments.Legal);

			SheduleList.Add(Schedule.IrregularHours);
			SheduleList.Add(Schedule.RegularHours);
			SheduleList.Add(Schedule.FlexibleHours);
			SheduleList.Add(Schedule.ShiftWorks);
		}

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
