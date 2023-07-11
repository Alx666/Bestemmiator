using System;

namespace Bestemmiator.Grammar
{
    class Element : ICloneable
    {
        public string Text { get; protected set; }
        public Element(string text)
        {
            Text = text;
        }

        public virtual object Clone()
        {
            return new Element(this.Text);
        }

        public virtual void Render()
        {
        }
    }
}
