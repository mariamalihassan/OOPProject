using OOPProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Contract
{
	public interface IBorrowable
	{
		void Borrow(Member member,int loanDays=14);

		decimal Return();
		bool IsAvaiable();
	}
}
