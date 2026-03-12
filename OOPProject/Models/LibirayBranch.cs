using OOPProject.Contract;
using OOPProject.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
	public class LibirayBranch : IDisplayable
	{
		public string BranchId { get; set; }
		public string BrancName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string OpeneingHours { get; set; }
		public Libirian Manager { get; set; }
		private readonly List<BookCopy> _copies = new ();
		private readonly List<Member> _members = new ();

		public LibirayBranch(string branchId, string brancName, string address, string phone, string openeingHours, Libirian manager)
		{
			BranchId = branchId;
			BrancName = brancName;
			Address = address;
			Phone = phone;
			OpeneingHours = openeingHours;
			Manager = manager;
		}

		public IReadOnlyList<BookCopy> BookCopies=> _copies;
		public IReadOnlyList<Member> Members => _members;

		public IReadOnlyList<LibiraryUser> Users
		{
			get
			{
				List<LibiraryUser> users = new ();
				users.Add(Manager);
				users.AddRange(Members);
				return users;
			}
		}

		public Member RegisterMember(string name , string phone)
		{
			var Member= new Member(name, phone);
			_members.Add(Member);
			return Member;
		}
		public Member RegisterMember(string name, DateOnly? dateogbirth,string email, string phone , DateOnly membershipdate)
		{
			var Member= new Member(name,dateogbirth,email,phone,membershipdate);
			_members.Add(Member);
			return Member;

		}

		public Member FindMember(string membershipId)
		{
			for(int i = 0; i < _members.Count; i++)
			{
				if (_members[i].MembershipId == membershipId.NoramlizeId()) 
					return _members[i];
			}
			throw new InvalidOperationException("Member not found");
		}
		public BookCopy FindCopy(string copyId)
		{
			for (int i = 0; i < _copies.Count; i++)
			{
				if (_copies[i].CopyId == copyId.NoramlizeId())
					return _copies[i];
			}
			throw new InvalidOperationException("BookCopy not found");
		}


		public void AddBookCopy(BookCopy book)
		{
			_copies.Add(book);

		}

		public List<BookCopy> GetAvaliableCopies()
		{
			List<BookCopy> avCopies= new List<BookCopy>();
			for(int i=0; i<_copies.Count; i++)
			{
				if (_copies[i].IsAvailable())
					avCopies.Add(_copies[i]);
			}
			return avCopies;
		}

		public string ToDisplay()=> $@"ID : {BranchId}
Name : {BrancName}
Address : {Address}
Phone : {Phone}
Opening Hours : {OpeneingHours}
Manager : {Manager.Name}
Total Members : {_members.Count}
Total Book Copies : {_copies.Count}";

	}
}
