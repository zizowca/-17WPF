using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Задание_17
{
    /// <summary>
    /// Логика взаимодействия для ColorMix.xaml
    /// </summary>
    public partial class ColorMix : UserControl
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            "Color",
            typeof(Color),
            typeof(ColorMix),
            new FrameworkPropertyMetadata(
                Colors.Black,
                new PropertyChangedCallback (OnColorChanged)));

        public static readonly DependencyProperty RedColorProperty = DependencyProperty.Register(
            "Red",
            typeof(byte),
            typeof(ColorMix),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnColorRGBChanged)));

        public static DependencyProperty GreenColorProperty= DependencyProperty.Register(
            "Green",
            typeof(byte),
            typeof(ColorMix),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnColorRGBChanged)));

        public static DependencyProperty BlueColorProperty=DependencyProperty.Register(
            "Blue",
            typeof(byte),
            typeof(ColorMix),
            new FrameworkPropertyMetadata(
                new PropertyChangedCallback(OnColorRGBChanged)));

        

        public Color Color
        {
            get
            { 
                return (Color) GetValue (ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }
        public byte Red
        {
            get
            {
                return (byte)GetValue(RedColorProperty);
            }
            set
            {
                SetValue(RedColorProperty, value);
            }
        }
        public byte Green
        {
            get
            {
                return (byte)GetValue(GreenColorProperty);
            }
            set
            {
                SetValue(GreenColorProperty, value);
            }
        }
        public byte Blue
        {
            get
            {
                return (byte)GetValue(BlueColorProperty);
            }
            set
            {
                SetValue(BlueColorProperty, value);
            }
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorMix colorMix = (ColorMix)sender;
            Color color = colorMix.Color;
            if (e.Property==RedColorProperty)
            {
                color.R = (byte)e.NewValue;
            }
            else if (e.Property==GreenColorProperty)
            {
                color.G = (byte)e.NewValue;
            }
            else if (e.Property == BlueColorProperty)
            {
                color.B = (byte)e.NewValue;
            }

            colorMix.Color = color;
        }
        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorMix colorMix = (ColorMix)sender;
            colorMix.Red = newColor.R;
            colorMix.Green = newColor.G;
            colorMix.Blue = newColor.B;

        }
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
            "ColorChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<Color>),
            typeof(ColorMix));
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add
            {
                AddHandler(ColorChangedEvent, value);
            }
            remove
            {
                RemoveHandler(ColorChangedEvent, value);
            }
        }
       
        public ColorMix()
        {
            InitializeComponent();
        }
    }
}
