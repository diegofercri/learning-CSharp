namespace MauiFlyout.Pages
{
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            Title = "Página 3";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Esta es la Opción 3", VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand }
                }
            };
        }
    }
}
