<?php
/*
Kata: https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1
Kyu: 4

Details:

Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]
For better understanding, please follow the numbers of the next array consecutively:

array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
snail(array) #=> [1,2,3,4,5,6,7,8,9]

*/

function snail(array $arr): array {
    if(count($arr) < 1){
        return [];
    }
   
    $firstArr = array_shift($arr);
    $lastArr = isset($arr[1]) ? array_reverse( array_pop($arr)) : array();
    
    $pops = array();
    $shifts = array();

    foreach($arr as &$innerArr){
        $pops[] = array_pop($innerArr);
        $shifts[] = array_shift($innerArr);
    }

    return array_merge($firstArr,$pops,$lastArr,array_reverse($shifts), snail($arr));
}