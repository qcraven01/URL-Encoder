using System;
using System.IO;

using System.Web;


namespace URLEncoder
{
    class MainClass
    {
        static string urlFormatString = "https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf";
        public static void Main(string[] args)
        {
            Console.WriteLine("URL Encoder");

            do
            {
                Console.WriteLine("Project Name: ");
                string projectName = GetUserInput();
                Console.WriteLine("Activity Name: ");
                string activityName = GetUserInput();

                Console.WriteLine(CreateURL(projectName, activityName));

                Console.Write("Would you like to do another? (y/n): ");
            } while (Console.ReadLine().ToLower().Equals("y"));
        }
        static string CreateURL(string projectName, string activityName)
        {

            //create URL string and return it
            return String.Format(urlFormatString, Encode(projectName), Encode(activityName));
        }

        static string GetUserInput()
        {
            string input = "";
            do
            {
                input = Console.ReadLine();
                if (IsValid(input)) return input;
                Console.Write("The input contains invalid characters. Enter again: ");

            } while (true);
            // get valid input from the user
            // disallow strings with control characters
            // IsValid() below is used to check if input is valid
        }

        static bool IsValid(string input)
        {
            foreach (char character in input.ToCharArray())
            {
                if ((character >= 0x00 && character <= 0x1f) || character == 0x7f)
                {
                    return false;
                }
            }
            return true;
            // check if the string is valid and does not
            // contain control characters
            // if valid, return true
            // if not valid, return false
        }

        static string Encode(string value)
        {
            string encodedValue = "";
            foreach (char character in value.ToCharArray())     // return an encoded version of the 
                                                                // string provided in value
            {
                string characterString = character.ToString();
                encodedValue += characterString;
            }
            return encodedValue;
        }
    }
}











