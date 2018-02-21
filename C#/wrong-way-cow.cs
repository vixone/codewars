/*
Kata: https://www.codewars.com/kata/57d7536d950d8474f6000a06
Kyu: 5

Details:

Have you ever noticed that cows in a field are always facing in the same direction?

Reference: http://bfy.tw/7fgf

Well.... not quite always.

One stubborn cow wants to be different from the rest of the herd - it's that damn Wrong-Way Cow!

Task
Given a field of cows find which one is the Wrong-Way Cow and return her position.

Notes:

There are always at least 3 cows in a herd
There is only 1 Wrong-Way Cow!
Fields are rectangular
The cow position is zero-based [x,y] of her head (i.e. the letter c)
Examples
Ex1

cow.cow.cow.cow.cow
cow.cow.cow.cow.cow
cow.woc.cow.cow.cow
cow.cow.cow.cow.cow
Answer: [6,2]

Ex2

c..........
o...c......
w...o.c....
....w.o....
......w.cow
Answer: [8,4]

Notes
The test cases will NOT test any situations where there are "imaginary" cows, so your solution does not need to worry about such things!

To explain - Yes, I recognise that there are certain configurations where an "imaginary" cow may appear that in fact is just made of three other "real" cows. In the following field you can see there are 4 real cows (3 are facing south and 1 is facing north). There are also 2 imaginary cows (facing east and west).

But such a field will never be tested by this Kata.

...w...
..cow..
.woco..
.ow.c..
.c.....


*/

using System.Collections.Generic;
public class Dinglemouse
        {

            public static int[] FindWrongWayCow(char[][] field)
            {
               
                int[] WrongWayCowIndex = new int[2];
                int rows = field.Length;

                var HorizontalCowList = new List<KeyValuePair<int, int>>();
                var HorizontalWocList = new List<KeyValuePair<int, int>>();
                var VerticalCowList = new List<KeyValuePair<int, int>>();
                var VerticalWocList = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < field[i].Length; j++)
                    {
                        if (j + 2 < field[i].Length && field[i][j] == 'c' && field[i][j + 1] == 'o' && field[i][j + 2] == 'w')
                        {
                            HorizontalCowList.Add(new KeyValuePair<int, int>(i, j));
                        }
                        else if (j + 2 < field[i].Length && field[i][j] == 'w' && field[i][j + 1] == 'o' && field[i][j + 2] == 'c')
                        {
                            HorizontalWocList.Add(new KeyValuePair<int, int>(i, j + 2));
                        }
                        else if (i + 2 < rows && field[i][j] == 'c' && field[i + 1][j] == 'o' && field[i + 2][j] == 'w')
                        {
                            VerticalCowList.Add(new KeyValuePair<int, int>(i, j));

                        }
                        else if (i + 2 < rows && field[i][j] == 'w' && field[i + 1][j] == 'o' && field[i + 2][j] == 'c')
                        {
                            VerticalWocList.Add(new KeyValuePair<int, int>(i+2, j));

                        }
                    }
                }

             
                if (HorizontalCowList.Count == 1)
                {
                    WrongWayCowIndex[0] = HorizontalCowList[0].Value;
                    WrongWayCowIndex[1] = HorizontalCowList[0].Key;
                }
                else if (HorizontalWocList.Count == 1)
                {
                    WrongWayCowIndex[0] = HorizontalWocList[0].Value;
                    WrongWayCowIndex[1] = HorizontalWocList[0].Key;
                }
                else if (VerticalCowList.Count == 1)
                {
                    WrongWayCowIndex[0] = VerticalCowList[0].Value;
                    WrongWayCowIndex[1] = VerticalCowList[0].Key;
                }
                else if (VerticalWocList.Count == 1)
                {
                    WrongWayCowIndex[0] = VerticalWocList[0].Value;
                    WrongWayCowIndex[1] = VerticalWocList[0].Key;
                }
                else
                {
                    WrongWayCowIndex[0] = 99;
                    WrongWayCowIndex[1] = 99;
                }

             
                return WrongWayCowIndex;

            }
        }