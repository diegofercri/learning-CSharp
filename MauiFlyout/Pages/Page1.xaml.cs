namespace MauiFlyout.Pages
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            Title = "Página 1";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Esta es la Opción 1", VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand }
                }
            };
        }
    }
}
