using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmailChecker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string fileName = getFileName();
            processFile(fileName);
            Console.WriteLine("\nFinished");
            Console.ReadKey(true);
        }

        static string getFileName()
        {
            string fileName = "";

            Console.WriteLine("Please enter your file name now: ");
            string userInput = Console.ReadLine();


            //Checks to see if format has .csv
            if (userInput.Contains(".csv"))
            {
                fileName = userInput;
            }
            else if(!userInput.Contains("."))
            {
                fileName = userInput + ".csv";
            }
            else
            {
                Console.WriteLine("Please use the format: emailList or emailList.csv");
                getFileName();
                
            }

            return fileName;
        }
        public static void processFile(string fileName)
        {
            try
            {
                //Opens a file reader to look for file name
                using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\" + fileName))
                {
                    string email;
                    List<string> listOfEmails = new List<string>();

                    //splits the file into the email section and adds them to a list
                    while (!reader.EndOfStream)
                    {
                        string entry = reader.ReadLine();
                        email = entry.Split(',')[2];

                        listOfEmails.Add(email);
                        
                        
                    }
                    //The list created get sent to check if they are valid
                    emailChecker(listOfEmails);
                }
            }
            catch
            {
                //If the file can not be found you will be prompted to retry
                Console.WriteLine("That file wasn't found please try again: (use emailList)");
                processFile(Console.ReadLine());
                
            }
            

        }

        static void emailChecker(List<string> listOfEmails)
        {
            List<string> validList = new List<string>();
            List<string> unvalidList = new List<string>();

            //Checks each email to make sure it has a "." and an "@" sign then adds them accordingly to the correct list
            for (int j = 0; j < listOfEmails.Count; j++) {
                {
                    if (listOfEmails.ElementAt(j).Contains(".") && listOfEmails.ElementAt(j).Contains("@"))
                    {
                        validList.Add(listOfEmails.ElementAt(j));
                    }
                    else
                    {
                        unvalidList.Add(listOfEmails.ElementAt(j));
                    }
                } 
            }
            //Prints list to screen
            printResults(validList, unvalidList);

        }

        static public void printResults(List<string> valid, List<string> notValid)
        {
            Console.WriteLine("Valid List: ");
            for (int i = 0; i < valid.Count; i++)
            {
                Console.WriteLine(valid[i]);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Not Valid List: \n");

            for (int i = 0; i < notValid.Count; i++)
            {
                Console.WriteLine(notValid[i]);
            }
        }
    }
}
