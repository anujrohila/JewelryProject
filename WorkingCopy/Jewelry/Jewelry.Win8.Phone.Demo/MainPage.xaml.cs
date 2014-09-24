using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Jewelry.Win8.Phone.Demo.Resources;

namespace Jewelry.Win8.Phone.Demo
{
    public partial class MainPage : PhoneApplicationPage
    {
        private double PointX;
        private double PointY;
        private double PointX1;
        private double PointY1;
        public MainPage()
        {
            InitializeComponent();
            RemoveWhiteBack();
            Drawbox();
            //transformGroup = new TransformGroup();
            //translation = new TranslateTransform();
            //scale = new ScaleTransform();
            //transformGroup.Children.Add(scale);
            //transformGroup.Children.Add(translation);
            //myrect.RenderTransform = transformGroup;
        }

        private void RemoveWhiteBack()
        {
            Uri uri = new Uri("/Document/8.jpg", UriKind.RelativeOrAbsolute);
            //BitmapImage bit = new BitmapImage(uri);
            //img1.Source = bit;

            var image = new Image();
            image.Stretch = Stretch.Fill;
            image.Source = new BitmapImage(uri);
            Canvas.SetTop(image, 0);
            Canvas.SetLeft(image, 0);
            paint.Children.Add(image);

        }


        private void Drawbox()
        {

            //Line rect = new Line();
            //rect.Fill = new SolidColorBrush(Colors.Blue);

            //rect.Width = 200;
            //rect.Height = 30;
            //Canvas.SetLeft(rect, 10);
            //Canvas.SetTop(rect, 20);
            //paint.Children.Add(rect);


            //rect.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta);
            //rect.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(OnManipulationCompleted);

            //Line line = new Line();
            //line.Stroke = new SolidColorBrush(Colors.Red);
            //line.StrokeThickness = 5;

            //line.X1 = 0;
            //line.X2 = 300;

            //line.Y1 = 0;
            //line.Y2 = 0;
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 255);

            //StackPanel stackPanel = new StackPanel();
            //stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;


            Border round1 = new Border();
            round1.Width = 30;
            round1.Height = 30;
            round1.Background = mySolidColorBrush;
            round1.CornerRadius = new CornerRadius(100);
            round1.Margin = new Thickness(0, 0, -2, 0);
            paint.Children.Add(round1);

            Canvas.SetLeft(round1, 10);
            Canvas.SetLeft(round1, 10);

            //Rectangle rectLine = new Rectangle();
            //rectLine.Width = 100;
            //rectLine.Height = 2;
            //rectLine.Fill = mySolidColorBrush;
            //stackPanel.Children.Add(rectLine);


            Border round2 = new Border();
            round2.Width = 30;
            round2.Height = 30;
            round2.Background = mySolidColorBrush;
            round2.CornerRadius = new CornerRadius(100);
            round2.Margin = new Thickness(0, 0, -2, 0);
            paint.Children.Add(round2);

            Canvas.SetLeft(round2, 50);
            Canvas.SetLeft(round2, 50);


            round1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta);

