using System.Collections;
using System.Collections.Generic;

namespace Lesson2_Employees
{
	public class Employees : IEnumerable<Employee>
	{
		Employee[] _employees;

		public Employees(Employee[] employees)
		{
			_employees = employees;
		}

		public IEnumerator<Employee> GetEnumerator()
		{
			for (int i = 0; i < _employees.Length; i++)
				yield return _employees[i];
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			for (int i = 0; i < _employees.Length; i++)
				yield return _employees[i];
		}
	}
}
