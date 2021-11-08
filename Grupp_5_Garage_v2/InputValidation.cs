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
    static class InputValidation
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
        public static bool IsValidEnum(string input, out string execptionMessage, int maxIndexOfEnum)
        {
            execptionMessage = "";
            bool isValid = int.TryParse(input, out int inputValue);
            if (!isValid)
            {
                execptionMessage = $"Felaktig inmatning.";
                return false;
            }
            else if (isValid && (inputValue < 1 || inputValue > maxIndexOfEnum))
            {
                execptionMessage = $"Felaktig inmatning. Ange 1 till {maxIndexOfEnum}";
                return false;
            }
            else return isValid;


        }
        public static bool IsValidModelYearNumber(string input, out string exceptionMessage, out int modelYear)
        {
            exceptionMessage = "";
            bool isValid = int.TryParse(input, out modelYear);
            if (!isValid)
            {
                exceptionMessage = "Endast siffor tillåtna";
                return false;
            }

            if (modelYear < 100 && modelYear > DateTime.Now.Year - 2000)
            {
                modelYear += 1900;
            }
            else if (modelYear <= DateTime.Now.Year - 2000) modelYear += 2000;
            if (modelYear > 1885 && modelYear <= DateTime.Now.Year)
            {
                return true;
            }
            else
            {
                exceptionMessage = "Ogiltigt årtal!";
                return false;
            }
        }
        public static string InitialToUpper(string input)
        {
            string x = input.ToUpper();
            input = input.Replace(input[0], x[0]);
            return input;
        }

    }
}
