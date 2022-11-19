using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polly_Payroll_Gabriel.IPayable;

namespace Polly_Payroll_Gabriel
{
    internal class Hourly_Employee : Employee 
    {
        private decimal _hourlyWage;
        private int _hoursWorked;
        private decimal _earnings;
        public override decimal GetPayableAmount => _earnings;
        public Hourly_Employee
            (string firstName, string lastName, string SSNumber,
                 decimal HourlyWage, int HoursWorked)
            :base(firstName,lastName, SSNumber,IPayable.PayrollType.Hourly)
        {
            _hourlyWage = HourlyWage;
            _hoursWorked = HoursWorked;
            generate_PayableAmount();
        }
        private string generate_PayableAmount()
        {
            if (_hoursWorked > 40)
                _earnings = _hoursWorked * (_hourlyWage * 1.5m);
            else
                _earnings = _hoursWorked * _hourlyWage;
            return _earnings.ToString("c");
        }
        public override string ToString()
        {
            return base.ToString() + " Hourly wage: " + _hourlyWage.ToString("c")
                + "\n Hours Worked: " + _hoursWorked + "\n Earned: " + _earnings + "\n";
        }
    }
}
