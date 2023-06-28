using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BackTrackings {
    public class SodukoSolver {
        public SodukoSolver() {
            char[][] board2 = new char[][]{
            new char[]{'7','.','.','.','4','.','.','.','.'},
            new char[]{'.','.','.','8','6','5','.','.','.'},
            new char[]{'.','1','.','2','.','.','.','.','.'},
            new char[]{'.','.','.','.','.','9','.','.','.'},
            new char[]{'.','.','.','.','5','.','5','.','.'},
            new char[]{'.','.','.','.','.','.','.','.','.'},
            new char[]{'.','.','.','.','.','.','2','.','.'},
            new char[]{'.','.','.','.','.','.','.','.','.'},
            new char[]{'.','.','.','.','.','.','.','.','.'}};
                        char[][] board = new char[][]{
             new char[]{'5','3','4','6','7','8','9','1','2'}
            ,new char[]{'6','.','.','1','9','5','3','4','8'}
            ,new char[]{'.','9','8','.','.','.','.','6','.'}
            ,new char[]{'8','.','.','.','6','.','.','.','3'}
            ,new char[]{'4','.','.','8','.','3','.','.','1'}
            ,new char[]{'7','.','.','.','2','.','.','.','6'}
            ,new char[]{'.','6','.','.','.','.','2','8','.'}
            ,new char[]{'.','.','.','4','1','9','.','.','5'}
            ,new char[]{'.','.','.','.','8','.','.','7','9'}
            };
                        char[][] board3 = new char[][]{
            new char[]{'8','3','.','.','7','.','.','.','.'}
            ,new char[]{'6','.','.','1','9','5','.','.','.'}
            ,new char[]{'.','9','8','.','.','.','.','6','.'}
            ,new char[]{'8','.','.','.','6','.','.','.','3'}
            ,new char[]{'4','.','.','8','.','3','.','.','1'}
            ,new char[]{'7','.','.','.','2','.','.','.','6'}
            ,new char[]{'.','6','.','.','.','.','2','8','.'}
            ,new char[]{'.','.','.','4','1','9','.','.','5'}
            ,new char[]{'.','.','.','.','8','.','.','7','9'}
            };
                        char[][] b = new char[][]{
            new char[]{'5','3','4','6','7','8','9','1','2'},
            new char[]{'6','7','2','1','9','5','3','4','8'},
            new char[]{'1','9','8','3','4','2','5','6','7'},
            new char[]{'8','5','9','7','6','1','4','2','3'},
            new char[]{'4','2','6','8','5','3','7','9','1'},
            new char[]{'7','1','3','9','2','4','8','5','6'},
            new char[]{'9','6','1','5','3','.','2','8','4'},
            new char[]{'2','8','7','4','1','9','6','3','5'},
            new char[]{'3','4','.','2','8','6','1','.','9'}
            };
        }

        bool[,] visited = new bool[9, 9];
        int totalDots = 0;
        public void validSudoku(char[][] board) {

            for(int i = 0; i < board.Length; i++) {
                for(int j = 0; j < board[i].Length; j++) {
                    if(board[i][j] == '.') {
                        totalDots++;
                    }
                }
            }
            int count = 0;
            bool ans = false;
            for(int i = 0; i < board.Length; i++) {
                for(int j = 0; j < board[i].Length; j++) {
                    if(board[i][j] == '.' && !visited[i, j]) {
                        dfs(board, i, j, count, ref ans);
                    }
                }
            }
        }
        private void dfs(char[][] board, int r, int c, int count, ref bool IsAns) {
            if(r < 0 || c < 0 || r >= board.Length || c >= board.Length) return;
            if(totalDots == count) {
                IsAns = true;
                return;
            }
            else if(IsAns) return;
            if(!visited[r, c]) {

                visited[r, c] = true;
                if(board[r][c] == '.') {
                    for(int i = 1; i <= 9; i++) {
                        board[r][c] = (char)(i + '0');
                        if(!IsValidSudoku(board)) continue;
                        dfs(board, r - 1, c, count + 1, ref IsAns);
                        dfs(board, r + 1, c, count + 1, ref IsAns);
                        dfs(board, r, c - 1, count + 1, ref IsAns);
                        dfs(board, r, c + 1, count + 1, ref IsAns);

                    }
                    board[r][c] = '.';

                }
                visited[r, c] = false;
            }
        }
        private bool IsValidSudoku(char[][] board) {
            int len = board.Length;
            int r = 0; int c = 0;
            int x = len - 2;
            while(r <= x) {
                while(c <= x) {
                    bool IsValid = check3x3(r, c, board);
                    if(!IsValid) { return false; }
                    c = c + 3;
                }
                c = 0;
                r = r + 3;
            }
            return checkAllRows(board) && checkAllCols(board);
        }
        private bool check3x3(int r, int c, char[][] board) {
            HashSet<char> map = new HashSet<char>();
            int x = r + 3;
            int y = c + 3;
            for(int i = r; i < x; i++) {
                for(int j = c; j < y; j++) {
                    if(board[i][j] != '.') {
                        if(map.Contains(board[i][j])) {
                            return false;
                        }
                        map.Add(board[i][j]);
                    }
                }
            }
            return true;
        }
        private bool checkAllRows(char[][] board) {

            for(int i = 0; i < board.Length; i++) {
                HashSet<char> map = new HashSet<char>();
                int j = 0;
                while(j < board[0].Length) {
                    if(board[i][j] != '.') {
                        if(map.Contains(board[i][j])) {
                            return false;
                        }
                        map.Add(board[i][j]);
                    }
                    j++;
                }
            }
            return true;
        }
        private bool checkAllCols(char[][] board) {

            for(int i = 0; i < board[0].Length; i++) {
                HashSet<char> map = new HashSet<char>();
                int j = 0;
                while(j < board[0].Length) {
                    if(board[j][i] != '.') {
                        if(map.Contains(board[j][i])) {
                            return false;
                        }
                        map.Add(board[j][i]);
                    }
                    j++;
                }
            }
            return true;
        }
    }
}
