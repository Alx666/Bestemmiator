namespace Bestemmiator.Grammar
{
    class Conjunction : Element
    {
        public Conjunction(string text) : base(text)
        {

        }
        public override object Clone()
        {
            return new Conjunction(this.Text);
        }

        public override string ToString()
        {
            return $"{Text} (Conjunction)";
        }
    }
}
