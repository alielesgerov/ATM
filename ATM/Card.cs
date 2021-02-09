using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Card
    {

        private string _pan;
        private string _pin;
        private string _cvc;
        public string ExpireDate { set; get; }
        private decimal _balance;

        public Card(string pan, string pin, string cvc, string expireDate, decimal balance)
        {
            PAN = pan;
            PIN = pin;
            CVC = cvc;
            ExpireDate = expireDate;
            Balance = balance;
        }

        public string PAN
        {
            get
            {
                return _pan;
            }

            set
            {
                if(!IsValid.IsPanValid(value))
                {
                    throw new InvalidOperationException("Invalid PAN!!");
                }
                _pan = value;
            }
        }

        public string PIN
        {
            get
            {
                return _pin;
            }

            set
            {
                if (!IsValid.IsPinValid(value))
                {
                    throw new InvalidOperationException("Invalid PIN!!");
                }
                _pin = value;
            }
        }

        public string CVC
        {
            get
            {
                return _cvc;
            }

            set
            {
                if (!IsValid.IsCvcValid(value))
                {
                    throw new InvalidOperationException("Invalid CVC!!");
                }
                _cvc = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return _balance;
            }

            set
            {
                if (value>=0)
                {
                    _balance = value;
                }
            }
        }

        public void ShowCardInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("=================================");
            Console.ResetColor();
            Console.Write("PAN: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(PAN);
            Console.ResetColor();
            Console.Write("Expire Date: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ExpireDate);
            Console.ResetColor();
            Console.Write("CVC: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CVC);
            ShowBalance();
        }

        public void ShowBalance()
        {
            Console.ResetColor();
            Console.Write("Balance: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Balance);
            Console.ResetColor();
        }

    }
}
