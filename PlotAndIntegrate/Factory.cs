using System;

namespace PlotAndIntegrate
{
    public class Factory<I> where I : class
    {
        public string Description { get; init; }

        public Func<I> NewItemFunction { get; init; }

        public Factory(Func<I> newItemFunction, string description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            NewItemFunction = newItemFunction ?? throw new ArgumentNullException(nameof(newItemFunction));
        }

        public I CreateNew()
        {
            return NewItemFunction();
        }

        public override string ToString()
        {
            return Description;
        }
    }
}