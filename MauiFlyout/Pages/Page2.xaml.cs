namespace MauiFlyout.Pages
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            Title = "P�gina 2";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Esta es la Opci�n 2", VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand }
                }
            };
        }
    }
}
