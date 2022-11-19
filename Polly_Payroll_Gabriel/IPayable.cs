using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Polly_Payroll_Gabriel
{
    internal interface IPayable
    {
        decimal GetPayableAmount { get; }
        string GetledgerType { get; }
        //public string createInvoice();
        public enum PayrollType
        {
            Salaried,
            Hourly,
            Invoice
        }
    }
}
