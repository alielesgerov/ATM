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
                if(value.Length==16)
                {
                    _pan = value;
                }
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
                if (value.Length == 4)
                {
                    _pin = value;
                }
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
                if (value.Length == 3)
                {
                    _cvc = value;
                }
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


    }
}
