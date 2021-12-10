using Newtonsoft.Json; 
namespace GRLZOHO.Data.projectclasslist{ 

    public class CustomField
    {
        [JsonProperty("Software Version")]
        public string SoftwareVersion { get; set; }
    }

}