using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yuwa.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YuwaMainPage : ContentPage
    {
        List<string> iconNameList = new List<string> { "Attendence", "Classes", "Equipment", "FieldPerformance", "Library", "LivelyHoodRecord", "MedicalRecord", "OtherSurvey", "Savings", "School", "Student_record", "Survey", "Threats", "ValueRanking" };

        public YuwaMainPage()
        {
            InitializeComponent();
            BindingContext = new ContentPageViewModel();
            WrapPanelFeatured.Padding = new Thickness(5);
            WrapPanelFeatured.RowSpacing = 10;

        }
        protected override void OnAppearing()
        {
            WrapPanelFeatured.Children.Clear();

            foreach (var item in iconNameList)
            {
                var stack = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(3),
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 5,
                };
                var img = new Image()
                {
                    Source = item.ToString() + ".png",
                    HeightRequest = 100,
                    WidthRequest = 100,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.Center,

                };
                var imgtapGesture = new TapGestureRecognizer();
                img.GestureRecognizers.Add(imgtapGesture);
                imgtapGesture.Tapped += Image_Tapped;


                var btmLbl = new Label()
                {
                    WidthRequest = 100,
                    Text = item.ToString(),
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    LineBreakMode = LineBreakMode.NoWrap,
                    VerticalOptions = LayoutOptions.Start
                };

                stack.Children.Add(img);
                stack.Children.Add(btmLbl);

                WrapPanelFeatured.Children.Add(new Frame()
                {
                    Content = stack,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    OutlineColor = Color.Gray,
                    Padding = new Thickness(0),

                });

            }

        }

        private async void Image_Tapped(object sender, EventArgs e)
        {
            await this.DisplayAlert("Still working on it", "Please try again after sometime", "OK");
        }
    }

        class YuwaMainPageViewModel : INotifyPropertyChanged
    {

        public YuwaMainPageViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
