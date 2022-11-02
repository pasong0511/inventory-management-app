using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount
{
    public class SDK
    {
        public ProductSDK Product;
        public PurchaseSDK Purchase;
        public InventorySDK Inventory;
        public SaleSDK Sale;

        public SDK()
        {
            this.Product = new ProductSDK();
            this.Purchase = new PurchaseSDK(this);  //자기자신 인스턴스를 넘겨준다.
            this.Inventory = new InventorySDK(this);
            this.Sale = new SaleSDK(this);
        }
    }
}
