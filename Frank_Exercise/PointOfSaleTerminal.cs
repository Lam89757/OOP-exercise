using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank_Exercise
{
  /// <summary>
  /// 
  /// </summary>
  public class PointOfSaleTerminal
  {
    //initialize a list of product
    private List<Product> products = new List<Product>();
    //create a list to store selected products
    private List<Product> selectedProducts = new List<Product>();

    #region initialize product
    /// <summary>
    /// initialize products' id, name and price
    /// </summary>
    public void SetPricing()
    {
      products.Add(new Product
      {
        ProductId = 1,
        ProductCode = "A",
        ProductPrice = 1.25,
        ProductDiscount = 0
      });
      products.Add(new Product
      {
        ProductId = 2,
        ProductCode = "B",
        ProductPrice = 4.25,
        ProductDiscount = 0
      });
      products.Add(new Product
      {
        ProductId = 3,
        ProductCode = "C",
        ProductPrice = 1.00,
        ProductDiscount = 0
      });
      products.Add(new Product
      {
        ProductId = 4,
        ProductCode = "D",
        ProductPrice = 0.75,
        ProductDiscount = 0
      });
    }

    /// <summary>
    /// set product discount
    /// </summary>
    /// <param name="objProduct">target of product </param>
    /// <param name="requiredNumber">required number for discount</param>
    /// <param name="discount">discount</param>
    private void SetDiscount(Product target)
    {
        //set discount for A that reduce 0.75 for each three
        if (target.ProductCode == "A" && target.ProductQuantity>=3)
        {
        target.ProductDiscount = 0.75;
          //set discount for C that reduce 1 for each 6
        }
        if (target.ProductCode == "C" && target.ProductQuantity >= 6)
        {
        target.ProductDiscount = 1;
      }
      }

    /// <summary>
    /// add product to selectedProducts list
    /// </summary>
    /// <param name="code">product code</param>
    /// <param name="price">product price</param>
    /// <param name="discount">product discount</param>
    /// <param name="quantity">product quantity</param>
    private void AddProduct(string code,double price,double discount,int quantity)
    {
      Product newProduct = new Product()
      {
        ProductCode = code,
        ProductPrice = price,
        ProductDiscount = discount,
        ProductQuantity = quantity
      };
      selectedProducts.Add(newProduct);
    }
    #endregion

    #region scan product and calculate total price
    /// <summary>
    /// get selected products
    /// </summary>
    /// <param name="code">scan the product code</param>
    public void ScanProduct(string code)
    {
      //get product object from database by ProductCode
      Product target = products.Where(product => product.ProductCode == code).FirstOrDefault();
      //judge if this code existed in database
      if(target==null)
      {
        //if not existed, alert user,and let user decide if add this to selectedProducts list
        if (true)//if user decide to add this product to selectedProducts list
        {
          //call AddProduct function to add
          //AddProduct(code, price, discount, quantity);
        }
      }
      //judge if this selectedProducts has this product
      var aa = from p in selectedProducts
               where p.ProductCode == code
               select p;
      //if scan product do not exist at selectedProducts, set property of quantity of it
      if (aa.Count() == 0)
      {
        //set quantity
        target.ProductQuantity = 1;
        //add selected product into selectedProducts
        selectedProducts.Add(target);
      }
      //if existed, add quantity
      else
      {
        //set quantity
        target.ProductQuantity++;
        //set discount
        SetDiscount(target);
      }
    }

    /// <summary>
    /// get total price of products
    /// </summary>
    /// <returns>total price as decimal and keep two decimals </returns>
    public decimal CalculateTotal()
    {
      double totalPrice = 0;
      foreach (Product product in selectedProducts)
      {
        totalPrice += product.ProductPrice * product.ProductQuantity - product.ProductDiscount;
      }
      return Convert.ToDecimal(totalPrice.ToString("0.00"));
    }
    #endregion
  }
}
