using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    static class Find
    {
        public static int FindByPIN(in Client[] clients, in string pin)
        {
            if (IsValid.IsPinValid(pin))
            {
                for (int i = 0; i < clients.Length; i++)
                {
                    if (clients[i].CreditCard.PIN == pin)
                        return i;
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid PIN!!");
            }
            return -1;
        }

        public static int FindByPAN(Client[] clients, string pan)
        {
            if (IsValid.IsPanValid(pan))
            {
                for (short i = 0; i < clients.Length; i++)
                {
                    if (clients[i].CreditCard.PAN == pan)
                        return i;
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid PAN!!");
            }
            return -1;
        }
    }


}
