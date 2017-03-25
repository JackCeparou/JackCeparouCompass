namespace Turbo.Plugins.Jack.Extensions
{
    using Turbo.Plugins.Default;

    public static class WorldDecoratorCollectionExtensions
    {
        public static void Add(this WorldDecoratorCollection collection, params IWorldDecorator[] decorators)
        {
            collection.Decorators.AddRange(decorators);
        }
    }
}