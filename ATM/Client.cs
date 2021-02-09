using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Client
    {
        private string _name;
        private string _surname;
        public Card CreditCard { set; get; }

        public Client(string name, string surname, Card creditCard)
        {
            Name = name;
            Surname = surname;
            CreditCard = creditCard;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!IsValid.IsNameOrSurnameValid(value))
                {
                    throw new InvalidOperationException("Invalid Name!!");
                }
                else
                    _name = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (!IsValid.IsNameOrSurnameValid(value))
                {
                    throw new InvalidOperationException("Invalid Surname!!");
                }
                else
                    _surname = value;
            }
        }

        public void ShowClientInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("===========Client Info===========");
            Console.ResetColor();
            Console.Write("Client Name: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Name);
            Console.ResetColor();
            Console.Write("Client Surname: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Surname);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("============Card Info============");
            CreditCard.ShowCardInfo();
        }
    }
}
