using UnityEngine;
using Gains.Utility;
using Gains.Module.ProductData;

namespace Gains.Module.ScanData
{
    public class ScanResultData : SingletonBehaviour<ScanResultData>
    {
        private Product _product;
        public Product Product => _product;

        public bool TryGetProduct(string barcode, out Product product)
        {
            product = null;
            product = ProductsData.Instance.ProductList.Products.Find(item => string.Equals(barcode, item.Barcode));
            if (product != null)
            {
                _product = product;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
