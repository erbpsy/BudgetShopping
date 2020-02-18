using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'budgetShopping' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY bundleQuantities
     *  3. INTEGER_ARRAY bundleCosts
     */

    public static int budgetShopping(int n, List<int> bundleQuantities, List<int> bundleCosts)
    {
            return getMaxQuantity(n, 0, 0, bundleQuantities.ToArray(), bundleCosts.ToArray());
      
    }
     static int getMaxQuantity(int budget, int currentQuantity, int currentCost, int[] bundleQuantities, int[] bundleCosts) {
        int maxQuantity = currentQuantity;
        
        for (int i = 0; i < bundleQuantities.Count(); i++) {
            if (currentCost + bundleCosts[i] <= budget) {
                int amount = getMaxQuantity(budget, currentQuantity + bundleQuantities[i], currentCost + bundleCosts[i], bundleQuantities, bundleCosts);
                if (maxQuantity < amount) {
                    maxQuantity = amount;
                }
            }
        }


        return maxQuantity;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int bundleQuantitiesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> bundleQuantities = new List<int>();

        for (int i = 0; i < bundleQuantitiesCount; i++)
        {
            int bundleQuantitiesItem = Convert.ToInt32(Console.ReadLine().Trim());
            bundleQuantities.Add(bundleQuantitiesItem);
        }

        int bundleCostsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> bundleCosts = new List<int>();

        for (int i = 0; i < bundleCostsCount; i++)
        {
            int bundleCostsItem = Convert.ToInt32(Console.ReadLine().Trim());
            bundleCosts.Add(bundleCostsItem);
        }

        int result = Result.budgetShopping(n, bundleQuantities, bundleCosts);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
