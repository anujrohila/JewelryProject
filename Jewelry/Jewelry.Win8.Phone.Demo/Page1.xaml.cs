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

        double angle, scale;
        private void OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
        {
            angle = transform.Rotation;
            scale = transform.ScaleX;
        }

        private void OnPinchDelta(object sender, PinchGestureEventArgs e)
        {
            transform.Rotation = angle + e.TotalAngleDelta;
            transform.ScaleX = scale * e.DistanceRatio;
            transform.ScaleY = scale * e.DistanceRatio;
        }
    }
}