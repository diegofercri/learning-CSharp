namespace MauiFlyout.Pages
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            Title = "P�gina 1";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Esta es la Opci�n 1", VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand }
                }
            };
        }
    }
}
