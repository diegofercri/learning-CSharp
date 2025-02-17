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
    /// Interaction logic for PrintPreviewWindow.xaml.
    /// This window provides a print preview for a given Grid and handles printing functionality.
    /// </summary>
    public partial class PrintPreviewWindow : Window
    {
        private Grid printView; // The Grid to be printed

        /// <summary>
        /// Constructor for the PrintPreviewWindow class.
        /// Initializes the window and sets up the print preview document.
        /// </summary>
        /// <param name="printView">The Grid containing the information to be printed.</param>
        public PrintPreviewWindow(Grid printView)
        {
            InitializeComponent();
            this.printView = printView;

            // Create a fixed document for the print preview
            FixedDocument fixedDoc = new FixedDocument();

            // Create the content page
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();

            // Create a VisualBrush to render the content of the Grid
            var visualBrush = new VisualBrush(printView);

            // Create a rectangle that will contain the preview of the Grid
            var rectangle = new Rectangle
            {
                Width = 700,  // Width based on the original Grid
                Height = 800, // Height based on the original Grid
                Fill = visualBrush  // Apply the visual content
            };

            // Add the rectangle to the print page
            fixedPage.Children.Add(rectangle);
            ((IAddChild)pageContent).AddChild(fixedPage);

            // Adjust the page size according to the Grid dimensions
            pageContent.Width = printView.ActualWidth;
            pageContent.Height = printView.ActualHeight;

            // Add the page to the fixed document
            fixedDoc.Pages.Add(pageContent);

            // Assign the document to the print preview in the UI
            this.previewView.Document = fixedDoc;
        }

        /// <summary>
        /// Handles the "Print" button click event.
        /// Opens a print dialog and sends the Grid to the printer as a PDF.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void Print_Event(object sender, RoutedEventArgs e)
        {
            // Create a print dialog
            PrintDialog printDialog = new PrintDialog();

            // Set the default printer to "Microsoft Print to PDF"
            printDialog.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF");

            // Adjust the page size according to the Grid dimensions
            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(printView.ActualWidth, printView.ActualHeight);
            printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape; // Set landscape orientation

            // Send the Grid to the printer as a PDF
            printDialog.PrintVisual(printView, "Grid to PDF");
        }
    }
}