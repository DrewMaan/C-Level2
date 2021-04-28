namespace Lesson2_Employees
{
	public class EmployeeFixedRate : Employee
	{
		public EmployeeFixedRate(string name, int age, string department, string position, decimal salary)
			: base(name, age, department, position, salary) { }

		public override decimal CalculateAverageMonthlyWage()
		{
			return Salary;
		}
	}
}
