using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace TheApp.Views
{
    public partial class SelecaoMesa : ContentPage
    {
        public SelecaoMesa()
        {
            InitializeComponent();
            ativaCamera();
        }

        async void ativaCamera()
        {
            var device = Resolver.Resolve<IDevice>();
            var _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
            await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 })
                .ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        var s = t.Exception.InnerException.ToString();
                    }
                    else if (t.IsCanceled)
                    {
                        var canceled = true;
                    }
                    else
                    {
                        var mediaFile = t.Result;

                        imgSrc.Source  = ImageSource.FromStream(() => mediaFile.Source);

                        return mediaFile;
                    }

                    return null;
                });
        }
    }
}
