using CompaniesMSWebApp.Core;
using CompaniesMSWebApp.Models.CompaniesMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestGetFunction
{
    public class Program
    {
        public static void Main(string[] args)
        {
			CompanyRepository cr = new CompanyRepository();

			cr.Create(new Company(10, "My Company", 20));
			var parent = cr.Get(1);
			cr.AddChild(parent, new Company(10, "My Company2", 20));
			Console.Read();
		}
    }
}
