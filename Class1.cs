using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;

namespace MergeTwoFiles
{
    class Class1
    {
        //Prints To the Console 
        public static void Print2DArray<T>(T[,] FileHolder1,int NoElements)
        {
            for (int i = 0; i < NoElements; i++)
            {
                Console.Write("{0}  {1}       {2}  {3}  {4}  {5}  {6}  {7}   {8}                         {9}             {10}", FileHolder1[0, i], FileHolder1[1, i], FileHolder1[2, i], FileHolder1[3, i], FileHolder1[4, i], FileHolder1[5, i], FileHolder1[6, i], FileHolder1[7, i], FileHolder1[8, i], FileHolder1[9, i], FileHolder1[10, i]);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        //Reads files to a single dimension array
        public static void ReadFile(ref string[,] FileHolder, int YearIncrement)
        {
            string[] filePaths = SortArrayBubble();//Sorts Files into correct order (year,month,day,time etc) 
            int position = 0;
            
            string IndivFilePath;//holds one of the file paths for the use bellow.
            for(int i =0;i<11;i++)
            {
                IndivFilePath = filePaths[YearIncrement+i];
                string[] TempHolder = System.IO.File.ReadAllLines(@IndivFilePath);
                AddToTwoDArray(ref FileHolder, ref position, TempHolder);//adds the 1d array to a 2d array (MERGE)
                
            }
        }

        //Sorts the order of the file paths based off of bubble sort
        public static string[] SortArrayBubble()
        {
            string[] TempFilesPaths = Directory.GetFiles(@"K:\Algorithms_Complexity\MergeTwoFiles - Testing 3\Spare Files\", "*.txt", SearchOption.TopDirectoryOnly);//gets all file paths in location with .txt extension
            for (int i = 0; i < TempFilesPaths.Length; i++)
            {
                for (int j = i + 1; j < TempFilesPaths.Length; j++)
                {
                    //strips all the file path down till left with number (i assigned each file with a number 1-22)
                    string temp = "";
                    string holderfirst = Path.GetFileNameWithoutExtension(TempFilesPaths[i]);
                    string holdersecond = Path.GetFileNameWithoutExtension(TempFilesPaths[j]);
                    string holderfirst2 = holderfirst.Substring(0, holderfirst.IndexOf("_"));
                    string holdersecond2 = holdersecond.Substring(0, holdersecond.IndexOf("_"));

                    //applies bubble sort
                    if (Convert.ToInt32(holderfirst2) > Convert.ToInt32(holdersecond2))
                    {
                        temp = TempFilesPaths[i];

                        TempFilesPaths[i] = TempFilesPaths[j];

                        TempFilesPaths[j] = temp;
                    }
                }
            }
            //returns the array with all file paths
            return TempFilesPaths;
        }

        //adds one file at a time to a 2d array
        public static void AddToTwoDArray(ref string[,] FileHolder, ref int position, string[] Tempholder)
        {
            int count = 0;
            while (count < 600 && position < 11)
            {
                FileHolder[position, count] = Tempholder[count];
                count++;
            }
            position++;
        }

        //once both data sets have been added to two seperate 2d arrays they are merged into one
        public static void AddBothSets(ref string[,] FileHolder1, string[,] FileHolder2)
        {
            for(int i =600;i<1200;i++)
            {
                for (int y = 0; y < 11;y++)
                {
                    FileHolder1[y, i] = FileHolder2[y, i - 600];
                }
            }
        }

        //writes the array send to this method to a .CSV 
        public static void WriteToFile(string[,] DataFound, int timesrun)
        {
            using (StreamWriter outfile = new StreamWriter(@"K:\Algorithms_Complexity\MergeTwoFiles - Testing 3\Spare Files\Storage.csv"))
            {
                for (int x = 0; x < timesrun; x++)
                {
                    string content = "";
                    for (int y = 0; y < 11; y++)
                    {
                        DataFound[y, x] = DataFound[y, x].Replace(",", " ");
                        content += DataFound[y, x] + ",";
                    }
                    outfile.WriteLine(content);
                }
            }
        }

        //Changes all months in an array passed to numbers Jan =1 & Dec =12 for sorting/ searching
        public static void ChangeMonthsToInt(ref string[,] Fileholder1, int size,int Position)
        {
            //stores the months in a 1d array
            string[] Months = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

            //loops throught a nested for loop, chech each element in the months column in the array against the above array
            //chnaging its value to a number based on the postion in the MontshArray
            for (int i = 0; i < size; i++)
            {
                for(int y = 0; y<12;y++)
                {
                    if (Fileholder1[Position, i].Replace(" ", "") == Months[y])
                    {
                        Fileholder1[Position, i] = Convert.ToString(y + 1);
                        y = 12;
                    }
                }
            }
        }

        //Changes all numbers into months, 1= jan 12=Dec
        public static void ChangeIntToMonth(ref string[,] Fileholder1, int size)
        {
            //stores the months in a 1d array
            string[] arr1 = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            for (int i = 0; i < size; i++)
            {
                Fileholder1[1, i] = arr1[Convert.ToInt32(Fileholder1[1, i])-1];
            }
        }

        //reverses a given array so that all elements are displayed backwards 
        public static void SwapValues(ref string[,] FileHolder1, int size)
        {
            string TempHolder;
            for (int i = 0; i < (size / 2) - 1; i++)
            {
                for(int y =0;y<11;y++)
                {
                    TempHolder = FileHolder1[y, (size - 1) - i];
                    FileHolder1[y, (size - 1) - i] = FileHolder1[y, i];
                    FileHolder1[y, i] = TempHolder;
                }
            }
        }

        //Sends a given array to a .HTML file and opens said file.
        public static void SendToHTML(string[,] FileHolder1,int NoElements)
        {
            string[] FilePaths = Class1.SortArrayBubble(); //holds all file paths
            List<string> lines = new List<string>(); // list used to stored .HTML code for writing to file
            //>HTML code for a table 
            lines.Add("<html>");
            lines.Add("<body>");
            lines.Add("<table>");
            lines.Add("<tr>");
            //strips all file paths down till the name of said file is left, used to heading in the .HTML table 
            for (int i = 0; i < 11; i++)
            {
                FilePaths[i] = Regex.Replace(Path.GetFileNameWithoutExtension(FilePaths[i]), @"[\d-]", string.Empty).Replace("_", "");
                lines.Add("<td><b>||" + FilePaths[i] + "<b></td>");
            }
            lines.Add("</tr>");
            //loops through array displaying all its contents into a table 
            for (int i = 0; i < NoElements; i++)
            {
                lines.Add("<tr>");
                for (int y = 0; y < 11; y++)
                {
                    lines.Add("<td>||" + FileHolder1[y, i] + "</td>");
                }
                lines.Add("<tr>");
            }

            lines.Add("</table>");
            lines.Add("</body>");
            lines.Add("</html>");
            File.WriteAllLines(@"K:\Algorithms_Complexity\MergeTwoFiles - Testing 3\Spare Files\myfile.htm", lines.ToArray()); //writes the list to a given .HTML file 
            System.Diagnostics.Process.Start(@"K:\Algorithms_Complexity\MergeTwoFiles - Testing 3\Spare Files\myfile.htm"); //opens said .HTML file
        }
    }
}
