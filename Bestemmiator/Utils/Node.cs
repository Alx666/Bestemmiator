using System;
using System.Collections.Generic;

namespace Bestemmiator.Utils
{
    class Node<T> where T : new()
    {
        #region static stuff

        private static Random rand;

        static Node()
        {
            rand = new Random();
        }

        #endregion

        private List<Arc> neighbours;

        public T Value { get; private set; }
        public bool IsBreakable { get; private set; }

        public Node(bool breakable)
        {
            neighbours = new List<Arc>();
            Value = new T();
            IsBreakable = breakable;
        }



        public void Add(Node<T> node, float weight) => neighbours.Add(new Arc(node, weight));


        public Node<T> GetNextWeighted()
        {
            float f          = (float)rand.NextDouble();
            float lowerRange = 0f;
            float upperRange = 0f;

            for (int i = 0; i < neighbours.Count; i++)
            {
                Arc current = neighbours[i];

                upperRange  += current.weight;

                if (f > lowerRange && f <= upperRange)
                {
                    return current.node;
                }
                else
                {
                    lowerRange = upperRange;                    
                }
            }

            throw new ApplicationException("Invalid Weight");
        }

        public Node<T> GetNextRandom()
        {
            return neighbours[rand.Next(0, neighbours.Count)].node;
        }


        private class Arc
        {
            public Arc(Node<T> node, float weight)
            {
                this.node   = node;
                this.weight = weight;
            }

            public Node<T> node;
            public float weight;
        }
    }
}
