namespace EjemploMAUI.Pages;

public partial class ChangePage : ContentPage
{
    public ChangePage()
    {
        InitializeComponent();
    }

    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Obtener la cantidad en euros desde la entrada
        if (double.TryParse(EurosEntry.Text, out double euros))
        {
            // Tasas de conversión
            const double dollarsRate = 1.07;
            const double poundsRate = 0.84;
            const double yenRate = 160.09;
            const double yuanRate = 7.77;
            const double pesosRate = 1148.01;
            const double rublesRate = 95.70;

            // Calcular las conversiones
            double dollars = euros * dollarsRate;
            double pounds = euros * poundsRate;
            double yen = euros * yenRate;
            double yuan = euros * yuanRate;
            double pesos = euros * pesosRate;
            double rubles = euros * rublesRate;

            // Mostrar los resultados
            DollarsResult.Text = $"Dólares americanos: {dollars:F2}";
            PoundsResult.Text = $"Libras esterlinas: {pounds:F2}";
            YenResult.Text = $"Yenes japoneses: {yen:F2}";
            YuanResult.Text = $"Yuanes chinos: {yuan:F2}";
            PesosResult.Text = $"Pesos argentinos: {pesos:F2}";
            RublesResult.Text = $"Rublos rusos: {rubles:F2}";
        }
        else
        {
            // Mostrar mensaje de error si la entrada no es válida
            DisplayAlert("Error", "Por favor, introduce un número válido.", "Aceptar");
        }
    }
}