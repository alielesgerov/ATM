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
            bool istrue=false;
            while(!istrue)
            {
                Console.Clear();
                Console.Write("Enter PAN: ");
                string pan = Console.ReadLine();
                Console.Write("Enter Value:");
                decimal value = Convert.ToDecimal(Console.ReadLine());
                istrue=TransAction(clients, client, pan, value);
            }
           
        }

        public static bool TransAction(Client[] clients,Client client,in string pan,decimal value)
        {
            try
            {
                if (IsValid.IsPanValid(pan))
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
                        return true;
                    }

                }
                else
                {
                    throw new InvalidOperationException("Invalid PAN!!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                System.Threading.Thread.Sleep(1000);
            }
            return false;
           
        }
    }
}
