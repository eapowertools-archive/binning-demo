using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace binning_demo
{
    class Program
    {
        private static double _threshold = 0;
		public static List<double> AddToBucket(List<double> numbersLeft, List<double> currentBucket)
		{
			if (numbersLeft.Count == 0)
			{
				return currentBucket;
			}
			List<List<double>> bucketsOfBuckets = new List<List<double>>();

			int countNumsLeft = numbersLeft.Count;
			for (int i = 0; i < countNumsLeft; i++)
			{
				double tempDouble = numbersLeft[i];
				List<double> newList = new List<double>(numbersLeft);
				newList.RemoveAt(i);
				if ((currentBucket.Sum() + tempDouble) > 120)
				{
					return currentBucket;
				}
				List<double> newCurrentBucket = new List<double>(currentBucket);
				newCurrentBucket.Add(tempDouble);
				bucketsOfBuckets.Add(AddToBucket(newList, newCurrentBucket));
			}
			double max = 0;
			int maxIndex = -1;
			for (int j = 0; j < bucketsOfBuckets.Count; j++)
			{
				if (bucketsOfBuckets[j].Sum() > max)
				{
					max = bucketsOfBuckets[j].Sum();
					maxIndex = j;
				}
			}

			return bucketsOfBuckets[maxIndex];
		}


		static void Main(string[] args)
		{
            try {
                StringBuilder sb = new StringBuilder();
                // Try to load file.
                String[] lines = File.ReadAllLines("input.txt");
                if(!Double.TryParse(lines[0], out _threshold))
                {
                    throw new Exception("Cannot parse the first line of input.txt. Should be your bin threshold.");
                }
                List<double> doubleList = new List<double>();
                lines[1].Split(',').ToList().ForEach(v => doubleList.Add(Convert.ToDouble(v.Trim())));

                double[] apps = doubleList.ToArray();

                List<double> myList = new List<double>(apps);
                int bucketCounter = 0;
                while (myList.Count > 0)
                {
                    bucketCounter++;
                    List<double> someBucket = AddToBucket(myList, new List<double>());

                    sb.AppendLine("Bucket number " + bucketCounter + ":");
                    for (int i = 0; i < someBucket.Count; i++)
                    {
                        if (i < (someBucket.Count - 1))
                        {
                            sb.Append(someBucket[i] + ", ");
                        }
                        else
                        {
                            sb.Append(someBucket[i]);
                        }
                        myList.Remove(someBucket[i]);
                    }
                    sb.AppendLine("\n");
                }
                string allText = sb.ToString();
                Console.WriteLine(allText);
                File.WriteAllText("output.txt", allText);
            }
            catch (Exception e)
            {
                Console.WriteLine("Binning failed due to: " + e.Message);
            }

            Console.WriteLine("Press any key to quit.");
            Console.Read();
		}
    }
}
