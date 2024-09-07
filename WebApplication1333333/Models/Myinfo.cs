using IniParser;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;


namespace WebApplication1333333.Models
{
    public class Myinfo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
    }

    public class JsonMyService
    {
        public Myinfo GetConfigData(string jsonPath)
        {
            var json = File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<Myinfo>(json);
        }
    }
}
