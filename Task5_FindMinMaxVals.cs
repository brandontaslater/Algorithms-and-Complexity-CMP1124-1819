using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoFiles
{
    class Task5_FindMinMaxVals
    {
        public static void FindMaxData(string[,] Fileholder,int Size)
        {
            Class1.ChangeMonthsToInt(ref Fileholder, Size, 1); //change months to int 
            string TempHolderString; //used for temporary storage for strings
            string TimeStampString; //used for temporary storage for strings
            double TempHolderDoub; //used for temporary storage for double
            double TimeStampDoub; //used for temporary storage for double
            int[] PositionHolder = new int[11];//used to store the max values for all corrisponding values

            for (int y = 0; y < 10; y++)
            {
                //checks positions 1, 2, 6 and 7
                if (y == 1 || y == 2 || y == 6 || y == 7)
                {
                    TempHolderDoub = Convert.ToDouble(Fileholder[y, 0]); //stores the max vales for position choosen 
                    TimeStampDoub = Convert.ToDouble(Fileholder[10, 0]); //stores the max vales for TimeStamp choosen 
                    PositionHolder[y] = 0;
                    //assigns correct values to tempholders
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (TempHolderDoub == Convert.ToDouble(Fileholder[y, 1 + i]))
                        {
                            if (TimeStampDoub < Convert.ToDouble(Fileholder[10, 1 + i]))
                            {
                                TempHolderDoub = Convert.ToDouble(Fileholder[y, 1 + i]); //stores the max vales for position choosen 
                                TimeStampDoub = Convert.ToDouble(Fileholder[10, 1 + i]); //stores the max vales for TimeStamp choosen 
                                PositionHolder[y] = 1 + i;
                            }
                        }
                        else if (Convert.ToDouble(Fileholder[y, 1 + i])> Convert.ToDouble(TempHolderDoub)) // checks to see if first element is bigger 
                        {
                            TempHolderDoub = Convert.ToDouble(Fileholder[y, 1 + i]); //stores the max vales for position choosen 
                            TimeStampDoub = Convert.ToDouble(Fileholder[10, 1 + i]); //stores the max vales for TimeStamp choosen
                            PositionHolder[y] = 1 + i;
                        }
                    }
                }
                //checks all the rest of the positions 
                else
                {
                    TempHolderString = Fileholder[y, 0]; //stores the max vales for position choosen 
                    TimeStampString = Fileholder[10, 0]; //stores the max vales for TimeStamp choosen
                    PositionHolder[y] = 0;
                    //assigns correct values to tempholders
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (TempHolderString == Fileholder[y, 1 + i])
                        {
                            if (0 > (TimeStampString.CompareTo(Fileholder[10, 1 + i])))
                            {
                                TempHolderString = Fileholder[y, 1 + i];//stores the max vales for position choosen 
                                TimeStampString = Fileholder[10, 1 + i]; //stores the max vales for TimeStamp choosen
                                PositionHolder[y] = 1 + i;
                            }
                        }
                        else if (0 < (Fileholder[y, 1 + i].CompareTo(TempHolderString)))
                        {
                            TempHolderString = Fileholder[y, 1 + i];//stores the max vales for position choosen 
                            TimeStampString = Fileholder[10, 1 + i]; //stores the max vales for TimeStamp choosen
                            PositionHolder[y] = 1 + i;
                        }
                    }
                }
            }
            Class1.ChangeIntToMonth(ref Fileholder, Size); //chanage int to months
            string[,] Output = new string[11,11];
            for(int i=0;i<11;i++)
            {
                Console.WriteLine(PositionHolder[i]);
                for(int y=0;y<11;y++)
                {
                    Output[y, i] = Fileholder[y, PositionHolder[i]];
                }   
            }
            Class1.SendToHTML(Output, 11);
        }

        public static void FindMinData(string[,] Fileholder, int Size)
        {
            Class1.ChangeMonthsToInt(ref Fileholder, Size, 1);
            string TempHolderString; //used for temporary storage for strings
            string TimeStampString; //used for temporary storage for strings
            double TempHolderDoub; //used for temporary storage for double
            double TimeStampDoub; //used for temporary storage for double
            int[] PositionHolder = new int[11];//used to store the max values for all corrisponding values
            for (int y = 0; y < 10; y++)
            {
                //checks positions 1, 2, 6 and 7
                if (y == 1 || y == 2 || y == 6 || y == 7)
                {
                    TempHolderDoub = Convert.ToDouble(Fileholder[y, 0]);//stores the max vales for position choosen
                    TimeStampDoub = Convert.ToDouble(Fileholder[10, 0]);//stores the max vales for TimeStamp choosen 
                    PositionHolder[y] = 0;
                    //assigns correct values to tempholders
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (TempHolderDoub == Convert.ToDouble(Fileholder[y, 1 + i]))
                        {
                            if (TimeStampDoub > Convert.ToDouble(Fileholder[10, 1 + i]))
                            {
                                TempHolderDoub = Convert.ToDouble(Fileholder[y, 1 + i]); //stores the max vales for position choosen 
                                TimeStampDoub = Convert.ToDouble(Fileholder[10, 1 + i]); //stores the max vales for TimeStamp choosen 
                                PositionHolder[y] = 1 + i;
                            }
                        }
                        else if (Convert.ToDouble(Fileholder[y, 1 + i]) < Convert.ToDouble(TempHolderDoub)) // checks to see if first element is bigger 
                        {
                            TempHolderDoub = Convert.ToDouble(Fileholder[y, 1 + i]); //stores the max vales for position choosen 
                            TimeStampDoub = Convert.ToDouble(Fileholder[10, 1 + i]); //stores the max vales for TimeStamp choosen
                            PositionHolder[y] = 1 + i;
                        }
                    }
                }
                else
                {
                    TempHolderString = Fileholder[y, 0]; //stores the max vales for position choosen
                    TimeStampString = Fileholder[10, 0]; //stores the max vales for TimeStamp choosen
                    PositionHolder[y] = 0;
                    //assigns correct values to tempholders
                    for (int i = 0; i < Size - 1; i++)
                    {
                        if (TempHolderString == Fileholder[y, 1 + i])
                        {
                            if (0 < (TimeStampString.CompareTo(Fileholder[10, 1 + i])))
                            {
                                TempHolderString = Fileholder[y, 1 + i];//stores the max vales for position choosen 
                                TimeStampString = Fileholder[10, 1 + i]; //stores the max vales for TimeStamp choosen
                                PositionHolder[y] = 1 + i;
                            }
                        }
                        else if (0 > (Fileholder[y, 1 + i].CompareTo(TempHolderString)))
                        {
                            TempHolderString = Fileholder[y, 1 + i]; //stores the max vales for position choosen 
                            TimeStampString = Fileholder[10, 1 + i]; //stores the max vales for TimeStamp choosen
                            PositionHolder[y] = 1 + i;
                        }
                    }
                }
            }
            Class1.ChangeIntToMonth(ref Fileholder, Size); //chanage int to months
            string[,] Output = new string[11, 11];
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(PositionHolder[i]);
                for (int y = 0; y < 11; y++)
                {
                    Output[y, i] = Fileholder[y, PositionHolder[i]];
                }
            }
            Class1.SendToHTML(Output, 11);
        }
    }
}
