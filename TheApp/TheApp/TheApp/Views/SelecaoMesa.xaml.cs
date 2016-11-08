using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheApp.Views.popup;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace TheApp.Views
{
    public partial class SelecaoMesa : ContentPage
    {
        public SelecaoMesa()
        {
            InitializeComponent();
            BindingContext = this;
            //scanner.IsAnalyzing = true;     
            //leitorQr();

        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {

            Device.BeginInvokeOnMainThread(async () =>
            {
                // Stop analysis until we navigate away so we don't keep reading barcodes
                scanner.IsAnalyzing = false;

                // Show an alert
                qrResult.Text = result.Text;
                IsBusy = true;
                var mesa = await App.TransportManager.PostAsync<MesaDTO>(new AppUtility.Model.MesaRequest() { nomeMesa = result.Text });
                //await DisplayAlert("Scanned Barcode", result.Text, "OK");

                await this.Navigation.PushAsync(new LogaMesaPopup(mesa));
                IsBusy = false;
            });
        }


        #region referencia futura
        //async Task leitorQr()
        //{
        //    #if __ANDROID__
        //        // Initialize the scanner first so it can track the current context
        //        MobileBarcodeScanner.Initialize (Application);
        //    #endif

        //    var scanner = new ZXing.Mobile.MobileBarcodeScanner();
        //    scanner.UseCustomOverlay = true;

        //    //scanner.CustomOverlay = myCustomOverlayInstance;

        //    var result = await scanner.Scan();

        //    if (result != null)
        //        qrResult.Text = "Scanned Barcode: " + result.Text;
        //        //Console.WriteLine("Scanned Barcode: " + result.Text);
        //}

        //async void ativaCamera()
        //{
        //    var device = Resolver.Resolve<IDevice>();
        //    var _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
        //    await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 })
        //        .ContinueWith(t =>
        //        {
        //            if (t.IsFaulted)
        //            {
        //                var s = t.Exception.InnerException.ToString();
        //            }
        //            else if (t.IsCanceled)
        //            {
        //                var canceled = true;
        //            }
        //            else
        //            {
        //                var mediaFile = t.Result;

        //                //imgSrc.Source  = ImageSource.FromStream(() => mediaFile.Source);

        //                return mediaFile;
        //            }

        //            return null;
        //        });
        //}
        #endregion

        private async void Button_Clicked(object sender, EventArgs e)
        {
            IsBusy = true;
            var mesa = await App.TransportManager.PostAsync<MesaDTO>(new AppUtility.Model.MesaRequest() { nomeMesa = qrResult.Text });
            await this.Navigation.PushAsync(new LogaMesaPopup(mesa));
            IsBusy = false;
        }
    }
}
