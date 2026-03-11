using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
	public class Libirian : LibiraryUser
	{
		public Libirian(string libirianId,string name , decimal salary,string phone ,DateOnly hireDate):base(name,phone)
		{
			LibirianId = libirianId;
			Salary = salary;
			HireDate = hireDate;
		}

		public string LibirianId { get; set; } = null!;
		public decimal Salary {  get; set; }
		public DateOnly HireDate { get; set; }
		public override string ToDisplay()
		{
			return $@"ID      : {LibirianId}
Name    : {Name}
Phone   : {Phone}
Salary  : {Salary:C}
Hired   : {HireDate:dd/MM/yyyy}";
		}
	}
}
