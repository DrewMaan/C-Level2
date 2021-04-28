namespace EmplyeeList.Data
{
	public class Employee
	{
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public Departments Department { get; set; }
		public Shedule Shedule { get; set; }

		public Employee(string firstName, string secondName, string lastName, int age, Departments department, Shedule shedule)
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
			Shedule = Shedule.RegularHours;
		}

		public string FIO
		{
			get => $"{FirstName} {SecondName} {LastName}";
		}

		public override string ToString()
		{
			return "";
		}
	}
}
