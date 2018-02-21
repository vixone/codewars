/*
Kata: https://www.codewars.com/kata/5324945e2ece5e1f32000370
Kyu: 4

Details:

Given the string representations of two integers, return the string representation of the sum of those integers.

For example:

sumStrings('1','2') // => '3'
A string representation of an integer will contain no characters besides the ten numerals "0" to "9".

*/

using System;
using System.Numerics;
public static class Kata
{
    public static string sumStrings(string a, string b)
    {
    
      if (String.IsNullOrEmpty(a))
      a = "0";
      
      if(String.IsNullOrEmpty(b))
      b = "0";
      
      
      BigInteger x = BigInteger.Parse(a);
      BigInteger y = BigInteger.Parse(b);
      BigInteger sum = x + y;
      return sum.ToString();
      
        
    }
}