using Microsoft.VisualBasic;
using OOPProject.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPProject.Models
{
	public class BoroowTransaction : IDisplayable
	{
		public int TransactionId { get;private set; }
		public DateOnly BorrowDate { get;private set; }
		public DateOnly DueDate { get;private set; }
		public DateOnly ? ReturnDate { get;private set; }
		public Member Member { get;private set; }
		public BookCopy BookCopy { get;private set; }

		private static int _counter = 1000;
		private const decimal _fineperDay = 10m;
		private const string _dateFormat = "dd//MM/yyyy";
		public BoroowTransaction(Member member, BookCopy bookCopy, int loanDays)
		{
			TransactionId=++_counter;
			Member=member;
			BookCopy=bookCopy;
			BorrowDate = DateOnly.FromDateTime(DateTime.Today);
			DueDate=DateOnly.FromDateTime(DateTime.Today.AddDays(loanDays));
			ReturnDate = null;

			
		}

		public bool IsReturned() => ReturnDate.HasValue;

		public decimal CalculateFine()
		{
			DateOnly effDate = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
			int overduedays = effDate.DayNumber - DueDate.DayNumber;
			return overduedays > 0 ? overduedays * _fineperDay : 0;
		}
		public decimal CalculateFine(DateOnly returndate)
		{
			int overdays= returndate.DayNumber-DueDate.DayNumber;
			return overdays>0 ? overdays*_fineperDay : 0;

		}
		public void MarkReturned(DateOnly returndate)=>ReturnDate= returndate;
		public string ToDisplay()
		{
			string status = ReturnDate.HasValue ? "Returned" : "Active";
			decimal fine = CalculateFine();
			string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString(_dateFormat) : "Not returned yet";
			string fineLine = fine > 0 ? $"{fine:F2} EGP" : "None";

			return $@"── Transaction #{TransactionId} ──────────────
Book      : {BookCopy.Book.Title}
Copy ID   : {BookCopy.CopyId}
Borrowed  : {BorrowDate.ToString(_dateFormat)}
Due       : {DueDate.ToString(_dateFormat)}
Returned  : {returnInfo}
Status    : {status}
Fine      : {fineLine}";



		}
	}
}
