using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Bank
    {

        public void Start()
        {
            Console.CursorVisible = false;
            Card CreditCard1 = new Card("5117764554072249", "1234", "123", new DateTime(2021, 8, 1).ToString("MM/yy"), 1000);
            Client client1 = new Client("Ali", "Elesgerov", CreditCard1);
            Card CreditCard2 = new Card("9784519845698456", "1568", "228", new DateTime(2024, 9, 1).ToString("MM/yy"), 2000);
            Client client2 = new Client("Jhon", "Jhonlu", CreditCard2);
            Card CreditCard3 = new Card("9845194569845894", "8754", "478", new DateTime(2023, 1, 1).ToString("MM/yy"), 3000);
            Client client3 = new Client("Aftandil", "Aftandilov", CreditCard3);
            Card CreditCard4 = new Card("9187451987458745", "8745", "754", new DateTime(2024, 3, 1).ToString("MM/yy"), 5000);
            Client client4 = new Client("Filankes", "Filankesov", CreditCard4);
            Card CreditCard5 = new Card("1785497864874519", "4754", "425", new DateTime(2025, 6, 1).ToString("MM/yy"), 6000);
            Client client5 = new Client("Deputatin", "oglu", CreditCard5);
            Client[] clients = new Client[] { client1, client2, client3, client4, client5 };
            int index = -1;
            while(index==-1)
            {
                Console.Write("Please Enter Your PIN: ");
                string pin=Console.ReadLine();
                index = Find.FindByPIN(clients, pin);
                if (index!=-1)
                {
                    index=MainMenu(clients,clients[index]);
                }
                else
                {
                    Console.Clear();
                    continue;
                }
            }
        }

       

        public int MainMenu(in Client[]clients,in Client client)
        {
            string[] options = new string[] { "Balance", "Cash", "Transaction" ,"Back" ,"Exit" };
            string text = $"Welcome {client.Name} {client.Surname}";
            System.Threading.Thread.Sleep(1000);
            while (true)
            {
                switch (Controle(text,options))
                {
                    case 0:
                        Console.Clear();
                        client.CreditCard.ShowBalance();
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    case 1:
                        Cash(client);
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    case 2:
                        Transaction.Start(clients, client);
                        continue;
                    case 3:
                        Console.Clear();
                        return -1;
                    default:
                        break;
                }
                break;
            }
            return 0;
        }
        
        public void PrintOptions(in string[] options,int selected)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if(i == selected&&options[selected]=="Exit")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{i+1}. {options[i]}");
                    Console.ResetColor();
                }
                else if (i == selected && options[selected] == "Back")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i + 1}. {options[i]}");
                    Console.ResetColor();
                }
                else if(i==selected)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1}. {options[i]}");
                    Console.ResetColor();
                }
                else
                    Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public int Controle(in string text, in string[] options)
        {
            int selected = 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(text);
                PrintOptions(options, selected - 1);
                ConsoleKeyInfo KeyInfoPressed = Console.ReadKey();
                switch (KeyInfoPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected > 1)
                            selected--;
                        else
                            selected = options.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selected < options.Length)
                            selected++;
                        else
                            selected = 1;
                        break;
                    case ConsoleKey.Enter:
                        return --selected;
                }
            }
        }

        public void GetCash(Client client,decimal cash)
        {
            if (client.CreditCard.Balance > cash)
            {
                client.CreditCard.Balance -= cash;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
                Console.ResetColor();
            }
            else
                throw new Exception("poor boi u don't have enough money");
        }

        public void Cash(Client client)
        {
            string[] options = new string[] { "10", "20", "50", "100","Other" };
            decimal cash;
            while (true)
            {
                Console.Clear();
                string text = "How much maney you want to get?";
                try
                {
                    switch (Controle(text, options))
                    {
                        case 0:
                            cash = 10;
                            break;
                        case 1:
                            cash = 20;
                            break;
                        case 2:
                            cash = 50;
                            break;
                        case 3:
                            cash = 100;
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine(text);
                            cash = Convert.ToDecimal(Console.ReadLine());
                            break;
                        default:
                            continue;
                    }
                    GetCash(client, cash);
                    break;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }
               
            }
            
        }
    }
}
