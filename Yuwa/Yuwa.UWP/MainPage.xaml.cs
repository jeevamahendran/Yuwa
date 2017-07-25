namespace Yuwa.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new Yuwa.App());
        }
    }
}