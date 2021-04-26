using EmplyeeList.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeList.App
{
	public class EmployeeListDatabase
	{
		private static int CHAR_BOUND_L = 65;
		private static int CHAR_BOUND_H = 90;

		private Random random = new Random();

		public ObservableCollection<Employee> Employees { get; set; }

		public EmployeeListDatabase()
		{
			Employees = new ObservableCollection<Employee>();
			GenerateEmployees(100);
		}

		private void GenerateEmployees(int count)
		{
			Employees.Clear();

			string firstName;
			string secondName;
			string lastName;
			int age;
			Departments department;
			Shedule shedule;

			for (int i = 0; i < count; i++)
			{
				firstName = GenerateSymbols(random.Next(6) + 5);
				secondName = GenerateSymbols(random.Next(6) + 5);
				lastName = GenerateSymbols(random.Next(6) + 5);

				age = random.Next(20, 61);
				department = (Departments)random.Next(1, 7);
				shedule = (Shedule)random.Next(0, 4);
				Employees.Add(new Employee(firstName, secondName, lastName, age, department, shedule));
			}
		}

		private string GenerateSymbols(int amount)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < amount; i++)
			{
				stringBuilder.Append((char)(CHAR_BOUND_L + random.Next(CHAR_BOUND_H - CHAR_BOUND_L)));
			}
			return stringBuilder.ToString();
		}
	}
}
