using UnityEngine;
using Gains.Utility;

namespace Gains.Module.ProductData
{
    public class ProductsData : SingletonBehaviour<ProductsData>
    {
        private ProductList _productList;
        public ProductList ProductList => _productList;
        private void Awake()
        {
            LoadData();
        }

        private void LoadData()
        {
            TextAsset dataSource = Resources.Load<TextAsset>(@"Data/Products");
            _productList = JsonUtility.FromJson<ProductList>(dataSource.text);
        }
    }
}
