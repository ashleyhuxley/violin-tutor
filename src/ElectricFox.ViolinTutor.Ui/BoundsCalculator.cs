namespace ElectricFox.ViolinTutor.Ui
{
    public class BoundsCalculator
    {
        private bool _isInitialized = false;
        private int _minX = int.MaxValue;
        private int _minY = int.MaxValue;
        private int _maxX = int.MinValue;
        private int _maxY = int.MinValue;

        public Rectangle Bounds
        {
            get
            {
                if (!_isInitialized) return Rectangle.Empty;
                return new Rectangle(_minX, _minY, _maxX - _minX, _maxY - _minY);
            }
        }

        public void Add(Rectangle rectangle)
        {
            if (!_isInitialized)
            {
                InitializeBounds(rectangle);
                return;
            }

            UpdateBounds(rectangle);
        }

        private void InitializeBounds(Rectangle rectangle)
        {
            _minX = rectangle.Left;
            _minY = rectangle.Top;
            _maxX = rectangle.Right;
            _maxY = rectangle.Bottom;
            _isInitialized = true;
        }

        private void UpdateBounds(Rectangle rectangle)
        {
            _minX = Math.Min(_minX, rectangle.Left);
            _minY = Math.Min(_minY, rectangle.Top);
            _maxX = Math.Max(_maxX, rectangle.Right);
            _maxY = Math.Max(_maxY, rectangle.Bottom);
        }
    }
}
