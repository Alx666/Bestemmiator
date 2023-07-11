namespace Bestemmiator.Grammar
{
    abstract class GenderDependency : Element
    {
        public Gender Gender { get; private set; }

        public virtual void Set(Gender g)
        {
            Gender = g;
        }

        public GenderDependency(string text) : base(text)
        {
        }
    }
}
