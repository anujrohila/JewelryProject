using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Jewelry.Win8.Phone.Demo
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private double m_Zoom = 1;
        private double m_Width = 0;
        private double m_Height = 0;

        private void viewport_ManipulationDelta(object sender,
        System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            if (e.PinchManipulation != null)
            {

                double newWidth, newHieght;


                if (m_Width < m_Height)  // box new size between image and viewport
                {
                    newHieght = m_Height * m_Zoom * e.PinchManipulation.CumulativeScale;
                    newHieght = Math.Max(viewport.ActualHeight, newHieght);
                    newHieght = Math.Min(newHieght, m_Height);
                    newWidth = newHieght * m_Width / m_Height;
                }
                else
                {
                    newWidth = m_Width * m_Zoom * e.PinchManipulation.CumulativeScale;
                    newWidth = Math.Max(viewport.ActualWidth, newWidth);
                    newWidth = Math.Min(newWidth, m_Width);
                    newHieght = newWidth * m_Height / m_Width;
                }


                if (newWidth < m_Width && newHieght < m_Height)
                {
                    MatrixTransform transform = image.TransformToVisual(viewport)
                      as MatrixTransform;
                    Point pinchCenterOnImage =
                      transform.Transform(e.PinchManipulation.Original.Center);
                    Point relativeCenter =
                      new Point(e.PinchManipulation.Original.Center.X / image.Width,
                      e.PinchManipulation.Original.Center.Y / image.Height);
                    Point newOriginPoint = new Point(
                      relativeCenter.X * newWidth - pinchCenterOnImage.X,
                      relativeCenter.Y * newHieght - pinchCenterOnImage.Y);
                    viewport.SetViewportOrigin(newOriginPoint);
                }

                image.Width = newWidth;
                image.Height = newHieght;

                // Set new view port bound
                viewport.Bounds = new Rect(0, 0, newWidth, newHieght);
            }
        }

        private void viewport_ManipulationCompleted(object sender,
        System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            m_Zoom = image.Width / m_Width;
        }
    }
}