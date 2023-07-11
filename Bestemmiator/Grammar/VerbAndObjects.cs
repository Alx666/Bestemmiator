namespace Bestemmiator.Grammar
{
    class VerbAndObjects : GenderDependency
    {
        public Catalog Objects { get; private set; }
        public VerbAndObjects(string name, params string[] objects) : this(name)
        {
            Objects = new Catalog(objects);
        }

        public VerbAndObjects(string name) : base(name)
        {

        }

        public override void Set(Gender g)
        {
            base.Set(g);

            if (g == Gender.Male || g == Gender)
                Text = g == Gender.Male ? Text.Replace('@', 'o') : Text.Replace('@', 'a');
        }

        public override object Clone()
        {
            VerbAndObjects clone = new VerbAndObjects(this.Text);
            clone.Objects = this.Objects;
            return clone;
        }

        public override void Render()
        {
            base.Render();
            this.Text += " " + Objects.Get().Text;
        }

        public override string ToString()
        {
            return $"{Text} (VerbAndObject)";
        }
    }
}
