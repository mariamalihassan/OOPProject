using ConsoleThemes;
using OOPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Service
{
	public class DisplayService
	{
		public void ShowBranchInfo(LibirayBranch branch)
		{
			ThemeHelper.PrintHeader("Libriray Branch Info");
			Console.WriteLine(branch.ToDisplay());
		}

		public void ShowAllUsers(LibirayBranch branch)
		{
			ThemeHelper.PrintHeader("All registered Users");
			IReadOnlyList<LibiraryUser> users = branch.Users;
			for(int i=0;i< branch.Users.Count; i++)
			{
				string header = users[i] is Libirian ? "Libiriran Profile " : "Member Profile";
				ThemeHelper.PrintSectionTitle(header);
				Console.WriteLine(users[i].ToDisplay());
			}

		}

		public void ShowAvailableCopies(LibirayBranch branch)
		{
			ThemeHelper.PrintHeader("Available Book Copies");
			List<BookCopy> books= branch.GetAvaliableCopies();
			if(books.Count ==0)
			{
				ThemeHelper.PrintWarning("No available book copies found");
				return;
			}
			else
			{
				for(int i=0; i< branch.BookCopies.Count; i++)
				{
					Console.WriteLine(branch.BookCopies[i].ToDisplay());
				}
			}

		}
		public void ShowALLCopies(LibirayBranch branch)
		{
			ThemeHelper.PrintHeader("ALL Book Copies");
			
			if (branch.BookCopies.Count == 0)
			{
				ThemeHelper.PrintWarning("No  book copies found");
				return;
			}
			else
			{
				for (int i = 0; i < branch.BookCopies.Count; i++)
				{
					Console.WriteLine(branch.BookCopies[i].ToDisplay());
				}
			}

		}

		public void ShowMemberHistory(Member member)
		{
			ThemeHelper.PrintSectionTitle($"Boroowing History for {member.Name}");
			Console.WriteLine(member.GetHistoryDisplay());

		}

		public void ShowBoroowSuccess(BookCopy copy, Member member)

		{
			ThemeHelper.PrintSuccess($"Copy {copy.CopyId} :{copy.Book.Title} Boroowed by {member.Name}");
			ThemeHelper.PrintSuccess($"DueDate : {copy.ActiveTransaction!.DueDate: dd//MM//yyyy}");


		}

		public void ShowReturnSuccess(BookCopy copy , decimal fine)
		{
			ThemeHelper.PrintSuccess($"Copy {copy.CopyId} - {copy.Book.Title} Returned");
			if (fine > 0)
				ThemeHelper.PrintWarning($"Late return fine :{fine:f2} EGP");
			else
				ThemeHelper.PrintSuccess("Retuern on date : No Fine Thanks");
		}

		public void ShowRegisterSuccess(Member member)
		{
			ThemeHelper.PrintSuccess($"Member : {member.Name} - {member.MembershipId} Registered");
		}
		public void ShowAddCopySuccess(BookCopy copy)
		{
			ThemeHelper.PrintSuccess($"Copy {copy.CopyId} - {copy.Book.Title} Added");
		}
		//


	}
}