            round2.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta1);
            //round1.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(OnManipulationCompleted);

        }

        void OnManipulationDelta(object sender, ManipulationDeltaEventArgs args)
        {
            FrameworkElement Elem = sender as FrameworkElement;

            double Left = Canvas.GetLeft(Elem);
            double Top = Canvas.GetTop(Elem);

            Left += args.DeltaManipulation.Translation.X;
            Top += args.DeltaManipulation.Translation.Y;

            //check for bounds
            if (Left < 0)
            {
                Left = 0;
            }
            else if (Left > (paint.ActualWidth - Elem.ActualWidth))
            {
                Left = paint.ActualWidth - Elem.ActualWidth;
            }

            if (Top < 0)
            {
                Top = 0;
            }
            else if (Top > (paint.ActualHeight - Elem.ActualHeight))
            {
                Top = paint.ActualHeight - Elem.ActualHeight;
            }

            Canvas.SetLeft(Elem, Left);
            Canvas.SetTop(Elem, Top);

            PointX = Left;
            PointY = Top;
        }

        void OnManipulationDelta1(object sender, ManipulationDeltaEventArgs args)
        {
            FrameworkElement Elem = sender as FrameworkElement;

            double Left = Canvas.GetLeft(Elem);
            double Top = Canvas.GetTop(Elem);

            Left += args.DeltaManipulation.Translation.X;
            Top += args.DeltaManipulation.Translation.Y;

            //check for bounds
            if (Left < 0)
            {
                Left = 0;
            }
            else if (Left > (paint.ActualWidth - Elem.ActualWidth))
            {
                Left = paint.ActualWidth - Elem.ActualWidth;
            }

            if (Top < 0)
            {
                Top = 0;
            }
            else if (Top > (paint.ActualHeight - Elem.ActualHeight))
            {
                Top = paint.ActualHeight - Elem.ActualHeight;
            }

            Canvas.SetLeft(Elem, Left);
            Canvas.SetTop(Elem, Top);

            PointX1 = Left;
            PointY1 = Top;
        }

        void OnManipulationDelta2(object sender, ManipulationDeltaEventArgs args)
        {
            FrameworkElement Elem = sender as FrameworkElement;

            double Left = Canvas.GetLeft(Elem);
            double Top = Canvas.GetTop(Elem);

            Left += args.DeltaManipulation.Translation.X;
            Top += args.DeltaManipulation.Translation.Y;

            //check for bounds
            if (Left < 0)
            {
                Left = 0;
            }
            else if (Left > (paint.ActualWidth - Elem.ActualWidth))
            {
                Left = paint.ActualWidth - Elem.ActualWidth;
            }

            if (Top < 0)
            {
                Top = 0;
            }
            else if (Top > (paint.ActualHeight - Elem.ActualHeight))
            {
                Top = paint.ActualHeight - Elem.ActualHeight;
            }

            Canvas.SetLeft(Elem, Left);
            Canvas.SetTop(Elem, Top);

        }

        void OnManipulationCompleted(object sender, ManipulationCompletedEventArgs args)
        {
            FrameworkElement Elem = sender as FrameworkElement;

            //if (args.IsInertial)
            //{
            //    ElemToMove = Elem;

            //    //Debug.WriteLine("Linear VelX:{0:0.00}  VelY:{1:0.00}", args.FinalVelocities.LinearVelocity.X,
            //    //    args.FinalVelocities.LinearVelocity.Y);

            //    ElemVelX = args.FinalVelocities.LinearVelocity.X / SPEED_FACTOR;
            //    ElemVelY = args.FinalVelocities.LinearVelocity.Y / SPEED_FACTOR;

            //    timer.Start();
            //}
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            var image1 = new Image();
            image1.Stretch = Stretch.Fill;
            image1.Source = new BitmapImage(new Uri("/Document/1.png", UriKind.RelativeOrAbsolute));
            image1.Width = PointX1 - PointX + ((PointX1 - PointX) / 8);
            Canvas.SetTop(image1, PointY);
            Canvas.SetLeft(image1, (PointX - ((PointX1 - PointX) / 15)));


            //Duration Time_duration = new Duration(TimeSpan.FromSeconds(2));
            //Storyboard MyStory = new Storyboard();
            //MyStory.Duration = Time_duration;
            //DoubleAnimation My_Double = new DoubleAnimation();
            //My_Double.Duration = Time_duration;

            CompositeTransform MyTransform = new CompositeTransform();
            MyTransform.Rotation = (PointY1 - PointY) / 3;
            //Storyboard.SetTarget(My_Double, MyTransform);
            //Storyboard.SetTargetProperty(My_Double, new PropertyPath("Angle"));
            image1.RenderTransform = MyTransform;
            //image1.RenderTransformOrigin = new Point(0.5, 0.5);

            paint.Children.Add(image1);
            image1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta2);

        }

        //private TransformGroup transformGroup;
        //private TranslateTransform translation;
        //private ScaleTransform scale;

        //private void myrect_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        //{
        //    //change the color of the Rectangle to a half transparent Red
        //    myrect.Fill = new SolidColorBrush(Color.FromArgb(127, 255, 0, 0));
        //}

        //private void myrect_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        //{
        //    translation.X += e.DeltaManipulation.Translation.X;
        //    translation.Y += e.DeltaManipulation.Translation.Y;

        //    //Scale the Rectangle
        //    if (e.DeltaManipulation.Scale.X != 0)
        //        scale.ScaleX *= e.DeltaManipulation.Scale.X;
        //    if (e.DeltaManipulation.Scale.Y != 0)
        //        scale.ScaleY *= e.DeltaManipulation.Scale.Y;

        //}

        //private void myrect_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        //{
        //    myrect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        //    //Debug.WriteLine(myrect.Width * scale.ScaleX);
        //    //Debug.WriteLine(myrect.Height * scale.ScaleY);
        //}

    }
}