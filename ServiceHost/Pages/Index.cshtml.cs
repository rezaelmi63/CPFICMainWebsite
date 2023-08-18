using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public ChartPrice DataSetPrice { get; set; }
        public ChartPriceLabels DatasetPriceLabels { get; set; }

        public ChartVolume DataSetVolume { get; set; }
        public ChartVolumeLabels DatasetVolumeLabels { get; set; }

        public ChartCount DataSetCount { get; set; }
        public ChartCountLabels DatasetCountLabels { get; set; }

        public void OnGet()
        {
            DataSetPrice = new ChartPrice
            {

                Label = "قیمت معاملات در ۷ روز گذشته",
                Data = new List<double> {15.510,15.50,15.560,15.560,15.510,15.490 ,15.490},
                backGroundColor = new[] { "#676528", "#6F6924", "#746A1F", "#81762A", "#8C8234", "#998E3B", "#A79C41" },
                Bordercolor = "#d7b369"

            };

            DatasetPriceLabels = new ChartPriceLabels
            {
                    Labels = new[]{  "1402/05/15", "1402/05/16", "1402/05/17", "1402/05/18", "1402/05/21", "1402/05/22", "1402/05/23" }
            };

            DataSetVolume = new ChartVolume
            {

                Label = "حجم معاملات در ۷ روز گذشته",
                Data = new List<double> {   1.731, 1.628, 0.864, 1.589,1.698,2.314,0.560 },
                backGroundColor = new[] { "#676528", "#6F6924", "#746A1F", "#81762A", "#8C8234", "#998E3B", "#A79C41" },
                Bordercolor = "#d7b369"

            };

            DatasetVolumeLabels = new ChartVolumeLabels
            {
                Labels = new[] {  "1402/05/15", "1402/05/16", "1402/05/17", "1402/05/18", "1402/05/21", "1402/05/22", "1402/05/23" }
			};


            DataSetCount = new ChartCount
            {

                Label = "تعداد معاملات در ۷ روز گذشته",
                Data = new List<double> {  260, 190, 205, 203, 355, 250,115 },
                backGroundColor = new[] { "#676528", "#6F6924", "#746A1F", "#81762A", "#8C8234", "#998E3B", "#A79C41" },
                Bordercolor = "#d7b369"

            };

            DatasetCountLabels = new ChartCountLabels
            {
                Labels = new[] { "1402/05/15", "1402/05/16", "1402/05/17", "1402/05/18", "1402/05/21", "1402/05/22", "1402/05/23" }
			};

        }
    }
}

public class ChartPrice
{
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }
    [JsonProperty(PropertyName = "data")]
    public List<double>Data { get; set; }
    [JsonProperty(PropertyName = "backgroundColor")]
    public string[] backGroundColor { get; set; }
    [JsonProperty(PropertyName = "borderColor")]
    public string Bordercolor { get; set; }    
}

public class ChartPriceLabels
{
    [JsonProperty(PropertyName = "labels")]
    public string[] Labels { get; set; }
}



public class ChartVolume
{
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }
    [JsonProperty(PropertyName = "data")]
    public List<double> Data { get; set; }
    [JsonProperty(PropertyName = "backgroundColor")]
    public string[] backGroundColor { get; set; }
    [JsonProperty(PropertyName = "borderColor")]
    public string Bordercolor { get; set; }
}

public class ChartVolumeLabels
{
    [JsonProperty(PropertyName = "labels")]
    public string[] Labels { get; set; }
}



public class ChartCount
{
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }
    [JsonProperty(PropertyName = "data")]
    public List<double> Data { get; set; }
    [JsonProperty(PropertyName = "backgroundColor")]
    public string[] backGroundColor { get; set; }
    [JsonProperty(PropertyName = "borderColor")]
    public string Bordercolor { get; set; }
}

public class ChartCountLabels
{
    [JsonProperty(PropertyName = "labels")]
    public string[] Labels { get; set; }
}