using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace FinalProject
{
    public partial class FmDetailsItem : Form
    {
        public static List<Weather5Days> weather5s = new List<Weather5Days>();
        
        public FmDetailsItem()
        {
            InitializeComponent();
        }

        string APIKey = "2724b06529928acbf2189721ec01ea17";
        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", "Zocca", APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                picWeatherIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                lblTemp.Text = (Info.main.temp - 273.15).ToString();
                label8.Text = Info.weather[0].description.ToString();

            }    
        }

        DateTime convertDateTime(long millisec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddMilliseconds(millisec).ToLocalTime();

            return day;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FmDetailsItem_Load(object sender, EventArgs e)
        {
            getWeather();
        }

        private void picWeatherIcon_Click(object sender, EventArgs e)
        {

        }

        private void lblChiTiet_Click(object sender, EventArgs e)
        {
            FmWeatherInfo fmWeatherInfo = new FmWeatherInfo();
            fmWeatherInfo.ShowDialog();
        }
    }
}
