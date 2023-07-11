namespace Bestemmiator.Grammar
{
    class Subject : Element
    {
        public Gender Gender { get; private set; }
        public Subject(string name, Gender gender) : base(name)
        {
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"{Text} (Subject {Gender})";
        }

        public override object Clone()
        {
            return new Subject(this.Text, this.Gender);
        }

    }
}
