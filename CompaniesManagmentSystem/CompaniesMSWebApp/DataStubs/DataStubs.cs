using CompaniesMSWebApp.Models.CompaniesMS;
using System.Collections.Generic;

namespace CompaniesMSWebApp.DataStubs
{
    public class DataStub
    {
		private List<Company> company = new List<Company>();

		public IList<Company> GetCompany()
		{
			company.Add(new Company(1, "Company1", 25));
			new Company(2, "Company2", 100, company[0]);
			new Company(2, "Company3", 100, company[0].Childs[0]);
			new Company(2, "Company4", 100, company[0]);

			return company;
		}
    }
}
