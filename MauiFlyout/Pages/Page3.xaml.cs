namespace MauiFlyout.Pages
{
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            Title = "P�gina 3";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Esta es la Opci�n 3", VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand }
                }
            };
        }
    }
}
