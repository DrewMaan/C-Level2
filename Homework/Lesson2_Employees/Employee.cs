using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_Employees
{
	public abstract class Employee : IComparable, IComparer<Employee>
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Department { get; set; }
		public string Position { get; set; }
		public decimal Salary { get; set; }

		public Employee(string name, int age, string department, string position, decimal salary)
		{
			Name = name;
			Age = age;
			Department = department;
			Position = position;
			Salary = salary;
		}

		public abstract decimal CalculateAverageMonthlyWage();

		public int CompareTo(object obj)
		{
			Employee employee = obj as Employee;

			if (employee != null)
			{
				if (Name.CompareTo(employee.Name) != 0)
					return Name.CompareTo(employee.Name);
				else
				{
					if (CalculateAverageMonthlyWage().CompareTo(employee.CalculateAverageMonthlyWage()) != 0)
						return CalculateAverageMonthlyWage().CompareTo(employee.CalculateAverageMonthlyWage());
					return 0;
				}
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public int Compare(Employee x, Employee y)
		{
			if (x != null && y != null)
			{
				if (x.Name.CompareTo(y.Name) != 0)
					return x.Name.CompareTo(y.Name);
				else
				{
					if (x.CalculateAverageMonthlyWage().CompareTo(y.CalculateAverageMonthlyWage()) != 0)
						return x.CalculateAverageMonthlyWage().CompareTo(y.CalculateAverageMonthlyWage());
					return 0;
				}
			}
			else
			{
				throw new ArgumentException();
			}
		}
	}
}
