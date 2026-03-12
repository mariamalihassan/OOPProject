using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject.Extentions
{
	public static class StringExtentions
	{
		public static string NoramlizeId(this string value)
		{
			return value?.Trim().ToUpperInvariant()?? string.Empty;
		}

		public static bool IsPhobneValid(this string value)
		{
			for(int i= 0; i< value.Length; i++)
			{
				if(char.IsDigit(value[i]))
					return true;
			}
			return false;
		}

		public static bool IsEmailValid(this string value)
		{
			bool hasAt=false;
			bool hasdot=false;
			for(int i=0; i<value.Length; i++)
			{
				if (value[i]=='@') hasAt = true;
				if (value[i]=='.') hasdot = true;
			}
			return hasAt && hasdot;
		}
	}
}
