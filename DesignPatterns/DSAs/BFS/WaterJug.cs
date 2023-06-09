using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.BFS
{
    public class WaterJug
    {
        public WaterJug()
        {
            int j1 = 3;
            int j2 = 5;
            int t = 4;

            var ans = CanMeasureWater(j1, j2, t);   
        }
        class JugCap
        {
            public int vol1;
            public int vol2;
            public List<string> Solution;
            public JugCap(int v1, int v2, List<string> s1)
            {
                vol1 = v1;
                vol2 = v2;
                Solution = s1;
            }
        }
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            HashSet<string> map = new HashSet<string>();

            Queue<JugCap> q = new Queue<JugCap>();
            //initially we have empty jugs
            JugCap jc = new JugCap(jug1Capacity, jug2Capacity,new List<string>());
            q.Enqueue(jc);
            while (q.Count > 0)
            {
                JugCap rem = q.Dequeue();
                int v1 = rem.vol1;
                int v2 = rem.vol2;
                List<string> option = rem.Solution;   
                if (v1 == targetCapacity ||
                    v2 == targetCapacity ||
                    v1 + v2 == targetCapacity
                    )
                {
                    //stop
                    option.Add("" + "J1-" + v1 + "-J2-" + v2);
                    int x = 90;
                    return true;
                }
                string key = "" +"J1-"+v1+"-J2-" + v2;
                if (map.Contains(key)) continue;
                map.Add(key);
                //Operation 1;
                //Fill jug1
                List<string> s1 = new List<string>(option);
                s1.Add(key);
                q.Enqueue(new JugCap(jug1Capacity, v2,s1));
                //Fill jug2
                List<string> s2 = new List<string>(option);
                s2.Add(key);
                q.Enqueue(new JugCap(v1, jug2Capacity,s2));

                //This is operation 2
                //empty jug1
                List<string> s3 = new List<string>(option);
                s3.Add(key);
                q.Enqueue(new JugCap(0, v2,s3));
                //empty jug2
                List<string> s4 = new List<string>(option);
                s4.Add(key);
                q.Enqueue(new JugCap(v1, 0,s4));
                //Operation 3
                //Pour water from jug1 to jug2
                if (v2 < jug2Capacity && v1 > 0)
                {
                    int diff = jug2Capacity - v2;
                    if (v1 >= diff)
                    {
                        int remV1 = v1 - diff;
                        List<string> s5 = new List<string>(option);
                        s5.Add(key);
                        q.Enqueue(new JugCap(remV1, jug2Capacity,s5));
                    }
                    else
                    {
                        List<string> s6 = new List<string>(option);
                        s6.Add(key);
                        q.Enqueue(new JugCap(0, v2 + v1,s6));
                    }
                }
                if (v1 < jug1Capacity && v2 > 0)
                {
                    int diff = jug1Capacity - v1;
                    if (v2 >= diff)
                    {
                        int remV2 = v2 - diff;
                        List<string> s7 = new List<string>(option);
                        s7.Add(key);
                        q.Enqueue(new JugCap(jug1Capacity, remV2,s7));
                    }
                    else
                    {
                        List<string> s8 = new List<string>(option);
                        s8.Add(key);
                        q.Enqueue(new JugCap(v2 + v1, 0,s8));
                    }
                }

            }

            return false;
        }
    }
}
