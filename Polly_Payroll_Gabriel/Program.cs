using Polly_Payroll_Gabriel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

bool IsRunning = true;
decimal weeklyInvoiceTotal = 0;

List<IPayable> Invoicelist = new List<IPayable>();

Invoicelist.Add(new Salaried_Employee("John", "Smith", "111-11-1111", 800.5m));
Invoicelist.Add(new Hourly_Employee("Karen", "Williams", "222-22-2222", 16.75m,40));
Invoicelist.Add(new InvoiceItem("2536", 2, "Flux Capacitor", 3655.66m));


while (IsRunning)
{
    Menu();
}
 
 bool Menu()
{
    Console.WriteLine("Please make a selection \n");
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
            Console.WriteLine("Generate Invoicing \n");
            WeeklyInvoiceGenerator();
            Console.WriteLine( calculateWeekly());
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
decimal calculateWeekly ()
{

    for (int i = 0; i < 4; i++)
    {
    weeklyInvoiceTotal = Invoicelist[i].GetPayableAmount;
       return weeklyInvoiceTotal + weeklyInvoiceTotal;
    }
    return weeklyInvoiceTotal;
}
void WeeklyInvoiceGenerator()
{
    foreach (var item in Invoicelist)
    {
        Console.WriteLine(item);
    }
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
