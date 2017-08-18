using EntityWork.ViewModel;

namespace EntityFront
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ModelViewModel();
        }
    }
}
