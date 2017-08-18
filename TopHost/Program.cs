using Topshelf;

namespace TopHost
{
    public static class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<TaskRunner>(s =>
                {
                    s.ConstructUsing(name => new TaskRunner());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Treehouse Topshelf Host");
                x.SetDisplayName("tiny tree host");
                x.SetServiceName("treehost");
            });
        }
    }
}
