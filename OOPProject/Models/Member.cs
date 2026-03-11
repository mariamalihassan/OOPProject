using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
	public class Member : LibiraryUser
	{
		public string MembershipId { get; private set; }
		public DateOnly? DateOfBitrh { get; private set; }
		public string? Email {  get; private set; }
		public DateOnly MembershipDate { get; private set; }
		private readonly List<BoroowTransaction> _transactions = new ();
		public IReadOnlyList<BoroowTransaction> Transactions => _transactions;


		private static int _counter = 1;
		public Member(string name  , DateOnly? dateOfBitrh, string? email,string phone, DateOnly membershipDate):base(name,phone)
		{
			MembershipId = $"MEM-{_counter++:D03}";
			DateOfBitrh = dateOfBitrh;
			Email = email;
			MembershipDate = membershipDate;
		}

		public Member(string name, string phone) : this(name, null, null, phone, DateOnly.FromDateTime(DateTime.Today))
		{

		}

		//AddTransaction

		public void AddTRansaction(BoroowTransaction transaction)
		{
			_transactions.Add(transaction);

		}

		//GetHistory Dispaly
		public string GetHistoryDisplay()
		{
			if (Transactions.Count == 0)
				return "No transaction Found";
			StringBuilder result = new();
			for(int i=0; i< Transactions.Count; i++)
			{
				result.Append(Transactions[i].ToDisplay());
			}
			return result.ToString();
		}
	




		public override string ToDisplay()
		{
			return $@"ID      : {MembershipId}
Name    : {Name}
Phone   : {Phone}
Email   : {Email ?? "N/A"}
Joined  : {MembershipDate:dd/MM/yyyy}
Borrows : {Transactions.Count}";
		}
	}
}
