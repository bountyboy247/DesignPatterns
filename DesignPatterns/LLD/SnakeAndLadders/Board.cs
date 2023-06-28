

namespace DesignPatterns.LLD.SnakeAndLadders {
    public class Board {
        public Cell[][] cells;
        public Board(int boardSize, int numOfSnakes, int numOfLadders) {
            initializeCells(boardSize);
            addSnakesLadders(cells, numOfSnakes,numOfLadders);
        }

        private void addSnakesLadders(Cell[][] cells, int numOfSnakes, int numOfLadders) {
           while(numOfSnakes> 0) {
                Random random = new Random();
                int snakeHead = random.Next(1, cells.Length*cells.Length-1);
                int snakeTail = random.Next(1, cells.Length*cells.Length - 1);
                if(snakeTail >= snakeHead) continue;

                Jump snakeObj = new Jump(snakeHead, snakeTail);
                snakeObj.start = snakeHead;
                snakeObj.end = snakeTail;
                int[] cellPos = getCellPositions(snakeHead);
                cells[cellPos[0]][cellPos[1]].jump = snakeObj;

                numOfSnakes--;
            }
           while(numOfLadders> 0) {
                Random random = new Random();
                int ladderHead = random.Next(1, cells.Length*cells.Length - 1);
                int ladderTail = random.Next(1, cells.Length*cells.Length - 1);

                if(ladderHead >= ladderTail) continue;
                
                Jump ladderObj = new Jump(ladderHead, ladderTail);
           
                ladderObj.start = ladderHead;
                ladderObj.end = ladderTail;
                int[] cellPos = getCellPositions(ladderHead);
                Cell cell = cells[cellPos[0]][cellPos[1]];
                if(cell.jump != null) {
                    continue;
                }
                cells[cellPos[0]][cellPos[1]].jump = ladderObj;
               
                numOfLadders--;
            }
        }

        private void initializeCells(int boardSize) {
            cells = new Cell[boardSize][];
            for(int i = 0; i < boardSize; i++) {
                cells[i] = new Cell[boardSize];
                for(int j = 0; j < boardSize; j++) {
                    cells[i][j] = new Cell();
                }
            }
        }
        private int[] getCellPositions(int position) {
            int r = position/cells.Length;
            int c = position % cells.Length;

            return new int[] { r, c };
        }
    }
}
