using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace iLG.WPF.Presentation.Components.Common
{
    /// <summary>
    /// Interaction logic for ToasterNotification.xaml
    /// </summary>
    public partial class ToasterNotification : UserControl
    {
        private readonly double _toasterHeight = 80;
        private readonly double _toasterWidth = 300;

        public ToasterNotification()
        {
            Width = _toasterWidth;
            Height = _toasterHeight;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Bottom;
            Margin = new Thickness(0, 0, 0, 10);
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            BeginAnimation(OpacityProperty, fadeInAnimation);
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title), typeof(string), typeof(ToasterNotification), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            nameof(Message), typeof(string), typeof(ToasterNotification), new PropertyMetadata(default(string)));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register(
            nameof(Duration), typeof(int), typeof(ToasterNotification), new PropertyMetadata(5));

        public int Duration
        {
            get { return (int)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty ToastTypeProperty = DependencyProperty.Register(
            nameof(ToastType), typeof(ToastType), typeof(ToasterNotification), new PropertyMetadata(ToastType.Info));

        public ToastType ToastType
        {
            get { return (ToastType)GetValue(ToastTypeProperty); }
            set { SetValue(ToastTypeProperty, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            switch (ToastType)
            {
                case ToastType.Info:
                    Background = (System.Windows.Media.Brush)Application.Current.Resources["ToastInfoBackground"];
                    break;
                case ToastType.Warning:
                    Background = (System.Windows.Media.Brush)Application.Current.Resources["ToastWarningBackground"];
                    break;
                case ToastType.Error:
                    Background = (System.Windows.Media.Brush)Application.Current.Resources["ToastErrorBackground"];
                    break;
            }
            if (Duration > 0)
            {
                _ = CloseAfterDelay(TimeSpan.FromSeconds(Duration));
            }
        }

        private async System.Threading.Tasks.Task CloseAfterDelay(TimeSpan delay)
        {
            await System.Threading.Tasks.Task.Delay(delay);
            this.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            var fadeOutAnimation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };
            BeginAnimation(OpacityProperty, fadeOutAnimation);
        }
    }
    public enum ToastType
    {
        Info,
        Warning,
        Error
    }
}
