namespace EjemploMAUI.Pages;

public partial class Page1 : ContentPage
{
    // Variable to store the current value entered by the user.
    private double currentValue = 0;

    // Variable to store the selected operator (+, -, *, /).
    private string currentOperator = "";

    // Indicates whether a new number input should be started on the screen.
    private bool isNewInput = true;

    /// <summary>
    /// Constructor of the page. Initializes the interface components.
    /// </summary>
    public Page1()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the event when a numeric button is clicked.
    /// Adds the pressed number to the calculator's display.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event data.</param>
    private void OnNumberClicked(object sender, EventArgs e)
    {
        var button = sender as Button; // Gets the button that was pressed.
        if (button != null)
        {
            // If it's a new input, replace the content of the display.
            if (isNewInput)
            {
                Display.Text = button.Text;
                isNewInput = false; // Indicates that it is no longer a new input.
            }
            else
            {
                // If it's not a new input, concatenate the number to what's already on the display.
                Display.Text += button.Text;
            }
        }
    }

    /// <summary>
    /// Handles the event when an operator button (+, -, *, /) is clicked.
    /// Stores the current value and the selected operator.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event data.</param>
    private void OnOperatorClicked(object sender, EventArgs e)
    {
        var button = sender as Button; // Gets the button that was pressed.
        if (button != null)
        {
            // Stores the current value displayed on the screen.
            currentValue = double.Parse(Display.Text);

            // Stores the selected operator.
            currentOperator = button.Text;

            // Indicates that the next input will be a new number.
            isNewInput = true;
        }
    }

    /// <summary>
    /// Handles the event when the equals button (=) is clicked.
    /// Performs the selected mathematical operation and displays the result.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event data.</param>
    private void OnEqualsClicked(object sender, EventArgs e)
    {
        // Converts the current value on the display to a number.
        double newValue = double.Parse(Display.Text);

        double result = 0; // Variable to store the result of the operation.

        // Performs the corresponding operation based on the selected operator.
        switch (currentOperator)
        {
            case "+":
                result = currentValue + newValue; // Addition.
                break;
            case "-":
                result = currentValue - newValue; // Subtraction.
                break;
            case "*":
                result = currentValue * newValue; // Multiplication.
                break;
            case "/":
                result = currentValue / newValue; // Division.
                break;
        }

        // Displays the result on the screen.
        Display.Text = result.ToString();

        // Indicates that the next input will be a new number.
        isNewInput = true;
    }

    /// <summary>
    /// Handles the event when the clear button (C) is clicked.
    /// Resets all values and clears the screen.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">Event data.</param>
    private void OnClearClicked(object sender, EventArgs e)
    {
        // Clears the screen and resets all variables.
        Display.Text = "0";
        currentValue = 0;
        currentOperator = "";
        isNewInput = true;
    }
}
