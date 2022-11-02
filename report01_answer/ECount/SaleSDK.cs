using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount
{
    public class SaleSDK
    {
        SDK Sdk;
        //판매에 대한 정보 저장
        List<SaleHistoryModel> sales = new List<SaleHistoryModel>();

        //생성자 -> sdk에 대한 정보 받음
        public SaleSDK(SDK sdk) {
            this.Sdk = sdk;
            Console.WriteLine("this sdk 출력" + Sdk);
        }

        //판매 상품 이름과 개수와, 날짜를 받음
        public void Create(string producName, int count, DateTime date) {

            Console.WriteLine($"판매 -> 제품이름{producName} 개수 {count} 날짜 {date}");

            var product = this.Sdk.Product.Get(producName);
            //참조형이므로 null 체크해야함
            if (product == null) {
                throw new Exception($"품목이 존재하지 않습니다. {producName}");
            }

            //여기서 실제 크리에이트 시작
            sales.Add(new SaleHistoryModel(product, count, date));
        }

        //구매 목록에 대한 전체 리스트 반환
        public List<SaleHistoryModel> GetHistory()
        {
            return sales;
        }
    }

    //상품 모델로 생성한 상품 객체, 판매개수 받음
    public class SaleHistoryModel
    {
        public ProductModel Product;    //상품모델
        public int Count;               //판매개수
        public DateTime Date;             //판매날짜

        //SaleHistoryModel 생성자 추가
        public SaleHistoryModel(ProductModel product, int count, DateTime date) {
            this.Product = product;
            this.Count = count;
            this.Date = date;
        }

        public override string ToString()
        {
            return $"판매 ({this.Product.Name}: {this.Count} : {this.Date})";
        }

    }
}
