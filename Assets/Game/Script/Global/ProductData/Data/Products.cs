namespace Gains.Module.ProductData
{
    [System.Serializable]
    public class Product
    {
        public string ID;
        public string Name;
        public string Barcode;
        public Nutrition ServingSize;
        public string HSRCategory;
        public string BPOMCategory;
        public float Rating;
        public int ScanCount;
        public Nutrition TotalEnergy;
        public Nutrition Fat;
        public Nutrition Fiber;
        public Nutrition Sugar;
        public Nutrition Natrium;
        public Nutrition Protein;
    }
}
