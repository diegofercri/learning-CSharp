namespace EjemploMAUI.Pages;

public partial class Page2 : ContentPage
{
    /// <summary>
    /// Constructor of the page. Initializes the components of the interface.
    /// </summary>
    public Page2()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the event when the "Binary to Decimal" button is clicked.
    /// Converts a binary string entered by the user into its decimal equivalent.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event data.</param>
    private void OnBinaryToDecimalClicked(object sender, EventArgs e)
    {
        try
        {
            // Get the user input as a binary string.
            string binary = Input.Text;

            // Convert the binary string to a decimal number.
            int decimalValue = Convert.ToInt32(binary, 2);

            // Display the result in the format "Decimal: [value]".
            Result.Text = $"Decimal: {decimalValue}";
        }
        catch
        {
            // If an error occurs (e.g., invalid input), display an error message.
            Result.Text = "Invalid binary input";
        }
    }

    /// <summary>
    /// Handles the event when the "Decimal to Binary" button is clicked.
    /// Converts a decimal number entered by the user into its binary equivalent.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event data.</param>
    private void OnDecimalToBinaryClicked(object sender, EventArgs e)
    {
        try
        {
            // Get the user input as a decimal number.
            int decimalValue = int.Parse(Input.Text);

            // Convert the decimal number to a binary string.
            string binary = Convert.ToString(decimalValue, 2);

            // Display the result in the format "Binary: [value]".
            Result.Text = $"Binary: {binary}";
        }
        catch
        {
            // If an error occurs (e.g., invalid input), display an error message.
            Result.Text = "Invalid decimal input";
        }
    }
}