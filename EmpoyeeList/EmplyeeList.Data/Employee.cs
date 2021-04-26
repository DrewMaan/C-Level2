using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmplyeeList.Data
{
	public class Employee : INotifyPropertyChanged, ICloneable
	{
		private int id;
		private string firstName;
		private string secondName;
		private string lastName;
		private int age;
		private Departments department;
		private Schedule shedule;

		public int Id
		{
			get => id;
			set
			{
				id = value;
				NotifyPropertyChanged();
			}
		}

		public string FirstName
		{
			get => firstName;
			set
			{
				firstName = value;
				NotifyPropertyChanged();
			}
		}
		public string SecondName
		{
			get => secondName;
			set
			{
				secondName = value;
				NotifyPropertyChanged();
			}
		}
		public string LastName
		{
			get => lastName;
			set
			{
				lastName = value;
				NotifyPropertyChanged();
			}
		}
		public int Age
		{
			get => age;
			set
			{
				age = value;
				NotifyPropertyChanged();
			}
		}
		public Departments Department
		{
			get => department;
			set
			{
				department = value;
				NotifyPropertyChanged();
			}
		}
		public Schedule Shedule
		{
			get => shedule;
			set
			{
				shedule = value;
				NotifyPropertyChanged();
			}
		}

		public Employee(string firstName, string secondName, string lastName, int age, Departments department, Schedule shedule)
		{
			FirstName = firstName;
			SecondName = secondName;
			LastName = lastName;
			Age = age;
			Department = department;
			Shedule = shedule;
		}

		public Employee()
		{
			FirstName = "";
			SecondName = "";
			LastName = "";
			Age = 0;
			Department = Departments.None;
			Shedule = Schedule.RegularHours;
		}

		public string FIO
		{
			get => $"{FirstName} {SecondName} {LastName}";
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public override string ToString()
		{
			return $"{SecondName} {FirstName} {LastName}: Отдел - {Department} График работы: {Shedule}";
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
