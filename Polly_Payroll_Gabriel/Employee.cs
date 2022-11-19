using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_Payroll_Gabriel
{
	internal class Employee : IPayable
	{
		private string _firstName;
		private string _lastName;
		private string _SSNumber;
		private decimal _earnings;
		private string _payrollType;
		public virtual decimal GetPayableAmount => _earnings;
        public string GetledgerType => _payrollType;
        public Employee(string firstName, string lastName,
			string SSNumber, IPayable.PayrollType payrollType)
		{
			_firstName = firstName;
			_lastName = lastName;
			_SSNumber = SSNumber;
			_payrollType = payrollType.ToString();          
        }
        public Employee(string firstName, string lastName,
            string SSNumber, IPayable.PayrollType payrollType, decimal earnings)
        {
            _firstName = firstName;
            _lastName = lastName;
            _SSNumber = SSNumber;
            _payrollType = payrollType.ToString();
            _earnings = earnings;
        }
        public override string ToString()
		{
			return
				_payrollType + " Employee" 
                + "\nEmployee first name: " + _firstName
				+ "\nEmployee last name: " + _lastName
				+ "\nEmployee SSN: " + _SSNumber + "\n";

        }
	}
}
