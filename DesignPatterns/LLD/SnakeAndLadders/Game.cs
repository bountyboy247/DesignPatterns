using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.LLD.SnakeAndLadders {
    public class Game {
        public Board board;
        public Queue<Player> players = new Queue<Player>();
        public Dice dice;
        Player winner;
        public Game() {
            initializeGame();
        }

        private void initializeGame() {
            addPlayers();
            dice = new Dice(diceCount:1);
            winner = null;
            board = new Board(boardSize: 10, numOfSnakes: 6, numOfLadders:5);
        }

        private void addPlayers() {
            Player p1 = new Player(iD: "p1", currentPosition: 0);
            Player p2 = new Player(iD: "p2", currentPosition: 0);
            players.Enqueue(p1);
            players.Enqueue(p2);
        }

        public void startGame() {
            while(winner == null) {
                //check whose turn is it
                Player playerTurn = findPlayerTurn();
                Console.WriteLine($"Player turn is {playerTurn.ID} and current position is {playerTurn.CurrentPosition}");

                //roll the dice
                int diceNumber = dice.rollDice();

                //get the new position
                int playerPosition = playerTurn.CurrentPosition + diceNumber;
                playerPosition = jumpCheck(playerPosition);
                playerTurn.CurrentPosition = playerPosition;

                Console.WriteLine($"Player {playerTurn.ID} new position is {playerPosition}");

                //check for winning condition
                if(playerPosition >= board.cells.Length * board.cells.Length - 1) {
                    winner = playerTurn;
                }
            }
            Console.WriteLine("Winner is player " + winner.ID);
        }

        private int jumpCheck(int playerPosition) {
            if(playerPosition > (board.cells.Length * board.cells.Length - 1)) 
                return playerPosition;
            int r = playerPosition / (board.cells.Length);
            int c = playerPosition % (board.cells.Length );
            Cell cell = board.cells[r][c];
            if(cell.jump != null && cell.jump.start == playerPosition) {
                string jumpBy = (cell.jump.start < cell.jump.end) ? "ladder" : "snake";
                Console.WriteLine("jump done by " + jumpBy);
                playerPosition = cell.jump.end;
            }

            return playerPosition;
        }

        private Player findPlayerTurn() {
            Player player = players.Dequeue();
            players.Enqueue(player);
            return player;
        }
    }

}
