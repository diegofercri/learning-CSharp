using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;



namespace WPFnba.Views
{
    /// <summary>
    /// Interaction logic for PrintPreviewWindow.xaml
    /// </summary>
    public partial class PrintPreviewWindow : Window
    {
        private Grid printView; // Grid que se imprimirá

        /// <summary>
        /// Constructor de la ventana de vista preliminar.
        /// </summary>
        /// <param name="printView">Grid que contiene la información a imprimir.</param>
        public PrintPreviewWindow(Grid printView)
        {
            InitializeComponent();
            this.printView = printView;

            // Crear un documento fijo para la vista preliminar de impresión
            FixedDocument fixedDoc = new FixedDocument();

            // Crear la página de contenido
            PageContent pageContent = new PageContent();
            FixedPage fixedpage = new FixedPage();

            // Crear un VisualBrush para representar el contenido del Grid
            var visualBrush = new VisualBrush(printView);

            // Crear un rectángulo que contendrá la vista previa del Grid
            var rectangle = new Rectangle
            {
                Width = 700,  // Ancho basado en el Grid original
                Height = 800, // Alto basado en el Grid original
                Fill = visualBrush  // Aplicar el contenido visual
            };

            // Agregar el rectángulo a la página de impresión
            fixedpage.Children.Add(rectangle);
            ((IAddChild)pageContent).AddChild(fixedpage);

            // Ajustar el tamaño de la página según el Grid
            pageContent.Width = printView.ActualWidth;
            pageContent.Height = printView.ActualHeight;

            // Agregar la página al documento fijo
            fixedDoc.Pages.Add(pageContent);

            // Asignar el documento a la vista preliminar en la UI
            this.previewView.Document = fixedDoc;
        }

        /// <summary>
        /// Evento que maneja la impresión del Grid cuando se presiona el botón "Imprimir".
        /// </summary>
        private void Print_Event(object sender, RoutedEventArgs e)
        {
            // Crear un diálogo de impresión
            PrintDialog printDialog = new PrintDialog();

            // Configurar la impresora por defecto como "Microsoft Print to PDF"
            printDialog.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");

            // Ajustar el tamaño de la página según las dimensiones del Grid
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(printView.ActualWidth, printView.ActualHeight);
            printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape; // Establecer modo horizontal

            // Enviar el Grid a imprimir como PDF
            printDialog.PrintVisual(printView, "Grid a PDF");
        }
    }
}
