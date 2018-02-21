/*
Kata: https://www.codewars.com/kata/587136ba2eefcb92a9000027
Kyu: 5

Details:

Task
 	Your task is to make a simple class called SnakesLadders. The test cases will call the method play(die1, die2) independantly of the state of the game or the player turn. The variables die1 and die2 are the die thrown in a turn and are both integers between 1 and 6. The player will move the sum of die1 and die2.
	
Rules
 	1.  There are two players and both start off the board on square 0.

2.  Player 1 starts and alternates with player 2.

3.  You follow the numbers up the board in order 1=>100

4.  If the value of both die are the same then that player will have another go.

5.  Climb up ladders. The ladders on the game board allow you to move upwards and get ahead faster. If you land exactly on a square that shows an image of the bottom of a ladder, then you may move the player all the way up to the square at the top of the ladder. (even if you roll a double).

6.  Slide down snakes. Snakes move you back on the board because you have to slide down them. If you land exactly at the top of a snake, slide move the player all the way to the square at the bottom of the snake or chute. (even if you roll a double).

7.  Land exactly on the last square to win. The first person to reach the highest square on the board wins. But there's a twist! If you roll too high, your player "bounces" off the last square and moves back. You can only win by rolling the exact number needed to land on the last square. For example, if you are on square 98 and roll a five, move your game piece to 100 (two moves), then "bounce" back to 99, 98, 97 (three, four then five moves.)

Returns
 	Return Player n Wins!. Where n is winning player that has landed on square 100 without any remainding moves left.

	Return Game over! if a player has won and another player tries to play.

	Otherwise return Player n is on square x. Where n is the current player and x is the sqaure they are currently on.	

*/


using System;
using System.Collections.Generic;
namespace CodeWars
{
    class SnakesLadders
    {
    
        public int Player1Position, Player2Position = 0;
	      public int TurnCounter = 1; 
        public bool gameOver = false;
        
        //takes player number and position and returns a string 
        //indicating the player position or if the player wins
        public string ResultString(int player, int position){
         string x = "Player " + player + " is on square " + position;
         
           if(position == 100){
              x = "Player " + player + " Wins!";
              //switch the bool to true when the player wins
              //so that the rolling doesng continue
              gameOver = true;
           } 
           
         return x;
        }
        
        //check if the current position is currently in the Dictionary as a key
        //if found in dictionary the position is equivalated to the dictionary value of that key
        //thus 'moving' the player to the corresponding square
        private static int CheckPosition(int pos)
        {
            //shoutout to 1206549 for this simple beautiful solution
            //dictionary contains all snakes and ladders and their corresponding sqare
             Dictionary<int, int> obstacles = new Dictionary<int, int>()
             {
                 { 2,38 }, { 7,14 }, { 8,31 }, { 15,26 }, { 16,6 }, { 21,42 }, { 28,84 },
                 { 36,44 }, { 46,25 }, { 49,11 }, { 51,67 }, { 62,19 }, { 64,60 }, { 71,91 },
                 { 74,53 }, { 78,98 }, { 87,94 }, { 89,68 }, { 92,88 }, { 95,75 }, { 99,80 }
             };
            
            //if the dice roll is over 100, we 'move' the player back according to the roll
            //this needs to happen before the obstacle check
            if(pos > 100)
               pos = 100 - (pos - 100);
              
            //checks for obstacles  
            if (obstacles.ContainsKey(pos))
                pos = obstacles[pos];
            
			      return pos;
        }
    
        public string play (int dice1, int dice2)
        {
          //always check if game is over before rolling again.
          if (gameOver)
             return "Game over!";

          int sum = dice1 + dice2;
          
          //checks if the turn number is Odd
          //if turn is odd it means it's First Player's turn
          if(TurnCounter % 2 != 0)
          {
            //add the dice roll to the player position
            Player1Position += sum;
            
            //checks for obstacles and moves player accordingly
            Player1Position = CheckPosition(Player1Position);
          
            //we only increment the turn if the dices are not equal
            
            if(dice1 != dice2) {
            TurnCounter++;
            return ResultString(1, Player1Position);
            }
            //if the dices are equal the player needs to roll again 
            //so we don't increment the turn
            else return ResultString(1, Player1Position);
                      
          } 
          else
          {
            Player2Position += sum;
            Player2Position = CheckPosition(Player2Position);
            
            
            if(dice1 != dice2){
            TurnCounter++;
            return ResultString(2,Player2Position);
            } 
            else return ResultString(2, Player2Position);
          }
    } 
  }
}