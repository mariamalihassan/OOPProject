using OOPProject.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
	public abstract class LibiraryUser  : IDisplayable
	{
		protected LibiraryUser(string name, string phone)
		{
			Name = name;
			Phone = phone;
		}

		public string Name { get; set; }

		public string Phone {  get; set; }

		public abstract string ToDisplay();
	
	}
}
