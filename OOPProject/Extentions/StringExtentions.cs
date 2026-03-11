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
	}
}
