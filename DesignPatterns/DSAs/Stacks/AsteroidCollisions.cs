using DesignPatterns.LLD.BookMyShow.Models;
using DesignPatterns.LLD.SnakeAndLadders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DesignPatterns.DSAs.Stacks {
    public class AsteroidCollisions {

        //We are given an array asteroids of integers representing asteroids in a row.
        //For each asteroid, the absolute value represents its size, and the sign represents
        //its direction
        //(positive meaning right, negative meaning left). Each asteroid moves at the same speed.
        //Find out the state of the asteroids after all collisions.If two asteroids meet, the smaller
        //one will explode.If both are the same size, both will explode.Two asteroids moving in 
        //the same direction will never meet.

        public AsteroidCollisions() {
            int[] ast = new int[] { 46, -36, 3, 39, 20, 10, -33, 35, 4, -26, -37, 27 };
            int[] testCase2 = new int[] { 46, -36, 3, 39, 20, 10, -33, 35, 4, -26, -37, 27, -50, -23, 48, 5, -1, 29, -34, 34, 11, 22, 8, 41, -20, -10, 17, 35, -14, -9, 3, 12, -13, -47, 23, -39, 25,
                -43, -2, 26, -26, -42, -5, -4, 34, 3, 25, 20, 27, -6 };
            var ans = AsteroidCollision(ast);
            var ans2 = AsteroidCollision(testCase2);
      
        }
        //gives direction of asteroid
        //returns L => Left, or R => right direction
        private char getDirection(int x) {
            return x < 0 ? 'L' : 'R';
        }
        public int[] AsteroidCollision(int[] asteroids) {
            Stack<(int mag, char dir)> st = new Stack<(int mag, char dir)>();
            for(int i = 0; i < asteroids.Length; i++) {
                int mag = Math.Abs(asteroids[i]);
                char dir = getDirection(asteroids[i]);
                if(st.Count == 0) {
                    st.Push((mag, dir));
                }
                else {
                    //check top of stack asteroids
                    int magPeek = st.Peek().mag;
                    char dirPeek = st.Peek().dir;
                    //check condition of direction
                    //both traveling left or both right
                    //also one traveling left and one traveling right won't ever meet
                    if((dirPeek == 'L' && dir == 'L') ||
                       (dirPeek == 'R' && dir == 'R') ||
                       (dirPeek == 'L' && dir == 'R')) {
                        st.Push((mag, dir));
                    }
                    //this is where previous asteroid is traveling right and 
                    //current asteroid is traveling left
                    //so they will meet 
                    else if(dirPeek == 'R' && dir == 'L') {
                        //if same magnitude they will explode
                        if(mag == magPeek)
                            st.Pop();
                        else if(mag > magPeek) {
                            st.Pop();
                            st.Push((mag, dir));
                            while(st.Count > 1) {
                                //check only two conditions
                                mag = st.Peek().mag;
                                dir = st.Peek().dir;
                                st.Pop();
                                magPeek = st.Peek().mag;
                                dirPeek = st.Peek().dir;
                                if((dirPeek == 'L' && dir == 'L') ||
                                   (dirPeek == 'R' && dir == 'R') ||
                                   (dirPeek == 'L' && dir == 'R')) {
                                    st.Push((mag, dir));
                                    break;
                                }
                                else
                                    if(mag == magPeek) {
                                    st.Pop();
                                    break;
                                }
                                else if(mag > magPeek) {
                                    st.Pop();
                                    st.Push((mag, dir));
                                }
                                else break;
                            }
                        }
                    }
                }
            }
        int[] ans = new int[st.Count];
        int j = ans.Length - 1;
            while(st.Count > 0) {
                ans[j] = st.Peek().dir == 'L' ? -1 * st.Peek().mag : st.Peek().mag;
                st.Pop();
                j--;
            }
            return ans;
        }
    }
}
