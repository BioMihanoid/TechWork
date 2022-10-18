using System;
using System.Globalization;

class Program
{
	static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

	class Number
	{
		readonly int _number;

		public Number(int number)
		{
			_number = number;
		}

		public override string ToString()
		{
			return _number.ToString(_ifp);
		}
		public static string operator +(Number nbr, string str)
		{
			if (nbr == null)
				return Int32.Parse(str).ToString();
			if (str == null)
				return nbr.ToString();
			return (nbr._number + Int32.Parse(str)).ToString();
		}
	}

	static void Main(string[] args)
	{
		int someValue1 = 10;
		int someValue2 = 5;

		string result = new Number(someValue1) + someValue2.ToString(_ifp);
		Console.WriteLine(result);
		Console.ReadKey();
	}
}
