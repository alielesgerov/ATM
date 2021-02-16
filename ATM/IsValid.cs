using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public static class IsValid
    {
        public static bool IsNameOrSurnameValid(string value)
        {
            foreach (char check in "|\\?/>,.<`~!@#$%^&*()_+/*-1234567890")
            {
                if (value.Contains(check.ToString()))
                    return false;
            }
            return true;
        }
        
        public static bool IsPanValid(string value)
        {
            if(value.Length==16)
            {
                foreach (char check in "1234567890")
                {
                    if (value.Contains(check.ToString()))
                        return true;
                }
            }
            return false;
        }
        public static bool IsPinValid(string value)
        {
            if (value.Length == 4)
            {
                foreach (char check in "1234567890")
                {
                    if (value.Contains(check.ToString()))
                        return true;
                }
            }
            return false;
        }
        public static bool IsCvcValid(string value)
        {
            if (value.Length == 3)
            {
                foreach (char check in "1234567890")
                {
                    if (value.Contains(check.ToString()))
                        return true;
                }
            }
            return false;
        }

        public static bool IsValueValid(string value)
        {
            foreach (char check in "1234567890")
            {
                if (value.Contains(check.ToString()))
                    return true;
            }
            return false;
        }
    }
}
