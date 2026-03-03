using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace drawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ShapeDrawer shapeDrawer;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            shapeDrawer = new ShapeDrawer();
            shapeDrawer.mw = this;
        }
        public SolidColorBrush currentColor;

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            currentColor = new SolidColorBrush(Color.FromArgb(255, (byte)Slider1.Value, (byte)Slider2.Value, (byte)Slider3.Value));
            ColorShower.Fill = currentColor;
        }
        public string CurrentShape;
        private void NewShapeChosen(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn) {
                CurrentShape = (string)btn.Content;
            }
        }
        public Point MousePosition;

        public void AddShapeToCanvas()
        {

        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            MousePosition = e.MouseDevice.GetPosition(MainCanvas);
            CursorPos.Text = $"{MousePosition.X} {MousePosition.Y}" ;
        }

        private void MainCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}