using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoFiles
{
    class Task4_SearchMonth
    {
        //the search method for months
        public static void SearchMonth(string[,] FileHolder1, int Size,int Sortchoice)
        {
            bool TF = false;
            while (TF == false)
            {
                int NoMonth = 0;
                int count = 0;
                Console.Clear();
                //asks the user to search one of the following months
                Console.WriteLine("Please Enter one of the following:   ");
                Console.WriteLine("");
                Console.WriteLine("1:   January ");
                Console.WriteLine("2:   February ");
                Console.WriteLine("3:   March ");
                Console.WriteLine("4:   April ");
                Console.WriteLine("5:   May ");
                Console.WriteLine("6:   June ");
                Console.WriteLine("7:   July ");
                Console.WriteLine("8:   August ");
                Console.WriteLine("9:   September ");
                Console.WriteLine("10:  October ");
                Console.WriteLine("11:  November ");
                Console.WriteLine("12:  December ");
                Console.WriteLine("");
                try
                {   //checks the users input
                    string MonthChose = Console.ReadLine();

                    
                    
                    if( Sortchoice ==1) //binary search
                    {
                        BinarySearchClass.BinarySearch(FileHolder1, MonthChose, 1, 0, 0, Size); //binary search method
                    }
                    else if(Sortchoice == 2) //linear search
                    {
                        LinearSearch.SearchLinear(FileHolder1, MonthChose, 1, Size); //linear search method
                    }
                    bool TF2 = false;
                    while (TF2 == false)
                    {
                        Console.WriteLine("Would you like to sort another file? Enter Y/N     ");
                        string UserExitInput;
                        try
                        {
                            //checks the users input
                            UserExitInput = Console.ReadLine();
                            if (UserExitInput == "y" || UserExitInput == "Y") //checks if yes was entered
                            {
                                TF = false;
                            }
                            else
                            {
                                TF = true;
                            }
                        }
                        catch (System.FormatException e)
                        {
                            Console.WriteLine("Exception caught: {0}", e);
                            Console.WriteLine();
                        }
                        TF2 = true;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine("Exception caught: {0}", e);
                    Console.WriteLine();
                }
            }
        }
    }
}
