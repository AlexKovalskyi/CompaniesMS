using System.Collections;
using System.Collections.Generic;
using CompaniesMSWebApp.DataStubs;
using CompaniesMSWebApp.Models.CompaniesMS;
using System.Linq;

namespace CompaniesMSWebApp.Core
{
    public class CompanyRepository : ITreeRepository<Company>, IEnumerable
	{
		private IList<Company> companies = new DataStub().GetCompany();

		public void AddChild(Company parent, Company item)
		{
			parent.Childs.Add(item);
		}

		public void Create(Company item)
		{
			companies.Add(item);
		}

		public void Delete(int id)
		{
			var itemToDel = Get(id);
			var parent = itemToDel.Parent;
			if (parent != null)
			{
				parent.Childs.Remove(itemToDel);
			}
			else
			{
				companies.Remove(itemToDel);
			}
		}

		public Company Get(int id)
		{
			Company company = null;
			Get(companies, id, ref company);

			return company;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return companies.GetEnumerator();
		}

		public void Update(Company item)
		{
			var oldCompany = Get(item.ID);
			oldCompany.Name = item.Name;
			oldCompany.Earning = item.Earning;
		}

		private void Get(IList<Company> companies, int id, ref Company company)
		{
			if (company != null)
			{
				return;
			}
			foreach (var item in companies)
			{
				if(item.ID == id)
				{
					company = item;
					break;
				}
				else if (item.Childs != null && item.Childs.Any())
				{
					Get(item.Childs, id, ref company);
				}
			}
		}
	}
}
