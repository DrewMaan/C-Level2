using System;

namespace Lesson2_Employees
{
	class Program
	{
		static string[] _names = new string[20]
		{
			"Вадим", "Александр", "Владислав", "Андрей", "Никита", "Валерий", "Максим", "Кирилл", "Дмитрий", "Игнат",
			"Мария", "Анна", "Ирина", "Марина", "Евгения", "Екатерина", "Татьяна", "Анастасия", "Ксения", "Дарья"
		};

		static string[] _departments = new string[5]
		{
			"Отдел1", "Отдел2", "Отдел3", "Отдел4", "Отдел5"
		};

		static string[] _positions = new string[10]
		{
			"Должность1", "Должность2", "Должность3", "Должность4", "Должность5", "Должность6", "Должность7", "Должность8", "Должность9", "Должность10"
		};


		static void Main(string[] args)
		{
			Employee[] employees = new Employee[20];
			MakeArrayEmployees(employees, _names, _departments, _positions);
			Employees employees1 = new Employees(employees);

			for (int i = 0; i < employees.Length; i++)
			{
				Console.WriteLine($"Employee {i + 1}");
				Console.WriteLine($"Type: {employees[i].GetType()} Name: {employees[i].Name} ");
				Console.WriteLine($"Department: {employees[i].Department} Position: {employees[i].Position}");
				Console.WriteLine($"Age: {employees[i].Age} Salary: {employees[i].Salary}");
				Console.WriteLine();
			}

			foreach (var employee in employees1)
			{
				Console.WriteLine($"Type: {employee.GetType()} Name: {employee.Name} ");
				Console.WriteLine($"Department: {employee.Department} Position: {employee.Position}");
				Console.WriteLine($"Age: {employee.Age} Salary: {employee.Salary}");
				Console.WriteLine();
			}

			Array.Sort(employees);

			for (int i = 0; i < employees.Length; i++)
			{
				Console.WriteLine($"Employee {i + 1}");
				Console.WriteLine($"Type: {employees[i].GetType()} Name: {employees[i].Name} ");
				Console.WriteLine($"Department: {employees[i].Department} Position: {employees[i].Position}");
				Console.WriteLine($"Age: {employees[i].Age} Salary: {employees[i].Salary}");
				Console.WriteLine();
			}

			Console.ReadKey();
		}

		static void MakeArrayEmployees(Employee[] employees, string[] names, string[] departments, string[] positions)
		{
			int n;
			int d;
			int p;
			Random random = new Random();
			for (int i = 0; i < employees.Length; i++)
			{
				n = random.Next(0, 19);
				p = random.Next(0, 9);
				d = random.Next(0, 4);
				if (i % 2 == 0)
				{
					employees[i] = new EmployeeFixedRate(names[n], random.Next(20, 60), departments[d], positions[p], random.Next(10, 20) * 1000);
				}
				else
				{
					employees[i] = new EmployeeHourlyRate(names[n], random.Next(20, 60), departments[d], positions[p], random.Next(1, 10) * 10);
				}
			}
		}
	}
}
