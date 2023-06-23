namespace HappyMeal.Core.Common
{
	public static class DataConstatnts
	{
		public static class RestaurantConst
		{
			public const int MinLengthName = 3;
			public const int MaxLengthName = 50;

			public const int MinLengthDescription = 50;
			public const int MaxLengthDescription = 500;
		}

		public static class CityConst
		{
			public const int MinLengthName = 2;
			public const int MaxLengthName = 50;
		}

		public static class ProductConst
		{
			public const int MinLengthName = 2;
			public const int MaxLengthName = 50;

			public const int MinRangeTypeProduct = 0;
			public const int MaxRangeTypeProduct = 1;

			public const int MinLengthDescription = 20;
			public const int MaxLengthDescription = 200;

			public const int MinLengthWeight = 1;
			public const int MaxLengthWeight = 10;
		}

		public static class AddonConst
		{
			public const int MinLengthName = 2;
			public const int MaxLengthName = 50;

			public const int MinLengthDescription = 10;
			public const int MaxLengthDescription = 50;

			public const int MinLengthWeight = 1;
			public const int MaxLengthWeight = 10;
		}

		public static class ReviewConst
		{
			public const int MaxLenghtComment = 100;
		}

		public static class UserConst
		{
			public const int MinLengthFirstName = 2;
			public const int MaxLengthFirstName = 10;

			public const int MinLengthLastName = 2;
			public const int MaxLengthLastName = 10;

			public const int MinLengthPhoneNumber = 5;
			public const int MaxLengthPhoneNumber = 12;

			public const int MinLengthEmail = 20;
			public const int MaxLengthEmail = 50;
		}
	}
}
