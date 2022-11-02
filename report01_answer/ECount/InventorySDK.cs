using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount
{
    public class InventorySDK
    {
        SDK Sdk;

        //생성자
        public InventorySDK(SDK sdk)
        {
            this.Sdk = sdk;
        }

        //딕셔너리에 상품 정보와 재고 개수 저장
        public Dictionary<ProductModel, int> GetStatus()
        {
            var result = new Dictionary<ProductModel, int>();   //상품 정보랑 개수 저장
            var purchases = this.Sdk.Purchase.GetHistory();     //구매 목록 가져옴
            var sales = this.Sdk.Sale.GetHistory();

            //Console.WriteLine("!!! 구매개수 정보 출력" + purchases);
            //Console.WriteLine("!!! 판매개수 정보 출력" + sales);

            //구매목록에서 구매상품 정보를 키로 입벤토리 리절트에 추가함
            foreach (var purchase in purchases) {
                if (result.ContainsKey(purchase.Product)) {
                    //Console.WriteLine("키머냐!" + purchase.Product);
                    //기존에 있던 아이템이면 구매 개수 누적
                    result[purchase.Product] += purchase.Quantity;
                } else {
                    //기존에 없던 아이템이면 구매 새롭게 인벤토리 딕셔너리에 개수 추가
                    result.Add(purchase.Product, purchase.Quantity);
                }
            }

            //판매목록에서 판매상품 정보를 키로 인벤토리 리절트에 추가함
            foreach(var sale in sales) {
                //이미 등록되어있는 키(상품이름)가 있는 경우에만 뺄 수 있음
                if(result.ContainsKey(sale.Product)) {
                    //Console.WriteLine("현재 재고 카운트 -> " + result[sale.Product]);
                    if (result[sale.Product] - sale.Count >= 0) {
                        result[sale.Product] -= sale.Count;
                    } else {
                        throw new Exception($"존재하는 개수보다 큰 개수를 판매할 수 없습니다, 개수 {sale.Count}");
                    }
                    
                } else {
                    throw new Exception($"품목이 존재하지 않습니다. {sale.Product}");
                }
            }

            return result;
        }


        public Dictionary<ProductModel, DateTime> GetDate(DateTime targetDate)
        {
            var result = new Dictionary<ProductModel, DateTime>();   //상품 정보랑 개수 저장
            var purchases = this.Sdk.Purchase.GetHistory();     //구매 목록 가져옴

            Console.WriteLine("타겟 날자" + targetDate);

            foreach (var purchase in purchases)
            {
                //Console.WriteLine("반복문-> " + purchase.Date);
                if (purchase.Date == targetDate)
                {
                    result.Add(purchase.Product, purchase.Date);
                }
            }
            return result;
        }
    }
}
