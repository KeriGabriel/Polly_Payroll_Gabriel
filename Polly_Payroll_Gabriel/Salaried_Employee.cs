﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_Payroll_Gabriel
{
    internal class Salaried_Employee : Employee
    {
        private decimal _weeklyWage;
        public Salaried_Employee
             (string firstName, string lastName, string SSNumber,
                  decimal weeklyWage)
             : base(firstName, lastName, SSNumber, IPayable.PayrollType.Salaried)
        {
            _weeklyWage = weeklyWage;
        }
        public override string ToString()
        {
            return "\n" + base.ToString()
                        + "\nSalary Earned: "
                        + _weeklyWage.ToString("C");                      
        }
    }
}