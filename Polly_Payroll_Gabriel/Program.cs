using Polly_Payroll_Gabriel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

bool IsRunning = true;
decimal weeklyInvoiceTotal = 0;
decimal _hourlyWeeklyPayout =0;
decimal _InvoiceWeeklyPayout = 0;
decimal _salariedWeeklyPayout = 0;


List<IPayable> Invoicelist = new List<IPayable>();

Invoicelist.Add(new Salaried_Employee("John", "Smith", "111-11-1111", 800.5m));
Invoicelist.Add(new Salaried_Employee("Bob", "Smith", "222-11-1111", 600.5m));
Invoicelist.Add(new Salaried_Employee("Sally", "Smith", "333-11-1111", 1800.5m));
Invoicelist.Add(new Hourly_Employee("Karen", "Williams", "222-22-2222", 16.75m, 40));
Invoicelist.Add(new Hourly_Employee("Jill", "Jones", "444-22-2222", 20.55m, 35));
Invoicelist.Add(new Hourly_Employee("Bill", "Williams", "555-22-2222", 21.00m, 45));
Invoicelist.Add(new InvoiceItem("2536", 2, "Flux Capacitor", 3655.66m));
Invoicelist.Add(new InvoiceItem("1568", 3, "Clock", 35.55m));
Invoicelist.Add(new InvoiceItem("5068", 1, "12 ft Cable", 75m));


while (IsRunning)
{
    Menu();
}
 
 bool Menu()
{
    Console.WriteLine("\nPlease make a selection \n");
    Console.WriteLine("1. Enter a new Salaried employee \n");
    Console.WriteLine("2. Enter a new Hourly employee \n");
    Console.WriteLine("3. Enter a new Invoive \n");
    Console.WriteLine("4. Generate Invoicing \n");
    Console.WriteLine("5. Exit Program \n");

    switch (Console.ReadLine())
    {
        case "1":
            AddNewSalariedEmployee();
            return true;
        case "2":
            AddNewHourlyEmployee();
            return true;
        case "3":
            AddNewItem();
            return true;
        case "4":
            WeeklyInvoiceGenerator();
            return true;
        case "5":
            Console.WriteLine(" Exit Program \n");
            IsRunning = false;
            break;
        default:
            Console.WriteLine("Please choose 1,2,3,4 or 5. \n");
            break;
    }
    return true;
}
void CalculateWeekly ()
{
    for (int i = 0; i < Invoicelist.Count; i++)
    {
        weeklyInvoiceTotal = weeklyInvoiceTotal + Invoicelist[i].GetPayableAmount;

        if (Invoicelist[i].GetledgerType == IPayable.PayrollType.Invoice.ToString())
        {
            _InvoiceWeeklyPayout = _InvoiceWeeklyPayout + Invoicelist[i].GetPayableAmount;
        }
        if (Invoicelist[i].GetledgerType == IPayable.PayrollType.Salaried.ToString())
        {
            _salariedWeeklyPayout = _salariedWeeklyPayout + Invoicelist[i].GetPayableAmount;
        }
        if (Invoicelist[i].GetledgerType == IPayable.PayrollType.Hourly.ToString())
        {
            _hourlyWeeklyPayout = _hourlyWeeklyPayout + Invoicelist[i].GetPayableAmount;
        }
    }
}

void WeeklyInvoiceGenerator()
{
    Console.WriteLine("\nWeekly Invoice Payout is as follows:\n");
    foreach (var item in Invoicelist)
    {
        Console.WriteLine(item);
    }
    CalculateWeekly();
    Console.WriteLine("Total Weekly Payout: " + weeklyInvoiceTotal.ToString("c"));
    Console.WriteLine("Category Breakdown: ");
    Console.WriteLine(" Invoices: " + _InvoiceWeeklyPayout.ToString("c") 
                      + "\n Salaried Payroll: "+ _salariedWeeklyPayout.ToString("c")
                      + "\n Hourly Payroll: " + _hourlyWeeklyPayout.ToString("c"));
}
void AddNewHourlyEmployee()
{
    Console.WriteLine("Please enter employee first name:");
    string firstName = Console.ReadLine();
    Console.WriteLine("Please enter employee last Name:");
    string lastName = Console.ReadLine();
    Console.WriteLine("Please enter the SSNumber:");
    string SSNumber = Console.ReadLine();
    Console.WriteLine("Please enter the Hourly Wage:");
    decimal HourlyWage = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Please enter the hours worked:");
    int HoursWorked = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("\nNew Employee has been added:");
    Hourly_Employee H = new Hourly_Employee(firstName, lastName, SSNumber, HourlyWage,HoursWorked);
    Invoicelist.Add(H);
    Console.WriteLine(H.ToString());
}
void AddNewSalariedEmployee()
{
    Console.WriteLine("Please enter employee first name:");
    string firstName = Console.ReadLine();
    Console.WriteLine("Please enter employee last Name:");
    string lastName = Console.ReadLine();
    Console.WriteLine("Please enter the SSNumber:");
    string SSNumber = Console.ReadLine();
    Console.WriteLine("Please enter the Hourly Wage:");
    decimal weeklyWage = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("\nNew Employee has been added:");
    Salaried_Employee S = new Salaried_Employee(firstName, lastName, SSNumber, weeklyWage);
    Invoicelist.Add(S);
    Console.WriteLine(S.ToString());
}
void AddNewItem()
{
    Console.WriteLine("Please enter Part Number Name:");
    string PartNumber = Console.ReadLine();
    Console.WriteLine("Please enter Quanity of part:");
    int Quanity = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please enter the Description:");
    string PartDescription = Console.ReadLine();
    Console.WriteLine("Please enter the price:");
    decimal Price = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("\nNew Invoice Item has been added:");
    InvoiceItem I = new InvoiceItem(PartNumber, Quanity, PartDescription, Price);
    Invoicelist.Add(I);
    Console.WriteLine(I.ToString());
}
