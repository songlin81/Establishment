namespace Structure
{
    public class AppEngine : IAppEngine
    {
        private readonly ITransform _transform;
        private readonly IOutputDisplay _outputDisplay;

        public AppEngine(ITransform transform, IOutputDisplay outputDisplay)
        {
            _transform = transform;
            _outputDisplay = outputDisplay;
        }

        public void Run()
        {
            _outputDisplay.Show(_transform.GetTransformValue());
        }
    }
}
