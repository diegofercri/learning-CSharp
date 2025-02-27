using MauiFlyout.Pages;

namespace MauiFlyout
{
    /// <summary>
    /// The main page of the application, which acts as a FlyoutPage.
    /// Provides navigation to different pages such as DecimalCalculatorPage and BinaryConverterPage.
    /// </summary>
    public partial class MainPage : FlyoutPage
    {
        int count = 0; // A counter variable (currently unused in this implementation).

        /// <summary>
        /// Constructor for the MainPage. Initializes the components of the interface.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the event when Option 1 (Decimal Calculator) is clicked.
        /// Navigates to the DecimalCalculatorPage if not already on it.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private async void OnOption1Clicked(object sender, EventArgs e)
        {
            // Get the current page from the navigation stack.
            var currentPage = Navigation.NavigationStack.LastOrDefault();

            // Check if the current page is not already the DecimalCalculatorPage.
            if (currentPage is not DecimalCalculatorPage)
            {
                if (Navigation.NavigationStack.Count > 0)
                {
                    // Pop to the root page before navigating to avoid stacking multiple pages.
                    await NavPage.PopToRootAsync();
                }

                // Navigate to the DecimalCalculatorPage.
                await NavPage.PushAsync(new DecimalCalculatorPage());
            }
            else
            {
                // If already on DecimalCalculatorPage, show an informational alert.
                await DisplayAlert("Information", "You are already on DecimalCalculatorPage.", "OK");
            }
        }

        /// <summary>
        /// Handles the event when Option 2 (Binary Converter) is clicked.
        /// Navigates to the BinaryConverterPage if not already on it.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private async void OnOption2Clicked(object sender, EventArgs e)
        {
            // Get the current page from the navigation stack.
            var currentPage = Navigation.NavigationStack.LastOrDefault();

            // Check if the current page is not already the BinaryConverterPage.
            if (currentPage is not BinaryConverterPage)
            {
                if (Navigation.NavigationStack.Count > 0)
                {
                    // Pop to the root page before navigating to avoid stacking multiple pages.
                    await NavPage.PopToRootAsync();
                }

                // Navigate to the BinaryConverterPage.
                await NavPage.PushAsync(new BinaryConverterPage());
            }
            else
            {
                // If already on BinaryConverterPage, show an informational alert.
                await DisplayAlert("Information", "You are already on BinaryConverterPage.", "OK");
            }
        }
    }
}