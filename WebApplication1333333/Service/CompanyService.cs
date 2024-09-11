using WebApplication1333333.Models;

namespace WebApplication1333333.Service
{
    public class CompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Company GetCompanyWithMostEmployees()
        {
            var companies = new List<Company>();

            
            var jsonCompanies = _configuration.GetSection("Companies").Get<List<Company>>();
            if (jsonCompanies != null)
            {
                companies.AddRange(jsonCompanies);
            }

            
            var xmlCompanies = _configuration.GetSection("Companies").Get<List<Company>>();
            if (xmlCompanies != null)
            {
                companies.AddRange(xmlCompanies);
            }

            
            foreach (var section in _configuration.GetChildren())
            {
                if (section.Key.StartsWith("Company"))
                {
                    var name = section.GetValue<string>("Name");
                    var employees = section.GetValue<int>("Employees");
                    companies.Add(new Company { Name = name, Employees = employees });
                }
            }

            
            return companies.OrderByDescending(c => c.Employees).FirstOrDefault();
        }
    }
}
