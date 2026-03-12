using ConsoleThemes;
using OOPProject.Extentions;
using OOPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Service
{
	public class LibirayService
	{
		private readonly LibirayBranch _branch;
		private readonly DisplayService _displayService;

		public LibirayService(LibirayBranch branch, DisplayService displayService)
		{
			_branch = branch;
			_displayService = displayService;
		}

		//handle borrow
		public void HandleBorrow()
		{
			string memberId = ThemeHelper.Prompt("MemberId").NoramlizeId();
			Member member= _branch.FindMember(memberId);
			_displayService.ShowAvailableCopies(_branch);
			string copyId = ThemeHelper.Prompt("CopyId to Borrow ").NoramlizeId();
			BookCopy bookCopy= _branch.FindCopy(copyId);
		bookCopy.Borrow(member);
			_displayService.ShowBoroowSuccess(bookCopy,member);

		}

		//handle return

		public void HandleReturn()
		{
			string copyId = ThemeHelper.Prompt("CopyId To Return").NoramlizeId();
			BookCopy copy = _branch.FindCopy(copyId);
			decimal fine = copy.Return();
			_displayService.ShowReturnSuccess(copy,fine);
		}

		//handle history
		public void HandleHistory()
		{
			string memberId = ThemeHelper.Prompt("MemeberId");
			Member member= _branch.FindMember(memberId);
			_displayService.ShowMemberHistory(member);
		}

		public void HandleRegisteration()
		{
			string name = ThemeHelper.Prompt("Full Name");
			string phone = ThemeHelper.Prompt("Phone");
			if (!phone.IsPhobneValid())
				throw new InvalidOperationException("Phone is not valid");
			string email= ThemeHelper.Prompt("Email");
			if (! email.IsEmailValid())
				throw new InvalidOperationException("Email is not valid");
			Member member= _branch.RegisterMember(name,null,email,phone,DateOnly.FromDateTime(DateTime.Today));
			_displayService.ShowRegisterSuccess(member);




		}
	}
}
