using OOPProject.Contract;
using OOPProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Models
{
	public class BookCopy : IDisplayable
	{

		public string CopyId { get; private set; }
		public string Condition { get; private set; }
		public CopyStatus Status { get; private set; }
		public Book Book { get; private set; }
		public BoroowTransaction ? ActiveTransaction { get; private set; }

		public BookCopy(string copyid, Book book,string condition="Good")
		{
			CopyId = copyid;
			Book = book;
			Condition = condition;
			Status = CopyStatus.Available;
			
		}

		public string ToDisplay()=> $"Copy [{CopyId}] — {Book.Title} | Condition: {Condition}|{Status} ";

		public void Borrow(Member member, int loandays=14)
		{
			//check book copy
			if (!IsAvailable())
				throw new InvalidOperationException($"Copy {CopyId} is not available");

			//change status book copy 
			Status = CopyStatus.Borrowed;
			//create transaction
			ActiveTransaction=new BoroowTransaction(member,this,loandays);
			//add trasnaction memeber 
			member.AddTRansaction(ActiveTransaction);

		}

		public decimal Return()
		{
			if (ActiveTransaction == null)
				throw new InvalidOperationException("No Active Transaction");
			if(Status != CopyStatus.Borrowed)
				throw new InvalidOperationException($"Copy {CopyId} not borrowed");
			ActiveTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Today));
			decimal fine = ActiveTransaction.CalculateFine();
			Status = CopyStatus.Available;
			ActiveTransaction = null;
			return fine;

		}

		public bool IsAvailable() => Status == CopyStatus.Available;
		
	
	}
}
