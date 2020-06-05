using System.Windows;
using System.Windows.Controls;
using Services;


namespace WpfApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        
       public MainWindow(RandomStringGenerator randomStringGenerator) {
            InitializeComponent();
            var randomString = randomStringGenerator.Generate();
            WriteInTextBlock(randomString);

       }

       private void WriteInTextBlock(string text) {
           Content = new TextBlock {
               Text = text
           };
       }
    }
}