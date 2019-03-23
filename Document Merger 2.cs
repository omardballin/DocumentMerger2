using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)

        {
            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments.");
                Console.WriteLine("Must have at least two files and an output file must be provided.");
            }

            Console.Write("Enter the name of the first text file: ");
            string firstDocument = Console.ReadLine();

            while (firstDocument == null || firstDocument == "")
            {
                Console.WriteLine("File Name can not be blank. Please check your spelling and try again");
                Console.Write("Enter the name of the first text file: ");
                firstDocument = Console.ReadLine();
            }

            Console.Write("Enter the name of the second text file: ");
            string secondDocument = Console.ReadLine();

            while (secondDocument == null || secondDocument == "")
            {
                Console.WriteLine("File Name can not be blank. Please check your spelling and try again");
                Console.Write("Enter the name of the second text file: ");
                secondDocument = Console.ReadLine();
            }

            try
            {
                //create a list for strings parsed from both documents(I always start with a new line)
                List<string> finalString = new List<string> { "--First Document--" };

                StreamReader text = new StreamReader(firstDocument);
                string line;
                
                //as long as the next line read is not null (EOL), keep looping and adding parsed
                //strings to the final string list
                while ((line = text.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    finalString.Add(line);
                }

                text.Close();

                //New Line for ease to read
                finalString.Add(Environment.NewLine);

                //distinguishes portion that is from the second document document
                finalString.Add("--Second Document--");
                StreamReader text2 = new StreamReader(secondDocument);
                string line2;

                //as long as the next line read is not null (EOL), keep looping and adding parsed
                //strings to the final string list
                while ((line2 = text2.ReadLine()) != null)
                {
                    Console.WriteLine(line2);
                    finalString.Add(line2);
                }

                text2.Close();

                //concatenate the final path name (merge of the names of the two documents)
                string finalPathName = Path.GetFileNameWithoutExtension(firstDocument) + Path.GetFileNameWithoutExtension(secondDocument) + ".txt";

                //keep track of character count
                int wordcount = 0;

                //create new file with finalPathName as the name of the file
                using (StreamWriter finalFile = new StreamWriter(finalPathName))
                {
                    //loops through each index of our final string list and prints each string,
                    //in the order that we put it in
                    foreach (string l in finalString)
                    {
                        finalFile.WriteLine(l);
                        Console.WriteLine(l);
                        //get the length of each string that passes through
                        wordcount += l.Length;

                    }
                }
                
                Console.WriteLine(finalPathName + " was successfully saved. The document contains " + wordcount + " characters.");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("You've reached the finally block");
                Console.ReadLine();
            }

        }
    }
}