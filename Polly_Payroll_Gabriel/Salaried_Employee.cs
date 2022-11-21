using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_Payroll_Gabriel
{
    internal class Salaried_Employee : Employee  
    {
        private decimal _weeklyWage;
        private decimal _earnings;
        public override decimal GetPayableAmount => _earnings;
        public Salaried_Employee
             (string firstName, string lastName, string SSNumber,
                  decimal weeklyWage)
             : base(firstName, lastName, SSNumber, IPayable.PayrollType.Salaried)
        {
            _weeklyWage = weeklyWage;
            _earnings = weeklyWage;
        }
        //for future upgrade to monthly invoice payout.
        public Salaried_Employee
             (string firstName, string lastName, string SSNumber,
                  decimal weeklyWage,int numberOfWeeks)
             : base(firstName, lastName, SSNumber, IPayable.PayrollType.Salaried)
        {
            _weeklyWage = weeklyWage;
            CalculateEarnings(weeklyWage, numberOfWeeks);
        }
        private void CalculateEarnings(decimal weeklyWage, int numberOfWeeks)
        {
            _earnings = weeklyWage * numberOfWeeks;
        }
        public override string ToString()
        {
            return base.ToString()
                        + " Weekly Salary: "
                        + _weeklyWage.ToString("C") 
                        + "\nEarned: "+ _earnings.ToString("c")
                        +"\n";                      
        }
    }
}
