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
using System.IO;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;
using Microsoft.Phone;

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
            MediaLibrary mediaLibrary = new MediaLibrary();
            Picture img = mediaLibrary.Pictures.Where(pic => pic.Name.Contains("PictureJewelry")).FirstOrDefault();
            //var imageToShow = new Image()
            //{
            //    Source = PictureDecoder.DecodeJpeg(img.GetImage())
            //};
            //if (img != null)
            //    image1.Source = PictureDecoder.DecodeJpeg(img.GetImage());
        }

        private void RemoveWhiteBack()
        {
            Uri uri = new Uri("/Document/9.jpg", UriKind.RelativeOrAbsolute);
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

            Canvas.SetTop(round1, 100);
            Canvas.SetLeft(round1, 100);

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

            Canvas.SetTop(round2, 150);
            Canvas.SetLeft(round2, 150);

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
            Uri uri = new Uri("/Document/9.jpg", UriKind.RelativeOrAbsolute);
            //BitmapImage bit = new BitmapImage(uri);
            //img1.Source = bit;
            var image = new Image();
            image.Stretch = Stretch.Fill;
            image.Source = new BitmapImage(uri);
            Canvas.SetTop(image, 0);
            Canvas.SetLeft(image, 0);
            paint.Children.Add(image);




            var image1 = new Image();
            image1.Stretch = Stretch.Fill;
            image1.Source = new BitmapImage(new Uri("/Document/nec1.png", UriKind.RelativeOrAbsolute));
            paint.Children.Remove(image1);
            image1.Width = PointX1 - PointX + ((PointX1 - PointX) / 8);
            Canvas.SetTop(image1, PointY);
            Canvas.SetLeft(image1, (PointX - ((PointX1 - PointX) / 15)));
            CompositeTransform MyTransform = new CompositeTransform();
            MyTransform.Rotation = (PointY1 - PointY) / 3;
            image1.RenderTransform = MyTransform;
            paint.Children.Add(image1);
            image1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(OnManipulationDelta2);

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            Border b = new Border();
            paint.Children.Remove(b);
            for (int i = 1; i <= 6; i++)
            {
                Uri uri = new Uri("/Document/9.jpg", UriKind.RelativeOrAbsolute);
                var image = new Image();
                image.Stretch = Stretch.Fill;
                image.Source = new BitmapImage(uri);
                Canvas.SetTop(image, 0);
                Canvas.SetLeft(image, 0);
                paint.Children.Add(image);

                var image1 = new Image();
                image1.Stretch = Stretch.Fill;
                image1.Source = new BitmapImage(new Uri("/Document/nec" + i.ToString() + ".png", UriKind.RelativeOrAbsolute));
                image1.Width = PointX1 - PointX + ((PointX1 - PointX) / 8);
                Canvas.SetTop(image1, PointY);
                Canvas.SetLeft(image1, (PointX - ((PointX1 - PointX) / 15)));
                CompositeTransform MyTransform = new CompositeTransform();
                MyTransform.Rotation = (PointY1 - PointY) / 3;
                image1.RenderTransform = MyTransform;
                paint.Children.Add(image1);

                WriteableBitmap wb = new WriteableBitmap(paint, null);

                wb.Render(paint, new TranslateTransform());
                wb.Invalidate();

                using (MemoryStream stream = new MemoryStream())
                {
                    WriteableBitmap bitmap = new WriteableBitmap(paint, null);
                    bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, 100);
                    stream.Seek(0, SeekOrigin.Begin);

                    using (MediaLibrary mediaLibrary = new MediaLibrary())
                    {
                        mediaLibrary.SavePicture("PictureJewelry" + i.ToString() + ".jpg", stream);
                    }
                }
            }
            
            //MessageBox.Show("Picture Saved...");
            //Stream st = new MemoryStream();
            //BitmapImage b = new BitmapImage();
            //b.UriSource = new Uri("/asstes/34.png", UriKind.Relative);
            //// encode writeablebitmap object to a jpeg stream.
            //Extensions.SaveJpeg(wb, st, 200, 250, 0, 100);
            //st.Close();



            //Uri uri = new Uri("/Document/picture.jpg", UriKind.RelativeOrAbsolute);
            //BitmapImage bit = new BitmapImage(uri);
            //Stream stream = new MemoryStream();
            //bit.SetSource(stream);
            //Extensions.SaveJpeg(wb, stream, 200, 250, 0, 100);
            //stream.Close();
            //using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
            //{
            //    using (var fs = isf.CreateFile("picture.jpg"))
            //    {
            //        wb.SaveJpeg(fs, wb.PixelWidth, wb.PixelHeight, 10, 100);
            //    }
            //}
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