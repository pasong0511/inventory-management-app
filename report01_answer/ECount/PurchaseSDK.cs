using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount
{
    public class PurchaseSDK
    {

        SDK Sdk;
        //구매애 대한 정보 저장
        List<PurchaseHistoryModel> purchases = new List<PurchaseHistoryModel>();

        //생성자 -> sdk에 대한 정보를 저장
        public PurchaseSDK(SDK sdk)
        {
            this.Sdk = sdk;
        }

        //상품 이름과 개수 받음
        public void Create(string producName, int quantity, DateTime date)
        {
            var product = this.Sdk.Product.Get(producName);
            Console.WriteLine($"구매 -> 구매이름{producName} 수량 {quantity} 날짜 {date}");

            //참조형이므로 null 체크해야함
            if (product == null) {
                throw new Exception($"품목이 존재하지 않습니다. {producName}");
            }

            //여기서 실제 크리에이트 시작
            purchases.Add(new PurchaseHistoryModel(product, quantity, date));
        }

        //구매 목록에 대한 전체 리스트 반환
        public List<PurchaseHistoryModel> GetHistory()
        {
            
            return purchases;
        }
    }

    //상품 모델로 생성한 상품 객체, 개수 받음
    public class PurchaseHistoryModel
    {
        public ProductModel Product;
        public int Quantity;
        public DateTime Date;             //판매날짜

        //PurchaseHistoryModel 생성자
        public PurchaseHistoryModel(ProductModel product, int quantity, DateTime date)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Date = date;
        }

        public override string ToString()
        {
            return $"구매 ({this.Product.Name} : {this.Quantity} : {this.Date})";
        }
    }
}
