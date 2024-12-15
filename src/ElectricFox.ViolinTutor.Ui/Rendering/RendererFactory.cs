using ElectricFox.ViolinTutor.Code;

namespace ElectricFox.ViolinTutor.Ui.Rendering
{
    public static class RendererFactory
    {
        private static readonly Dictionary<Type, object> _renderers = new();

        // Method to register renderers
        public static void RegisterRenderer<T>(IRenderer<T> renderer)
            where T : NotationItem
        {
            _renderers[typeof(T)] = renderer ?? throw new ArgumentNullException(nameof(renderer));
        }

        // Method to get the correct renderer for a given NotationItem instance
        public static IRenderer<NotationItem> GetRenderer(NotationItem item)
        {
            var itemType = item.GetType(); // Get the runtime type of the item
            if (_renderers.TryGetValue(itemType, out var renderer))
            {
                // Wrap the renderer into an adapter to cast it as IRenderer<NotationItem>
                return new AdapterRenderer(itemType, renderer);
            }

            throw new InvalidOperationException($"No renderer registered for type {itemType.FullName}");
        }

        // Adapter class to unify the renderer interface
        private class AdapterRenderer : IRenderer<NotationItem>
        {
            private readonly Type _itemType;
            private readonly object _renderer;

            public AdapterRenderer(Type itemType, object renderer)
            {
                _itemType = itemType;
                _renderer = renderer;
            }

            public Rectangle Render(Graphics g, Point p, NotationItem item, Melody melody)
            {
                if (!_itemType.IsInstanceOfType(item))
                    throw new ArgumentException($"Item must be of type {_itemType}", nameof(item));

                // Use reflection to invoke the renderer's Render method
                var method = _renderer.GetType().GetMethod(nameof(IRenderer<NotationItem>.Render));
                if (method == null)
                    throw new InvalidOperationException($"Renderer for {_itemType} is not properly implemented.");

                // Invoke the method dynamically
                return (Rectangle)method.Invoke(_renderer, [g, p, item, melody]);
            }
        }
    }
}
