namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // This method handles the calculation when the "Calculate" button is clicked
        private void OnCalculateClicked(object sender, EventArgs e)
        {
            // Get the first and second numbers from user
            if (double.TryParse(firstNumberEntry.Text, out double firstNumber) && double.TryParse(secondNumberEntry.Text, out double secondNumber))
            {
                // Get the selected operation from the picker
                string operation = operationPicker.SelectedItem.ToString();

                double result = 0;
                bool validOperation = true;

                // Perform the operation based on selection
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                    case "x":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            resultLabel.Text = "Cannot divide by zero!";
                            validOperation = false;
                        }
                        else
                        {
                            result = firstNumber / secondNumber;
                        }
                        break;
                    default:
                        validOperation = false;
                        break;
                }

                // Display the result if the operation is valid
                if (validOperation)
                {
                    resultLabel.Text = $"Result: {result}";
                }
            }
            else
            {
                //  invalid input (non-numeric)
                resultLabel.Text = "Please enter valid numbers.";
            }
        }

        // This method resets the UI for another calculation
        private void OnCalculateAgainClicked(object sender, EventArgs e)
        {
            // Reset all input fields and result label
            firstNumberEntry.Text = string.Empty;
            secondNumberEntry.Text = string.Empty;
            resultLabel.Text = "Result:";
            operationPicker.SelectedIndex = -1;  // Reset the picker
        }
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            firstNumberLabel.Text = $"First number: {e.NewValue}";
            firstNumberEntry.Text = e.NewValue.ToString();
        }
    }
}
