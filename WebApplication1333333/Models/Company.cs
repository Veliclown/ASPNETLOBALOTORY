using IniParser;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;


namespace WebApplication1333333.Models
{
    public class Company
    {
        public string Name { get; set; }
        public int Employees { get; set; }
    }

    public class XmlService
    {
        public List<Company> GetCompaniesFromXml(string xmlPath)
        {
            var companies = new List<Company>();
            var xDocument = XDocument.Load(xmlPath);
            var companyElements = xDocument.Descendants("Company");

            foreach (var element in companyElements)
            {
                companies.Add(new Company
                {
                    Name = element.Attribute("name")?.Value,
                    Employees = int.Parse(element.Element("Employees")?.Value ?? "0")
                });
            }

            return companies;
        }
    }
    public class JsonService
    {
        public List<Company> GetCompaniesFromJson(string jsonPath)
        {
            var json = File.ReadAllText(jsonPath);
            var jsonObject = JsonConvert.DeserializeObject<JsonObject>(json);
            return jsonObject.Companies;
        }

       
    }
    public class JsonObject
    {
        public List<Company> Companies { get; set; }
    }
    public class IniService
    {
        public List<Company> GetCompaniesFromIni(string iniPath)
        {
            var companies = new List<Company>();
            var parser = new FileIniDataParser();
            var data = parser.ReadFile(iniPath);

            foreach (var section in data.Sections)
            {
                var companyName = section.SectionName;
                var employees = int.Parse(data[companyName]["Employees"]);

                companies.Add(new Company
                {
                    Name = companyName,
                    Employees = employees
                });
            }

            return companies;
        }
    }
}
