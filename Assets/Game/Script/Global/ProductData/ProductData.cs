using UnityEngine;
using Gains.Utility;

namespace Gains.Module.ProductData
{
    public class ProductData : SingletonBehaviour<ProductData>
    {
        private ProductList _productList = new ProductList();
        public ProductList ProductList => _productList;
        public void Awake()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/Products");
            _productList = JsonUtility.FromJson<ProductList>(dataSource.text);
            Debug.Log(_productList.Products.Count);
        }
    }
}
