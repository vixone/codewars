/*
Kata: https://www.codewars.com/kata/58f5c63f1e26ecda7e000029
Kyu: 6

Details:

Task

	In this simple Kata your task is to create a function that turns a string into a Mexican Wave. You will be passed a string
	and you must return that string in an array where an uppercase letter is a person standing up.
 
Rules
 	1.  The input string will always be lower case but maybe empty.
	2.  If the character in the string is whitespace then pass over it as if it was an empty seat.
	
Example
	wave("hello") => ["Hello", "hEllo", "heLlo", "helLo", "hellO"]
 

*/

using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    public class Kata
    {
        public List<string> wave(string str)
        {  
            List<string> waveList = new List<string>();
           
            for(int i = 0; i < str.Length; i++)
            {
              //create a temporary string
              string tempStr;
              
              //if space is found skip over it
              if (str[i] == ' ') continue;
              
              //assign char of index i to temporary string + 
              //a substring formed of rest of string
              //this only works for fist letter
              tempStr = char.ToUpper(str[i]) + str.Substring(i+1);
              
              //for the rest of the letters we must add
              //another substring formed of all the letters 
              //until the char of index i
              if(i > 0)
              tempStr = str.Substring(0, i) + char.ToUpper(str[i]) + str.Substring(i+1);
               
              //add our temp string to the string list
              waveList.Add(tempStr);
            }
     
            return waveList;
        }
    }
}