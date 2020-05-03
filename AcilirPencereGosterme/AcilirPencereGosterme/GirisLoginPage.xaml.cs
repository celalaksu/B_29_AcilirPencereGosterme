using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AcilirPencereGosterme
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GirisLoginPage : PopupPage
    {
        public GirisLoginPage()
        {
            InitializeComponent();
            //Animation = new ScaleAnimation();
            
        }

        private async void GirisButton_Clicked(object sender, EventArgs e)
        { 
            await Navigation.PushModalAsync(new GirisBasarili());
            await PopupNavigation.Instance.PopAllAsync();           
        }

        private void vazgecButton_Clicked(object sender, EventArgs e)
        {
            AcilirPencereKapat();
        }

        private async void AcilirPencereKapat()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();

            //FrameContainer.HeightRequest = -1;

            if (!IsAnimationEnabled)
            {
             /*   
                CloseImage.Rotation = 0;
                CloseImage.Scale = 1;
                CloseImage.Opacity = 1;
                
                */
                //girisButton.Scale = 1;
                girisButton.Opacity = 1;
                vazgecButton.Opacity = 1;

                kullaniciAdiEntry.TranslationX = sifreEntry.TranslationX = 0;
                kullaniciAdiEntry.Opacity = sifreEntry.Opacity = 1;

                return;
            }

            /*
            CloseImage.Rotation = 30;
            CloseImage.Scale = 0.3;
            CloseImage.Opacity = 0;
            */

            //girisButton.Scale = 0.3;
            girisButton.Opacity = 0;
            vazgecButton.Opacity = 0;

            kullaniciAdiEntry.TranslationX = sifreEntry.TranslationX = -10;
            kullaniciAdiEntry.Opacity = sifreEntry.Opacity = 0;
        }

        

        protected override async Task OnAppearingAnimationEndAsync()
        {
            
            if (!IsAnimationEnabled)
                return;

            var translateLength = 400u;

            await Task.WhenAll(
                kullaniciAdiEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                kullaniciAdiEntry.FadeTo(1),
                (new Func<Task>(async () =>
                {
                    await Task.Delay(200);
                    await Task.WhenAll(
                        sifreEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                        sifreEntry.FadeTo(1));

                }))());

            await Task.WhenAll(
                /*
                 CloseImage.FadeTo(1),
                 CloseImage.ScaleTo(1, easing: Easing.SpringOut),
                 CloseImage.RotateTo(0),
                */ 
                girisButton.ScaleTo(1),
                girisButton.FadeTo(1),
                vazgecButton.ScaleTo(1),
                vazgecButton.FadeTo(1));
        }

        
    }
}