using DigitalizarDoc.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DigitalizarDoc
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ImageSource imgSource = null;
    
        public ICommand CaptureCommand => new Command(Capture);

        private async void Capture()
        {
            //var navigation = Application.Current.MainPage as CustomNavigationPage;
            //if (navigation != null)
            //{
            //    navigation.PushAsync(new CaptureDoc(), true);
            //}

            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
                imgSource = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        public MainPageViewModel()
        {
            
        }
    }
}
