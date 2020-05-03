using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AcilirPencereGosterme
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void AcilirPencere_Clicked(object sender, EventArgs e)
        {
            bool cevap = await DisplayAlert("Soru", "Soru sorma penceresi çalıştı mı?", "Evet", "Hayır");
            if (cevap)
            {
                await DisplayAlert("Cevabınız olumlu", "Evet diyerek cevapladınız.", "Tamam");
            }
            else
            {
                await DisplayAlert("Cevabınız olumsuz", "Hayır diyerek cevapladınız.", "Tamam");
            }
        }

        private async void SeceneklerButton_Clicked(object sender, EventArgs e)
        {
            string secilenIslem = await DisplayActionSheet("Sosyal medyayı seçiniz", "Vazgeç", null, "Facebook", "Twitter", "Google");

            await DisplayAlert("Seçiminiz", $"{secilenIslem} 'i seçtiniz", "Tamam");
        }

        private async void VeriAlButton_Clicked(object sender, EventArgs e)
        {
            string cevap = await DisplayPromptAsync("Xamarin", "Xamarin'le işler nasıl gidiyor?");
            await DisplayAlert("Yorumunuz", $"Cevabınız \"{cevap}\"", "Tamam");
        }

        private async void Giris_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new GirisLoginPage());
        }

        private async void OzelAnimasyonButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new OzelAnimasyonPage());
        }
    }
}
