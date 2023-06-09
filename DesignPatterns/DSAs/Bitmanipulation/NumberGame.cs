using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.Bitmanipulation
{
    public class NumberGame
    {
        public NumberGame()
        {
            ulong num = 1UL << 63;
            string ans = counterGame(5);
        } 
        public string counterGame(long n)
        {
            ulong num = (ulong)n;
            int turn = 0;
            while (num != 1)
            {
                int start = 0;
                int end = 127;
                int mid = 0;
                while(start <= end)
                {
                    mid = (start + end) / 2;
                    ulong curr = (1UL << mid);
                    if(num < curr)
                    {
                        end = mid -1;
                    }
                    else if(num >= curr)
                    {
                        start = mid + 1;
                    }
                }
                if( num > (1UL << end))
                {
                    num = (num - (1UL << end));
                }
                else if(num == ( 1UL << end))
                {
                    num = num / 2;
                }

                if (num == 1 && turn % 2 == 0)
                {
                    return "Louise";
                }
                else if (num == 1 && turn % 2 != 0)
                {
                    return "Richard";
                }


                turn++;
            }
            return "";
        }
    }
}
