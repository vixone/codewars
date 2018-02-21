<?php
/*
Kata: https://www.codewars.com/kata/520446778469526ec0000001
Kyu: 4

Details:

Complete the function/method (depending on the language) to return true/True when its argument is an array that has the same nesting structure as the first array.

For example:

same_structure_as([1, 1, 1], [2, 2, 2]); // => true
same_structure_as([1, [1, 1]], [2, [2, 2]]); // => true
same_structure_as([1, [1, 1]], [[2, 2], 2]); // => false
same_structure_as([1, [1, 1]], [[2], 2]); // => false
same_structure_as([[[], []]], [[[], []]]); // => true
same_structure_as([[[], []]], [[1, 1]]); // => false
You may assume that all arrays passed in will be non-associative.

*/

function same_structure_as(array $a, array $b): bool {
   return check($a) === check($b);
}

function check($arr){
    $result = array();
    if(is_array($arr)){
        foreach($arr as $value){
             if(is_array($value)){
                 $result[] = check($value);
             } else {
                 $result[] = 'notarray';
             }
        }
    } else {
        $result[] = 'notarray';
    }
    return $result;
}