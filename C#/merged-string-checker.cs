/*
Kata: https://www.codewars.com/kata/54c9fcad28ec4c6e680011aa
Kyu: 5

Details:

At a job interview, you are challenged to write an algorithm to check if a given string, s, can be formed from two other strings, part1 and part2.

The restriction is that the characters in part1 and part2 are in the same order as in s.

The interviewer gives you the following example and tells you to figure out the rest from the given test cases.

For example:

	'codewars' is a merge from 'cdw' and 'oears':

    s:  c o d e w a r s   = codewars
	part1:  c   d   w         = cdw
	part2:    o   e   a r s   = oears

*/


using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class StringMerger
{
	public static bool isMerge(string s, string part1, string part2)
	{
      string bothWords = part1 + part2;
      List<char> firstString = new List<char>();
      List<char> secondString = new List<char>();
  
      //populate firstString char list
      foreach(char c in part1)
              firstString.Add(c);
              
      //populate secondString char list        
      foreach(char c in part2)
              secondString.Add(c);        
              
       for(int i = 0; i < s.Length; i++)
       {
            for(int j = 0; j < firstString.Count; j++)
            {
                //the index of the char in firstString always has to be 0
                //even if the char list contains the char from s we're looking for
                //if it's not the first one (index 0) it means it's not in the correct order
                if(s[i] == firstString[j] && firstString.IndexOf(firstString[j]) == 0)
                  firstString.Remove(s[i]);
            }
            for(int k = 0; k < secondString.Count; k++)
            {
                 if(s[i] == secondString[k] && secondString.IndexOf(secondString[k]) == 0)
                  secondString.Remove(s[i]);
            }
            
       }
      
       //if the count of the string list is 0 it means we have used all the chars
       //if we used all chars, it means that s can be succesfully built from part1 & part2
       //we need an extra check to make sure the input is not null
       if((firstString.Count == 0 && secondString.Count == 0) && (bothWords.Length == s.Length))
       return true;
       else 
       return false;
	}
}