using System;
using System.Net.Http;
using BankApiClasses;

namespace ApiTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzIiwianRpIjoiZjRjNzQxOTMtNTYxYS00Nzk0LWE2ZmEtNDM0NWUzNGRiZTg1Iiwicm9sZXMiOiJDdXN0b21lciIsImV4cCI6MTYyMTc5MDY0MSwiaXNzIjoiYmFua2FkbWluYXBwIiwiYXVkIjoiYmFua2FkbWluYXBwIn0.JJKPFAgnCS6kvJdPMtMtW5ZIStTwO_zH45ZWL5jRNb0");

            var service = new BankApiClasses.swaggerClient("https://localhost:44368/", httpClient);

            var customerModel = new CustomerDetailsViewModel();

            try
            {
                customerModel = service.GetDetailsAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(customerModel.FullName);
            foreach (var a in customerModel.AccountItems)
            {
                Console.WriteLine(a.AccountNumber);
                Console.WriteLine(a.Balance);
                Console.WriteLine(a.AccountOwnership);
            }

            var accountTransactionsModel = service.GetTransactionsAsync(1, 0, 5).Result;

            foreach (var t in accountTransactionsModel.TransactionItems)
            {
                Console.WriteLine(t.TransactionId);
                Console.WriteLine(t.Type);
                Console.WriteLine(t.Amount);
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
    
}
