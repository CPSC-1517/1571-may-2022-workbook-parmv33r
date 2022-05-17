using System;
namespace OOPsReview
{
	public static class Utilities
	{
		// Static classes are NOT instantiated by the outside user (developer)
		// Static class items are referenced using the classname.xxxxx
		// Methods withing this class have the keyword static in their signature
		// Static classes are shared between all outside user at the SAME time
		// DO NOT CONSIDER SAVING DATA within a static class BECAUSE you cannot be
		//	certain it will be there when you use the class again
		// Consider placing GENERIC reusable methods within a static class

		// Sample of overloaded methods
		// the method signatures are different

		public static bool IsZeroPositive(int value)
        {
			bool valid = true;

			if(value < 0)
            {
				valid = false;
            }

            return valid;
        }

		public static bool IsZeroPositive(double value)
		{
			bool valid = true;

			if (value < 0)
			{
				valid = false;
			}

			return valid;
		}

		public static bool IsZeroPositive(decimal value)
		{
			bool valid = true;

			if (value < 0)
			{
				valid = false;
			}

			return valid;
		}
	}
}

