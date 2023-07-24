using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.Trees {
    public class LFUCache {
        class Node {
            public int key;
            public int value;
            public int count;
            public Node next;
            public Node prev;

            public Node(int key, int value, int count)
            {
                this.key = key;
                this.value = value;
                this.count = count;
                next = null;
                prev = null;
            }
          
        }

        int cap = 0;
        private Dictionary<int, Node> cache;
        private SortedDictionary<int , Node > countMap;
        public LFUCache(int capacity) {

            cap = capacity;
            cache = new Dictionary<int, Node>();
            countMap = new SortedDictionary<int, Node>();
        }

        public int Get(int key) {
            if(cache.ContainsKey(key)) {
                Node rem = cache[key];
                cache.Remove(key);
                Node remNext = rem.next;
                Node remPrev = rem.prev;

                if(remNext != null) {
                    remNext.prev = remPrev;
                }
                if(remPrev != null) {
                    remPrev.next = remNext;
                }

                rem.count += 1;
                Node newNode = new Node(key, rem.value, rem.count);
                if(countMap.ContainsKey(rem.count)) {
                    Node remFromCount = countMap[rem.count];
                    newNode.next = remFromCount;
                    remFromCount.prev = newNode;
                }
                cache[key] = newNode;
                countMap[rem.count] = newNode;

                return rem.value;
            }
            return -1;
        }

        public void Put(int key, int value) {
            if(cache.ContainsKey(key)) {
                Node n1 = cache[key];
                n1.value = value;
               

                Node nextNode = n1.next;
                Node prevNode = n1.prev;
                if(nextNode != null) {
                    nextNode.prev = prevNode;
                }
                if(prevNode != null) {
                    prevNode.next = nextNode;
                }
                cache.Remove(key);
                n1.count += 1;
                if(countMap.ContainsKey(n1.count)) {
                    Node cNode = countMap[n1.count];    
                    n1.next = cNode;
                    cNode.prev = n1;
                }
                n1.next = null;
                n1.prev = null;
                cache[key] = n1;
                countMap[n1.count] = n1;

            }
            else if(cache.Count == cap) {
                //evict from least frequently used
                Node n1 = countMap.First().Value;
                cache.Remove(n1.key );
                //remove this from the countMap
                Node n1Next = n1.next;
                Node n1Prev = n1.prev;

                if(n1Next != null) {
                    n1Next.prev = n1Prev;
                }
                if(n1Prev != null) {
                    n1Prev.next = n1Next;
                }
       
                Node nn = countMap[n1.count];
                if(nn.next == null && nn.prev == null) countMap.Remove(n1.count);

                Node newNode = new Node(key, value, 1);

                cache[key] = newNode;
                if(countMap.ContainsKey(1)) {
                    //remove from the tail
                    Node cNode = countMap[1];
                    newNode.next = cNode;
                    cNode.prev = newNode;

                }
                countMap[1] = newNode;

            }
            else {
                Node n1 = new Node(key, value, 1);
                cache[key] = n1;
                if(countMap.ContainsKey(1)) {
                    Node cNode = countMap[1];
                    n1.next = cNode;
                    cNode.prev = n1;
                  
                }
                countMap[1] = n1;
                
            }
        }
    }
}
