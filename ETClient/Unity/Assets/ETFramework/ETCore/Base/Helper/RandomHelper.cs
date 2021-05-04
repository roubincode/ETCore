using System;

namespace ETModel
{
	public static class RandomHelper
	{
		private static readonly Random random = new Random();

		public static UInt64 RandUInt64()
		{
			var bytes = new byte[8];
			random.NextBytes(bytes);
			return BitConverter.ToUInt64(bytes, 0);
		}

		public static Int64 RandInt64()
		{
			var bytes = new byte[8];
			random.NextBytes(bytes);
			return BitConverter.ToInt64(bytes, 0);
		}

		/// <summary>
		/// 获取lower与Upper之间的随机数
		/// </summary>
		/// <param name="lower"></param>
		/// <param name="upper"></param>
		/// <returns></returns>
		public static int RandomNumber(int lower, int upper)
		{
			int value = random.Next(lower, upper);
			return value;
		}
		public static int Random(int lower, int upper)
		{
			int value = random.Next(lower, upper);
			return value;
		}

		public static int Random(int upper)
		{
			int value = random.Next(upper);
			return value;
		}

		public static float Randomf()
		{
			int r = random.Next(0,100);
			double c = Math.Round((Convert.ToDouble(r)/Convert.ToDouble(100)),2);
			return Convert.ToSingle(c);
		}

		public static float Percentage(int a){
			double c = Math.Round((Convert.ToDouble(a)/Convert.ToDouble(100)),2);
			return Convert.ToSingle(c);
		}
	}
}