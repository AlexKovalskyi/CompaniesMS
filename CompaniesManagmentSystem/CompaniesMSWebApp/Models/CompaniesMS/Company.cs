using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CompaniesMSWebApp.Models.CompaniesMS
{
    public class Company : IEnumerable
    {
		private decimal _childEarnings;
	
		public int ID { get; private set; }
		public Company Parent { get; set; }
		public IList<Company> Childs { get; set; } 
		public string Name { get; set; }
		public decimal Earning { get; set; }
		public decimal ChildsEarnings 
		{ 
			get
			{
				if(Childs != null)
					_childEarnings = Childs.Sum(x => x.Earning);
				
				return _childEarnings;
			} 
			set
			{
				_childEarnings = value;
			}
		}
		
		public IEnumerator GetEnumerator()
		{
			return Childs.GetEnumerator();
		}

		public Company(int id, string name) : this(id, name, 0, null)
		{
		}

		public Company(int id, string name, decimal earning) : this(id, name, earning, null)
		{
		}

		public Company(int id, string name, decimal earning, Company parent)
		{
			ID = id;
			Name = name;
			Earning = earning;
			Parent = parent;
			AddToParent();
		}

		private void AddToParent()
		{
			if(Parent != null && Parent.Childs == null)
			{
				Parent.Childs = new List<Company>()
				{
					this
				};
			}
			else if (Parent != null)
			{
				Parent.Childs.Add(this);
			}
		}
    }
}
