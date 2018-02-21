<?php
/*
Kata: https://www.codewars.com/kata/587731fda577b3d1b0001196
Kyu: 6

Write simple .camelCase method (camel_case function in PHP or CamelCase in C#) for strings. All words must have their first letter capitalized without spaces.

For instance:

camel_case("hello case"); // => "HelloCase"
camel_case("camel case word"); // => "CamelCaseWord"

*/


function camel_case($s) {

  // check for empty strings
  if(strlen($s) == 0) {
     return;
  }
  
  // explode and capitalize every word in array
  $exploded = explode(" ", $s);
  foreach($exploded as &$value) {
      $value = ucfirst($value);
  }
  
  // implode and return
  $formatted = implode("",$exploded);
  
  return $formatted;
}