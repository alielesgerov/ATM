using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    static class Transaction
    {
        public static void Start(Client[] clients,Client client)
        {
            while(true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Enter PAN: ");
                    string pan = Console.ReadLine();
                    if (!IsValid.IsPanValid(pan))
                    {
                        throw new InvalidOperationException("Invalid PAN!!");
                    }
                    Console.Write("Enter Value:");
                    string check_value = Console.ReadLine();
                    if (IsValid.IsValueValid(check_value))
                    {
                        decimal value = Convert.ToDecimal(check_value);
                        if (value > client.CreditCard.Balance || value < 0)
                        {
                            throw new InvalidOperationException("Invalid Value!!");
                        }
                        TransAction(clients, client, pan, value);
                        break;
                    }
                    else
                        throw new InvalidOperationException("Invalid Value");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }

            }
           
        }

        public static void TransAction(Client[] clients, Client client, in string pan, decimal value)
        {
            int index = Find.FindByPAN(clients, pan);
            if (index != -1)
            {
                client.CreditCard.Balance -= value;
                clients[index].CreditCard.Balance += value;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succsses");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                throw new Exception("PAN not found");
            }
        }
    }
}
