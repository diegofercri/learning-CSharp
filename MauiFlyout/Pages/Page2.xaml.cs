namespace MauiFlyout.Pages
{
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            Title = "Página 2";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Esta es la Opción 2", VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand }
                }
            };
        }
    }
}
