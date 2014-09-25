using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;

namespace Jewelry.Win8.Phone.Demo
{
    public partial class Camera1 : PhoneApplicationPage
    {
        public Camera1()
        {
            InitializeComponent();
            CameraData();
        }

        private int photoCounter = 0;
        PhotoCamera cam;
        MediaLibrary library = new MediaLibrary();

        private void CameraData()
        {
            if (PhotoCamera.IsCameraTypeSupported(CameraType.Primary) == true)
            {
                cam = new PhotoCamera(CameraType.Primary);
                cam.CaptureImageAvailable +=
                  new EventHandler<Microsoft.Devices.ContentReadyEventArgs>
                    (cam_CaptureImageAvailable);
                viewfinderBrush.SetSource(cam);
            }
            else
            {
                txtMessage.Text = "A Camera is not available on this device.";
            }
        }



        void cam_CaptureImageAvailable(object sender, Microsoft.Devices.ContentReadyEventArgs e)
        {
            photoCounter++;
            string fileName = photoCounter + ".jpg";
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtMessage.Text = "Captured image available, saving picture.";
            });
            library.SavePictureToCameraRoll(fileName, e.ImageStream);
            Deployment.Current.Dispatcher.BeginInvoke(delegate()
            {
                txtMessage.Text = "Picture has been saved to camera roll.";
            });
        }

        void viewfinder_Tapped(object sender, GestureEventArgs e)
        {
            if (cam != null)
            {
                try
                {
                    cam.CaptureImage();
                }
                catch (Exception ex)
                {
                    this.Dispatcher.BeginInvoke(delegate()
                    {
                        txtMessage.Text = ex.Message;
                    });
                }
            }
        }
    }
}