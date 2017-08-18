using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ModelPicker
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            myLabel.Content = "";
            var mySource = Enumerable.Range(1, 1000).ToList();
            Task.Factory.StartNew(() => HeavyLiftFunction(mySource));
        }

        private void HeavyLiftFunction(List<int> values)
        {
            foreach (var i in values)
            {
                var currentProgress = i;
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    myLabel.Content = myLabel.Content + "Updating..." + Fibonacci(currentProgress) + "\n";
                }), DispatcherPriority.Background);
            }
        }

        private static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
