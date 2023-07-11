namespace Bestemmiator.Grammar
{
    class SubjectAttribute : GenderDependency
    {
        public override void Set(Gender g)
        {
            base.Set(g);

            //signor e
            //patron e
            //

            if (Gender == Gender.Male)
            {
                int index = Text.IndexOf('@') - 1;
                if (Text[index] == 'r')
                {
                    Text = Text.Replace('@', 'e');
                }
                else
                {
                    Text = Text.Replace('@', 'o');
                }
            }
            else
            {
                Text = Text.Replace('@', 'a');
            }


            if (g == Gender.Male || g == Gender)
                Text = g == Gender.Male ? Text.Replace('@', 'o') : Text.Replace('@', 'a');
        }

        public SubjectAttribute(string attribute) : base(attribute)
        {
        }

        public override string ToString()
        {
            return $"{Text} (Attribute {Gender})";
        }

        public override object Clone()
        {
            SubjectAttribute clone = new SubjectAttribute(this.Text);
            return clone;
        }

    }
}
