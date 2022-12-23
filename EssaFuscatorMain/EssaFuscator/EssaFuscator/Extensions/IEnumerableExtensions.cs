using System;
using System.Collections.Generic;

namespace EssaFuscator.Extensions
{
	public static class EnumerableExtensions
	{
		private static readonly Random Rng = new();
		
		public static void Shuffle<T>(this IList<T> list)
		{
			for(var i=0; i < list.Count; i++)
				list.Swap(i, Rng.Next(i, list.Count));
		}

		private static void Swap<T>(this IList<T> list, int i, int j) => (list[i], list[j]) = (list[j], list[i]);
	}
}