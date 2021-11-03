using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_5_Garage_v2
{
    /// <summary>
    /// Statiska metoder för att kolla regnummer..
    /// </summary>
    static class OtherMethods
    {
        public static bool IsValidLicenseNumber(string input, out string exeptionMessage)
        {
            exeptionMessage = "Felmeddelande:\n";
            int numberOfExeptions = 0;
            input = input.Trim();
            char[] inputArray = input.ToCharArray();
            if (input.Length != 6)
            {
                exeptionMessage = "Felaktigt antal inmatade tecken!";
                return false;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!IsValidLetter(inputArray[i]))
                    {
                        exeptionMessage += $"Position {i+1}: {inputArray[i]} - Felaktigt tecken.\n";
                        numberOfExeptions++;
                    }
                }
                for (int i = 3; i < 5; i++)
                {
                    if (!Char.IsDigit(inputArray[i]))
                    {
                        exeptionMessage += $"Position {i+1}: {inputArray[i]} - Endast siffra tillåtet.\n";
                        numberOfExeptions++;
                    }
                }
                if (!Char.IsDigit(inputArray[5]) && !IsValidLetter(inputArray[5]))
                {
                    exeptionMessage += $"Position {5}: {inputArray[5]} - Felaktigt tecken.\n";
                }      
            }
            if (numberOfExeptions == 0) exeptionMessage = null;
            return (numberOfExeptions == 0 ? true : false);
            
        }
        public static bool IsValidLetter(char input)
        {
            char[] unallowedLetters = {'i', 'q', 'v', 'å', 'ä','ö'};
            if (!Char.IsLetter(input) || unallowedLetters.Contains(input))
            {
                return false;
            }
            else return true;
        }
    }
}
