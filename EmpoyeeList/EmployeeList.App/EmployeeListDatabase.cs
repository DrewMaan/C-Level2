using EmplyeeList.Data;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

namespace EmployeeList.App
{
	public class EmployeeListDatabase
	{
		public const string ConnectionString = "Data Source=localhost;Initial Catalog=EmployeeList;User ID=EmployeeListRoot;Password=12345";

		//private static int CHAR_BOUND_L = 65;
		//private static int CHAR_BOUND_H = 90;

		//private Random random = new Random();

		public ObservableCollection<Employee> Employees { get; set; }

		public EmployeeListDatabase()
		{
			Employees = new ObservableCollection<Employee>();
			LoadFromDatabase();
			//GenerateEmployees(100);
			//SyncToDB();
		}

		//public void SyncToDB()
		//{
		//	foreach(var employee in Employees)
		//	{
		//		Add(employee);
		//	}
		//}

		public void LoadFromDatabase()
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();

				string sqlExpression = $@"SELECT * FROM Employees";
				var command = new SqlCommand(sqlExpression, sqlConnection);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							var employee = new Employee()
							{
								Id = (int)reader["Id"],
								FirstName = (string)reader["FirstName"],
								SecondName = (string)reader["SecondName"],
								LastName = (string)reader["LastName"],
								Age = int.Parse(reader["Age"].ToString()),
								Department = (Departments)int.Parse(reader["DepartmentId"].ToString()),
								Shedule = (Schedule)int.Parse(reader["ScheduleId"].ToString())
							};
							Employees.Add(employee);
						}
					}
				}
			}
		}

		public int Add(Employee employee)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();

				string sqlExpression = $@"INSERT INTO Employees (FirstName, SecondName, LastName, Age, DepartmentId, ScheduleId)
                    VALUES ('{employee.FirstName}', '{employee.SecondName}', '{employee.LastName}',
                    '{employee.Age}', {(int)employee.Department}, {(int)employee.Shedule})";
				var command = new SqlCommand(sqlExpression, sqlConnection);
				var res = command.ExecuteNonQuery();
				if (res > 0)
				{
					employee.Id = Employees.Last().Id + 1;
					Employees.Add(employee);
				}
				return res;
			}
		}

		public int Update(Employee employee)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();

				string sqlExpression = $@"UPDATE Employees
                    SET FirstName = '{employee.FirstName}', 
                    SecondName = '{employee.SecondName}',
                    LastName = '{employee.LastName}',
                    Age = '{employee.Age}',
                    DepartmentId = {(int)employee.Department},
                    ScheduleId = {(int)employee.Shedule}
                    WHERE Id = '{employee.Id}'";
				var command = new SqlCommand(sqlExpression, sqlConnection);
				return command.ExecuteNonQuery();
			}
		}

		public int Delete(Employee employee)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();

				string sqlExpression = $@"DELETE FROM Employees WHERE Id = '{employee.Id}'";
				var command = new SqlCommand(sqlExpression, sqlConnection);
				var res = command.ExecuteNonQuery();
				if (res > 0)
				{
					Employees.Remove(employee);
				}
				return res;
			}
		}

		//private void GenerateEmployees(int count)
		//{
		//	Employees.Clear();

		//	string firstName;
		//	string secondName;
		//	string lastName;
		//	int age;
		//	Departments department;
		//	Shedule shedule;

		//	for (int i = 0; i < count; i++)
		//	{
		//		firstName = GenerateSymbols(random.Next(6) + 5);
		//		secondName = GenerateSymbols(random.Next(6) + 5);
		//		lastName = GenerateSymbols(random.Next(6) + 5);

		//		age = random.Next(20, 61);
		//		department = (Departments)random.Next(1, 7);
		//		shedule = (Shedule)random.Next(0, 4);
		//		Employees.Add(new Employee(firstName, secondName, lastName, age, department, shedule));
		//	}
		//}

		//private string GenerateSymbols(int amount)
		//{
		//	StringBuilder stringBuilder = new StringBuilder();
		//	for (int i = 0; i < amount; i++)
		//	{
		//		stringBuilder.Append((char)(CHAR_BOUND_L + random.Next(CHAR_BOUND_H - CHAR_BOUND_L)));
		//	}
		//	return stringBuilder.ToString();
		//}
	}
}
