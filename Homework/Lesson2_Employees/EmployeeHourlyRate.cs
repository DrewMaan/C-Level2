namespace Lesson2_Employees
{
	public class EmployeeHourlyRate : Employee
	{
		public EmployeeHourlyRate(string name, int age, string department, string position, decimal salary)
			: base(name, age, department, position, salary) { }

		public override decimal CalculateAverageMonthlyWage()
		{
			return (decimal)(20.8 * 8 * (double)Salary);
		}
	}
}
