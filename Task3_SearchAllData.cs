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
    //searching all data files 
    class Task3_SearchAllData
    {
        //Entering data for searching all data files 
        public static void EnterDataSearch(ref string[] DataHolder)
        {
            //All of the 1st set of files in array
            string[] FilePaths = Class1.SortArrayBubble();

            Console.WriteLine("You will now have to enter 11 peices of data to search by:       ");
            for (int i = 0; i < 11; i++)
            {
                //strip file path down to file down
                FilePaths[i] = Regex.Replace(Path.GetFileNameWithoutExtension(FilePaths[i]), @"[\d-]", string.Empty).Replace("_", "");
                bool TF = false;
                while (TF == false)
                {
                    Console.WriteLine("Please Enter the {0} you would like to search for:", FilePaths[i]);
                    try
                    {
                        DataHolder[i] = Console.ReadLine();
                        TF = true;
                        if (DataHolder[i] == "")
                            TF = false;
                    }
                    //catches errors
                    catch (System.FormatException e)
                    {
                        Console.WriteLine("Exception caught: {0}", e);
                        Console.WriteLine();
                    }
                }
            }
        }
        
        //linear search 
        public static void LinearSearch(string[,] FileHolder1, int size)
        {
            string[] DataHolder = new string[11]; //data stored for searching 
            string[,] MatchData = new string[11,1]; //stores data if any found 
            EnterDataSearch(ref DataHolder); //calls the data entry for searching
            bool DataFound = false;
            int counter = 0;
            int position;
            //checks input against elements and repeats for all searches 
            for (int y = 0; y < size; y++)
            {
                if (DataHolder[0] == FileHolder1[0, y].Replace(" ", ""))
                {
                    MatchData[0,0] = FileHolder1[0,y];
                    counter = 1;
                    for (int i = 1; i < 11; i++)
                    {
                        if (i < 8 && i > 3)
                        {
                            FileHolder1[i,y] = string.Format("{0:G29}", decimal.Parse(FileHolder1[i,y]));
                        }
                        if (DataHolder[i] == FileHolder1[i, y].Replace(" ", ""))
                        {
                            MatchData[i,0] = FileHolder1[i,y];
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                            i=11;
                        }
                    }
                }
                if(counter >=11)
                { 
                    position =y;
                    DataFound =true;
                    y = size;
                }
            }
            if (DataFound == false)
            {
                //No data was found 
                Console.WriteLine("");
                Console.WriteLine("Sorry No Data Was found With Your Criteria!!     ");
                Console.WriteLine("");
                Console.ReadLine();
            }
            else
            {
                //data was found 
                Console.WriteLine("");
                Console.WriteLine("Data Was found That Matches Your Criteria!!  ");
                Console.WriteLine("");
                Class1.SendToHTML(MatchData, 1);
            }
        }
    }
}
