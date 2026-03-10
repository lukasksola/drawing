using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
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

        public System.Drawing.Point MousePosition;

        public void AddShapeToCanvas(UIElement element)
        {
            MainCanvas.Children.Add(element);
        }

        private void MainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePosition = e.MouseDevice.GetPosition(MainCanvas);
            MousePosition.X = (int)mousePosition.X;
            MousePosition.Y = (int)mousePosition.Y;
            CursorPos.Text = $"{MousePosition.X} {MousePosition.Y}" ;
        }

        private void MainCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            shapeDrawer.DrawShape(CurrentShape, currentColor, MousePosition);
        }

        private void LoadFile(object sender, RoutedEventArgs e)
        {
            var FileDialog = new OpenFileDialog();
            if (FileDialog.ShowDialog() == true) {
                string json = File.ReadAllText(FileDialog.FileName);

                List<SaveFormat> shapes = JsonSerializer.Deserialize<List<SaveFormat>>(json);
                MainCanvas.Children.Clear();
                shapeDrawer.LoadedFile(shapes);
                
            }
        }
        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (MainCanvas.Children.Count != 0) {
                var FileDialog = new SaveFileDialog();
                if(FileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(FileDialog.FileName, shapeDrawer.SaveFile());
                }


            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Clear();
            shapeDrawer.savedShapes.Clear();
        }
    }
}