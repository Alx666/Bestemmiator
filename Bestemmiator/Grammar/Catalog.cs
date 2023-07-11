using Bestemmiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bestemmiator.Grammar
{
    class Catalog
    {
        private static Random rand = new Random();
        private Queue<Element> elements;
        public bool Reusable { get; set; }
        public Catalog()
        {
            elements = new Queue<Element>();
            Reusable = true;
        }

        public Catalog(string[] names)
        {
            List<Element> tmp = names.Select(x => new Element(x)).ToList();
            tmp.Shuffle();
            elements = new Queue<Element>(tmp);
        }

        public void Add(Element e)
        {
            elements.Enqueue(e);
        }

        public void Shuffle()
        {
            List<Element> tmp = elements.ToList();
            tmp.Shuffle();
            elements = new Queue<Element>(tmp);
        }

        public Element Get()
        {
            if (Reusable)
            {
                var one = elements.Dequeue();
                Element clone = one.Clone() as Element;
                elements.Enqueue(one);
                return clone;
            }
            else
            {
                return elements.Dequeue();
            }

        }
    }
}
