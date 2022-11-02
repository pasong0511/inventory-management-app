using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECount
{
    //여기 퍼블릭은 내부에서는 문제가 되지않음 -> 다른 프로젝트에서는 문제가 있음
    //인터널 -> 내 프로젝트는 자유롭고, 다른 프로젝트에서는 접근 제한
    public enum ProductType {
        RawMaterial,        //원재료
        Product,            //제품
        Goods,              //상품
    }

    public class ProductSDK
    {
        //프로덕트 객체를 저장하는 리스트
        List<ProductModel> products = new List<ProductModel>();


        public void Create(string name, ProductType type)
        {
            //이름과 타입을 넘겨줘서 생성된 ProductModel를 리스트에 담는다.
            products.Add(new ProductModel(name, type));
        }

        //이름으로 상품리스트(products)에 있는거 찾기
        public ProductModel Get(string name)
        {
            //람다식 사용
            return products.Find(x => x.Name == name);
        }
    }

    //프로덕트모델 붕어빵 틀
    public class ProductModel
    {
        //위에 두개 갖고 만든다.(string name, ProductType type)
        public string Name;
        public ProductType Type;    //enum으로 만든 타입

        //생성자
        public ProductModel(string name, ProductType type)
        {
            this.Name = name;
            this.Type = type;
        }

        //문자열로 반환해주는 함수
        public override string ToString()
        {
            return this.Name;
        }
    }
}
