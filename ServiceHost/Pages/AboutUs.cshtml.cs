using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Text.Json;

namespace ServiceHost.Pages
{
    public class AboutUsModel : PageModel
    {
        public about_us_chart ChartDataSet { get; set; }
        public about_us_chartLabels ChartLabelsDataSet { get; set; }
        public void OnGet()
        {
            ChartDataSet = new about_us_chart
            {
                Label = "درصد",
                Data = new List<double> { 78.26, 2.99, 2.36, 1.86, 14.53 },
                BackgroundColor = new[] { "#7089d9", "#00e2f3", "#c695c7", "#f9cd8a", "#7fc04b" },
                BorderColor = "#ffcdb2"
            };

            ChartLabelsDataSet = new about_us_chartLabels
            {
                Labels = new[] { "صندوق بازنشستگی کشوری :" + " 78.26", 
                    "شرکت سرمایه‌گذاری آتیه‌صبا :" + " 2.99"
                    , " شرکت بیمه مرکزی جمهوری اسلامی ایران :"+ " 2.36",
                        "موسسه صندوق بیمه اجتماعی روستائیان وعشایر :" + " 1.86",
                    " :سایر سهامداران حقوقی و حقیقی"+ " 14.53" }
            };
        }
    }

    public class about_us_chartLabels
    {
        [JsonProperty(PropertyName = "labels")]
        public string[] Labels { get; set; }
    }


    public class about_us_chart
    {
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<double> Data { get; set; }

        [JsonProperty(PropertyName = "backgroundColor")]
        public string[] BackgroundColor { get; set; }

        [JsonProperty(PropertyName = "borderColor")]
        public string BorderColor { get; set; }

    }
}
