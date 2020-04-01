using System;
using Frank_Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    #region tests
    [TestMethod]
    public void TestMethod1()
    {
      //expected result for test
      decimal expectedResult=13.25M;
      //test scane product list
      string productsString = "ABCDABA";

      decimal actualResult = RunTest(productsString);

      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMethod2()
    {
      //expected result for test
      decimal expectedResult = 6M;
      //test scane product list
      string productsString = "CCCCCCC";

      decimal actualResult = RunTest(productsString);

      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMethod3()
    {
      //expected result for test
      decimal expectedResult = 7.25M;
      //test scane product list
      string productsString = "ABCD";

      decimal actualResult = RunTest(productsString);

      Assert.AreEqual(expectedResult, actualResult);
    }
    #endregion

    #region public function run test
    /// <summary>
    /// public test function
    /// </summary>
    /// <param name="productsString">input products string</param>
    /// <returns>total price as decimal</returns>
    private decimal RunTest(string productsString)
    {
      //create an instance of PointOfSaleTerminal class
      PointOfSaleTerminal terminal = new PointOfSaleTerminal();
      //call function to initialize product's name and price
      terminal.SetPricing();
      string[] terminalPro = new string[productsString.Length];
      //split product list from string to string array
      for (int i = 0; i < productsString.Length; i++)
      {
        terminalPro[i] = productsString.Substring(i, 1);
      }
      //Analog scanning machine, scan one product at a time
      foreach (string key in terminalPro)
      {
        terminal.ScanProduct(key);
      }
      decimal actualResult = terminal.CalculateTotal();
      return actualResult;
    }
    #endregion
  }
}
