using MauiTest.Models;
using MauiTest.PageModels;

namespace MauiTest.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}