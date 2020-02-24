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
    class Task6_SearchForIndividualData
    {
        public static void SearchingIndividual(string[,] FileHolder, int Size, int SortChoice, ref bool ExitCase)
        {
            //Class1.SendToHTML(FileHolder,Size);
            int UserInput3 = -1;
            bool Menu3 = false;
            while (Menu3 == false)
            {
                //sorts all the files into a array FilePaths
                string[] FilePaths = Class1.SortArrayBubble();
                Console.Clear();
                Console.WriteLine("Below Shows all Avaliable file Titles:    ");
                //strips all the file path and leaves the name of file 
                for (int i = 0; i < 11; i++)
                {
                    FilePaths[i] = Regex.Replace(Path.GetFileNameWithoutExtension(FilePaths[i]), @"[\d-]", string.Empty).Replace("_", "");
                    Console.WriteLine("{0}      :     {1}", i, FilePaths[i]);
                }
                Console.WriteLine("Please Enter the number for the file you wish to search:     ");
                try
                {   //User Input checked
                    UserInput3 = Convert.ToInt16(Console.ReadLine());
                    bool Menu4 = false;
                    while (Menu4 == false)
                    {
                        string UserInput4;
                        Console.WriteLine("Please Enter the Data you want to search for: (enure When you enter a decimal you make it three decimal places)    ");
                        try
                        {   //User Input checked
                            UserInput4 = Console.ReadLine();

                            

                            if (SortChoice ==1)
                            {
                                //changes the input into a int using chnage to int method
                                string[,] TempChoice = new string[1, 1];
                                TempChoice[0,0] =UserInput4;
                                Class1.ChangeMonthsToInt(ref TempChoice, 1,0);
                                UserInput4 = TempChoice[0, 0];
                                BinarySearchClass.BinarySearch(FileHolder, UserInput4, UserInput3, -1, -1, Size); //binary search
                            }
                            else if(SortChoice == 2)
                            {
                                LinearSearch.SearchLinear(FileHolder, UserInput4, UserInput3, Size); //linear search
                            }
                            
                            bool Menu5 = false;
                            while (Menu5 == false)
                            {
                                Console.WriteLine("Please Enter y/n if you want to search again: ");
                                string UserInput5;
                                try
                                {   //User Input checked
                                    UserInput5 = Console.ReadLine();
                                    if (UserInput5 == "y" || UserInput5 == "Y") //checks to see if its yes 
                                    {
                                        Menu5 = true;
                                        Menu4 = true;
                                    }
                                    else
                                    {
                                        Menu5 = true;
                                        Menu4 = true;
                                        Menu3 = true;
                                        ExitCase = true;
                                    }

                                }
                                catch (System.FormatException e) //Exception Handling
                                {
                                    Console.Clear();
                                    Console.WriteLine("Exception caught: {0}", e);
                                    Console.WriteLine();
                                }
                            }
                        
                        }
                        catch (System.FormatException e) //Exception Handling
                        {
                            Console.Clear();
                            Console.WriteLine("Exception caught: {0}", e);
                            Console.WriteLine();
                        }
                    
                    }
                }
                catch (System.FormatException e) //Exception Handling
                {
                    Console.Clear();
                    Console.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine();
                }
            }
        }
    }
}
