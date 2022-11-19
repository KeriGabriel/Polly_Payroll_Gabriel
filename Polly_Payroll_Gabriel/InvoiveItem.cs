using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polly_Payroll_Gabriel
{
    internal class InvoiceItem : IPayable
    {
        private string _partNumber;
        private int _quanity;
        private string _partDescription;
        private decimal _price;
        private decimal _extendedPrice;
        private string _invoiceNumber;
        private string _ledgerType;

        public decimal GetPayableAmount => _extendedPrice;

        public string GetledgerType => _ledgerType;

        public	InvoiceItem(string PartNumber, int Quanity, string PartDescription, decimal Price)
		{
            _partNumber = PartNumber;
            _quanity = Quanity;
            _partDescription = PartDescription;
            _price = Price;
            _ledgerType = IPayable.PayrollType.Invoice.ToString();
            InvoiceNumberGenerator();
            ExtendedPriceGenerator();
        }
        private void ExtendedPriceGenerator()
        {
            _extendedPrice = _quanity * _price;
        }
        private void InvoiceNumberGenerator()
        {
            Random invoiceNumber = new Random(DateTime.Now.Millisecond);
            string result = invoiceNumber.Next(100000, 999999).ToString();
             _invoiceNumber = result + "_" + _partNumber;
        }
        public override string ToString()
        {
            return
                _ledgerType+": " + _invoiceNumber + "\n" 
                + "Quanity: " + _quanity + "\n"
                + "Part Description: " + _partDescription + "\n"
                + "Unit Price: " + _price.ToString("C") + "\n"
                + "Extended Price: " + _extendedPrice.ToString("C") + "\n";
        }
    }
}
