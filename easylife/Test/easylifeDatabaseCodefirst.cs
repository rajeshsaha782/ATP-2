using easylife.Core.Entities;
using easylife.Core.Service;
using easylife.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class easylifeDatabaseCodefirst
    {
        public void CreateDB()
        {
            easylifeDbContext e = new easylifeDbContext();
            MemberService ms = new MemberService(e);

            Member m1 = new Member();
            m1.Email = "rajesh@gmail.com";
            m1.Password = "123";
            m1.Name = "Rajesh saha";
            m1.Gender = "Male";
            m1.PhoneNumber = "01711111111";
            m1.Type = "1";
            m1.Status = "1";
            m1.MemberSince = DateTime.Now;
            m1.LastLoggedIn = DateTime.Now;
            m1.TotalPurchase = 1;
            m1.Point = 1;

            Console.WriteLine(ms.Insert(m1));


            Member m2 = new Member();
            m2.Email = "rakib@gmail.com";
            m2.Password = "123";
            m2.Name = "Rakibul Hossain";
            m2.Gender = "Male";
            m2.PhoneNumber = "01722222222";
            m2.Type = "2";
            m2.Status = "1";
            m2.MemberSince = DateTime.Now;
            m2.LastLoggedIn = DateTime.Now;
            m2.TotalPurchase = 1;
            m2.Point = 1;

            Console.WriteLine(ms.Insert(m2));



            Member m3 = new Member();
            m3.Email = "efti@gmail.com";
            m3.Password = "123";
            m3.Name = "Mashiul Azam";
            m3.Gender = "Male";
            m3.PhoneNumber = "01733333333";
            m3.Type = "3";
            m3.Status = "1";
            m3.MemberSince = DateTime.Now;
            m3.LastLoggedIn = DateTime.Now;
            m3.TotalPurchase = 1;
            m3.Point = 1;

            Console.WriteLine(ms.Insert(m3));



            Member m4 = new Member();
            m4.Email = "reza@gmail.com";
            m4.Password = "123";
            m4.Name = "Rezaul Karim";
            m4.Gender = "Male";
            m4.PhoneNumber = "01744444444";
            m4.Type = "4";
            m4.Status = "1";
            m4.MemberSince = DateTime.Now;
            m4.LastLoggedIn = DateTime.Now;
            m4.TotalPurchase = 1;
            m4.Point = 1;

            Console.WriteLine(ms.Insert(m4));

            Member m5 = new Member();
            m5.Email = "robi@gmail.com";
            m5.Password = "123";
            m5.Name = "Robi Ullah";
            m5.Gender = "Male";
            m5.PhoneNumber = "01811111111";
            m5.Type = "0";
            m5.Status = "1";
            m5.MemberSince = DateTime.Now;
            m5.LastLoggedIn = DateTime.Now;
            m5.TotalPurchase = 1;
            m5.Point = 1;

            Console.WriteLine(ms.Insert(m5));


            Member m6 = new Member();
            m6.Email = "tanim@gmail.com";
            m6.Password = "123";
            m6.Name = "Ibrahim Khalil";
            m6.Gender = "Male";
            m6.PhoneNumber = "01822222222";
            m6.Type = "0";
            m6.Status = "1";
            m6.MemberSince = DateTime.Now;
            m6.LastLoggedIn = DateTime.Now;
            m6.TotalPurchase = 1;
            m6.Point = 1;

            Console.WriteLine(ms.Insert(m6));

            Member m7 = new Member();
            m7.Email = "toma@gmail.com";
            m7.Password = "123";
            m7.Name = "Toma Azam";
            m7.Gender = "Female";
            m7.PhoneNumber = "01833333333";
            m7.Type = "0";
            m7.Status = "0";
            m7.MemberSince = DateTime.Now;
            m7.LastLoggedIn = DateTime.Now;
            m7.TotalPurchase = 1;
            m7.Point = 1;

            Console.WriteLine(ms.Insert(m7));

            Member m8 = new Member();
            m8.Email = "mizbah@gmail.com";
            m8.Password = "123";
            m8.Name = "Mizbah Ahmed";
            m8.Gender = "Male";
            m8.PhoneNumber = "01844444444";
            m8.Type = "0";
            m8.Status = "0";
            m8.MemberSince = DateTime.Now;
            m8.LastLoggedIn = DateTime.Now;
            m8.TotalPurchase = 1;
            m8.Point = 1;

            Console.WriteLine(ms.Insert(m8));



            Member m9 = new Member();
            m9.Email = "tushar@gmail.com";
            m9.Password = "123";
            m9.Name = "Saiful Islam";
            m9.Gender = "Male";
            m9.PhoneNumber = "01755555555";
            m9.Type = "2";
            m9.Status = "1";
            m9.MemberSince = DateTime.Now;
            m9.LastLoggedIn = DateTime.Now;
            m9.TotalPurchase = 1;
            m9.Point = 1;

            Console.WriteLine(ms.Insert(m8));



            //Console.WriteLine(ms.GetById(1).MemeberId);
            //Console.WriteLine(ms.GetById(1).Name);
            //Console.WriteLine(ms.GetById(1).Email);


            //Member m1 = new Member();
            //m1.MemberId = 1;
            //m1.Email = "e@gmail.com";
            //m1.Name = "efti1";
            //m1.MemberSince = DateTime.Now;
            //m1.LastLoggedIn = DateTime.Now;
            //Console.WriteLine(ms.Update(m1));

            //Console.WriteLine(ms.GetById(1).MemberId);
            //Console.WriteLine(ms.GetById(1).Name);
            //Console.WriteLine(ms.GetById(1).Email);

            //easylifeDbContext e = new easylifeDbContext();

            //Address a = new Address();
            //a.Member_id = 1;
            //a.Member_Address = "Mirpur";

            // AddressService a1 = new AddressService(e);
            // Console.WriteLine(a1.Insert(a));

            ////Member--------------------

            //Member m = new Member();
            //m.Email = "r@gmail.com";
            //m.MemeberSince = DateTime.Now;
            //m.LastLoggedIn = DateTime.Now;

            //MemberService ms = new MemberService(e);
            //Console.WriteLine(ms.Insert(m));

            //Product--------------------
            ProductService ps = new ProductService(e);

            Product p1 = new Product();
            p1.ProductName = "Kakashi T Shirt";
            p1.Features = "Loreum Ispum";
            p1.Quantity = 10;
            p1.BuyingPrice = 44;
            p1.SellingPrice = 450;
            p1.Category = "Kids Wear";
            p1.SubCategory = "T-Shirt";
            p1.Brand = "easy";
            p1.Size = 1;
            p1.Date = DateTime.Now;
            p1.LastSold = DateTime.Now;
            p1.TotalSell = 200;
            p1.TotalViewed = 5;
            p1.Star = 4;
            Console.WriteLine(ps.Insert(p1));


            Product p2 = new Product();
            p2.ProductName = "Naruto T Shirt";
            p2.Features = "Loreum Ispum";
            p2.Quantity = 10;
            p2.BuyingPrice = 44;
            p2.SellingPrice = 450;
            p2.Category = "Kids Wear";
            p2.SubCategory = "T-Shirt";
            p2.Brand = "easy";
            p2.Size = 1;
            p2.Date = DateTime.Now;
            p2.LastSold = DateTime.Now;
            p2.TotalSell = 200;
            p2.TotalViewed = 5;
            p2.Star = 3;
            Console.WriteLine(ps.Insert(p2));

            Product p3 = new Product();
            p3.ProductName = "Avenger T Shirt";
            p3.Features = "Loreum Ispum";
            p3.Quantity = 10;
            p3.BuyingPrice = 44;
            p3.SellingPrice = 450;
            p3.Category = "Kids Wear";
            p3.SubCategory = "T-Shirt";
            p3.Brand = "easy";
            p3.Size = 2;
            p3.Date = DateTime.Now;
            p3.LastSold = DateTime.Now;
            p3.TotalSell = 200;
            p3.TotalViewed = 5;
            p3.Star = 5;
            Console.WriteLine(ps.Insert(p3));


            Product p8 = new Product();
            p8.ProductName = "One Piece T Shirt";
            p8.Features = "Loreum Ispum";
            p8.Quantity = 10;
            p8.BuyingPrice = 480;
            p8.SellingPrice = 500;
            p8.Category = "Kids Wear";
            p8.SubCategory = "T-Shirt";
            p8.Brand = "arong";
            p8.Size = 2;
            p8.Date = DateTime.Now;
            p8.LastSold = DateTime.Now;
            p8.TotalSell = 200;
            p8.TotalViewed = 5;
            p8.Star = 4;
            Console.WriteLine(ps.Insert(p8));

            Product p9 = new Product();
            p9.ProductName = "Doraemon T Shirt";
            p9.Features = "Loreum Ispum";
            p9.Quantity = 10;
            p9.BuyingPrice = 480;
            p9.SellingPrice = 500;
            p9.Category = "Kids Wear";
            p9.SubCategory = "T-Shirt";
            p9.Brand = "arong";
            p9.Size = 2;
            p9.Date = DateTime.Now;
            p9.LastSold = DateTime.Now;
            p9.TotalSell = 200;
            p9.TotalViewed = 5;
            p9.Star = 3;
            Console.WriteLine(ps.Insert(p9));



            Product p11 = new Product();
            p11.ProductName = "Sonic T Shirt";
            p11.Features = "Loreum Ispum";
            p11.Quantity = 10;
            p11.BuyingPrice = 480;
            p11.SellingPrice = 500;
            p11.Category = "Kids Wear";
            p11.SubCategory = "T-Shirt";
            p11.Brand = "arong";
            p11.Size = 3;
            p11.Date = DateTime.Now;
            p11.LastSold = DateTime.Now;
            p11.TotalSell = 200;
            p11.TotalViewed = 5;
            p11.Star = 5;
            Console.WriteLine(ps.Insert(p11));


            Product p10 = new Product();
            p10.ProductName = "Superman T Shirt";
            p10.Features = "Loreum Ispum";
            p10.Quantity = 10;
            p10.BuyingPrice = 480;
            p10.SellingPrice = 500;
            p10.Category = "Kids Wear";
            p10.SubCategory = "T-Shirt";
            p10.Brand = "arong";
            p10.Size = 3;
            p10.Date = DateTime.Now;
            p10.LastSold = DateTime.Now;
            p10.TotalSell = 200;
            p10.TotalViewed = 5;
            p10.Star = 5;
            Console.WriteLine(ps.Insert(p11));










            ///shirt



            Product p4 = new Product();
            p4.ProductName = "Black Shirt";
            p4.Features = "Loreum Ispum";
            p4.Quantity = 10;
            p4.BuyingPrice = 1300;
            p4.SellingPrice = 1350;
            p4.Category = "Mens Wear";
            p4.SubCategory = "Shirt";
            p4.Brand = "yellow";
            p4.Size = 1;
            p4.Date = DateTime.Now;
            p4.LastSold = DateTime.Now;
            p4.TotalSell = 200;
            p4.TotalViewed = 5;
            p4.Star = 3;
            Console.WriteLine(ps.Insert(p4));

            Product p5 = new Product();
            p5.ProductName = "Blue Shirt";
            p5.Features = "Loreum Ispum";
            p5.Quantity = 10;
            p5.BuyingPrice = 1300;
            p5.SellingPrice = 1350;
            p5.Category = "Mens Wear";
            p5.SubCategory = "Shirt";
            p5.Brand = "yellow";
            p5.Size = 3;
            p5.Date = DateTime.Now;
            p5.LastSold = DateTime.Now;
            p5.TotalSell = 200;
            p5.TotalViewed = 5;
            p5.Star = 4;
            Console.WriteLine(ps.Insert(p5));

            Product p6 = new Product();
            p6.ProductName = "Maroon Shirt";
            p6.Features = "Loreum Ispum";
            p6.Quantity = 10;
            p6.BuyingPrice = 1200;
            p6.SellingPrice = 1280;
            p6.Category = "Mens Wear";
            p6.SubCategory = "Shirt";
            p6.Brand = "yellow";
            p6.Size = 1;
            p6.Date = DateTime.Now;
            p6.LastSold = DateTime.Now;
            p6.TotalSell = 200;
            p6.TotalViewed = 5;
            p6.Star = 5;
            Console.WriteLine(ps.Insert(p6));

            Product p7 = new Product();
            p7.ProductName = "Check Shirt";
            p7.Features = "Loreum Ispum";
            p7.Quantity = 10;
            p7.BuyingPrice = 1200;
            p7.SellingPrice = 1280;
            p7.Category = "Mens Wear";
            p7.SubCategory = "Shirt";
            p7.Brand = "arong";
            p7.Size = 1;
            p7.Date = DateTime.Now;
            p7.LastSold = DateTime.Now;
            p7.TotalSell = 200;
            p7.TotalViewed = 5;
            p7.Star = 3;
            Console.WriteLine(ps.Insert(p7));


            Product p12 = new Product();
            p12.ProductName = "Red Shirt";
            p12.Features = "Loreum Ispum";
            p12.Quantity = 10;
            p12.BuyingPrice = 1200;
            p12.SellingPrice = 1280;
            p12.Category = "Mens Wear";
            p12.SubCategory = "Shirt";
            p12.Brand = "arong";
            p12.Size = 2;
            p12.Date = DateTime.Now;
            p12.LastSold = DateTime.Now;
            p12.TotalSell = 200;
            p12.TotalViewed = 5;
            p12.Star = 4;
            Console.WriteLine(ps.Insert(p12));


            Product p13 = new Product();
            p13.ProductName = "Sky Blue Shirt";
            p10.Features = "Loreum Ispum";
            p13.Quantity = 10;
            p13.BuyingPrice = 1200;
            p13.SellingPrice = 1280;
            p13.Category = "Mens Wear";
            p13.SubCategory = "Shirt";
            p13.Brand = "ectasy";
            p10.Size = 2;
            p13.Date = DateTime.Now;
            p13.LastSold = DateTime.Now;
            p1.TotalSell = 200;
            p1.TotalViewed = 5;
            p1.Star = 5;
            Console.WriteLine(ps.Insert(p13));


            Product p14 = new Product();
            p14.ProductName = "White Shirt";
            p10.Features = "Loreum Ispum";
            p14.Quantity = 10;
            p14.BuyingPrice = 1200;
            p14.SellingPrice = 1280;
            p14.Category = "Mens Wear";
            p14.SubCategory = "Shirt";
            p14.Brand = "ectasy";
            p10.Size = 3;
            p14.Date = DateTime.Now;
            p14.LastSold = DateTime.Now;
            p1.TotalSell = 200;
            p1.TotalViewed = 5;
            p1.Star = 3;
            Console.WriteLine(ps.Insert(p14));






            ///pant

            Product p15 = new Product();
            p15.ProductName = "Biker-Jeans";
            p15.Features = "Loreum Ispum";
            p15.Quantity = 10;
            p15.BuyingPrice = 1200;
            p15.SellingPrice = 1280;
            p15.Category = "Mens Wear";
            p15.SubCategory = "Pant";
            p15.Brand = "ectasy";
            p15.Size = 2;
            p15.Date = DateTime.Now;
            p15.LastSold = DateTime.Now;
            p15.TotalSell = 200;
            p15.TotalViewed = 5;
            p15.Star = 4;
            Console.WriteLine(ps.Insert(p15));

            Product p16 = new Product();
            p16.ProductName = "Black Pant";
            p16.Features = "Loreum Ispum";
            p16.Quantity = 10;
            p16.BuyingPrice = 2000;
            p16.SellingPrice = 2080;
            p16.Category = "Mens Wear";
            p16.SubCategory = "Pant";
            p16.Brand = "ectasy";
            p10.Size = 2;
            p16.Date = DateTime.Now;
            p16.LastSold = DateTime.Now;
            p16.TotalSell = 200;
            p16.TotalViewed = 5;
            p16.Star = 5;
            Console.WriteLine(ps.Insert(p16));

            Product p17 = new Product();
            p17.ProductName = "Gavading Pant";
            p17.Features = "Loreum Ispum";
            p17.Quantity = 10;
            p17.BuyingPrice = 2000;
            p17.SellingPrice = 2080;
            p17.Category = "Mens Wear";
            p17.SubCategory = "Pant";
            p17.Brand = "yellow";
            p17.Size = 1;
            p17.Date = DateTime.Now;
            p17.LastSold = DateTime.Now;
            p17.TotalSell = 200;
            p17.TotalViewed = 5;
            p17.Star = 3;
            Console.WriteLine(ps.Insert(p17));


            Product p18 = new Product();
            p18.ProductName = "Gray Pant";
            p18.Features = "Loreum Ispum";
            p18.Quantity = 10;
            p18.BuyingPrice = 2000;
            p18.SellingPrice = 2080;
            p18.Category = "Mens Wear";
            p18.SubCategory = "Pant";
            p18.Brand = "yellow";
            p18.Size = 1;
            p18.Date = DateTime.Now;
            p18.LastSold = DateTime.Now;
            p18.TotalSell = 200;
            p18.TotalViewed = 5;
            p18.Star = 4;
            Console.WriteLine(ps.Insert(p18));

            Product p19 = new Product();
            p19.ProductName = "jack-jones-jeans";
            p19.Features = "Loreum Ispum";
            p19.Quantity = 10;
            p19.BuyingPrice = 2000;
            p19.SellingPrice = 2080;
            p19.Category = "Mens Wear";
            p19.SubCategory = "Pant";
            p19.Brand = "yellow";
            p19.Size = 1;
            p19.Date = DateTime.Now;
            p19.LastSold = DateTime.Now;
            p19.TotalSell = 200;
            p19.TotalViewed = 5;
            p19.Star = 5;
            Console.WriteLine(ps.Insert(p19));

            Product p20 = new Product();
            p20.ProductName = "Tommy-jones-jeans";
            p20.Features = "Loreum Ispum";
            p20.Quantity = 10;
            p20.BuyingPrice = 2000;
            p20.SellingPrice = 2080;
            p20.Category = "Mens Wear";
            p20.SubCategory = "Pant";
            p20.Brand = "yellow";
            p20.Size = 3;
            p20.Date = DateTime.Now;
            p20.LastSold = DateTime.Now;
            p20.TotalSell = 200;
            p20.TotalViewed = 5;
            p20.Star = 3;
            Console.WriteLine(ps.Insert(p20));

            Product p21 = new Product();
            p21.ProductName = "White Pant";
            p21.Features = "Loreum Ispum";
            p21.Quantity = 10;
            p21.BuyingPrice = 2000;
            p21.SellingPrice = 2080;
            p21.Category = "Mens Wear";
            p21.SubCategory = "Pant";
            p21.Brand = "yellow";
            p21.Size = 3;
            p21.Date = DateTime.Now;
            p21.LastSold = DateTime.Now;
            p21.TotalSell = 200;
            p21.TotalViewed = 5;
            p21.Star = 4;
            Console.WriteLine(ps.Insert(p21));






            ///panjabi

            Product p22 = new Product();
            p22.ProductName = "Blue Pnajabi";
            p22.Features = "Loreum Ispum";
            p22.Quantity = 10;
            p22.BuyingPrice = 2000;
            p22.SellingPrice = 2080;
            p22.Category = "Mens Wear";
            p22.SubCategory = "Panjabi";
            p22.Brand = "yellow";
            p22.Size = 2;
            p22.Date = DateTime.Now;
            p22.LastSold = DateTime.Now;
            p22.TotalSell = 200;
            p22.TotalViewed = 5;
            p22.Star = 4;
            Console.WriteLine(ps.Insert(p22));


            Product p23 = new Product();
            p23.ProductName = "Embrodari panjabi";
            p23.Features = "Loreum Ispum";
            p23.Quantity = 10;
            p23.BuyingPrice = 2000;
            p23.SellingPrice = 2080;
            p23.Category = "Mens Wear";
            p23.SubCategory = "Panjabi";
            p23.Brand = "yellow";
            p23.Size = 1;
            p23.Date = DateTime.Now;
            p23.LastSold = DateTime.Now;
            p23.TotalSell = 200;
            p23.TotalViewed = 5;
            p23.Star = 5;
            Console.WriteLine(ps.Insert(p23));

            Product p24 = new Product();
            p24.ProductName = "Red Panjabi";
            p24.Features = "Loreum Ispum";
            p24.Quantity = 10;
            p24.BuyingPrice = 2000;
            p24.SellingPrice = 2080;
            p24.Category = "Mens Wear";
            p24.SubCategory = "Panjabi";
            p24.Brand = "easy";
            p24.Size = 1;
            p24.Date = DateTime.Now;
            p24.LastSold = DateTime.Now;
            p24.TotalSell = 200;
            p24.TotalViewed = 5;
            p24.Star = 3;
            Console.WriteLine(ps.Insert(p24));


            Product p25 = new Product();
            p25.ProductName = "White Panjabi";
            p25.Features = "Loreum Ispum";
            p25.Quantity = 10;
            p25.BuyingPrice = 2000;
            p25.SellingPrice = 2080;
            p25.Category = "Mens Wear";
            p25.SubCategory = "Panjabi";
            p25.Brand = "easy";
            p25.Size = 2;
            p25.Date = DateTime.Now;
            p25.LastSold = DateTime.Now;
            p25.TotalSell = 200;
            p25.TotalViewed = 5;
            p25.Star = 4;
            Console.WriteLine(ps.Insert(p25));


            Product p26 = new Product();
            p26.ProductName = "Yellow Panjabi";
            p26.Features = "Loreum Ispum";
            p26.Quantity = 10;
            p26.BuyingPrice = 2000;
            p26.SellingPrice = 2080;
            p26.Category = "Mens Wear";
            p26.SubCategory = "Panjabi";
            p26.Brand = "arong";
            p26.Size = 2;
            p26.Date = DateTime.Now;
            p26.LastSold = DateTime.Now;
            p26.TotalSell = 200;
            p26.TotalViewed = 5;
            p26.Star = 5;
            Console.WriteLine(ps.Insert(p26));

            Product p27 = new Product();
            p27.ProductName = "Green Panjabi";
            p27.Features = "Loreum Ispum";
            p27.Quantity = 10;
            p27.BuyingPrice = 2000;
            p27.SellingPrice = 2080;
            p27.Category = "Mens Wear";
            p27.SubCategory = "Panjabi";
            p27.Brand = "arong";
            p27.Size = 1;
            p27.Date = DateTime.Now;
            p27.LastSold = DateTime.Now;
            p27.TotalSell = 200;
            p27.TotalViewed = 5;
            p27.Star = 3;
            Console.WriteLine(ps.Insert(p27));

            Product p28 = new Product();
            p28.ProductName = "Black Panjabi";
            p28.Features = "Loreum Ispum";
            p28.Quantity = 10;
            p28.BuyingPrice = 2000;
            p28.SellingPrice = 2080;
            p28.Category = "Mens Wear";
            p28.SubCategory = "Panjabi";
            p28.Brand = "arong";
            p28.Size = 2;
            p28.Date = DateTime.Now;
            p28.LastSold = DateTime.Now;
            p28.TotalSell = 200;
            p28.TotalViewed = 5;
            p28.Star = 4;
            Console.WriteLine(ps.Insert(p28));




            ///saree


            Product p29 = new Product();
            p29.ProductName = "Black Saree";
            p29.Features = "Loreum Ispum";
            p29.Quantity = 10;
            p29.BuyingPrice = 3000;
            p29.SellingPrice = 3200;
            p29.Category = "Womens Wear";
            p29.SubCategory = "Saree";
            p29.Brand = "arong";
            p29.Size = 0;
            p29.Date = DateTime.Now;
            p29.LastSold = DateTime.Now;
            p29.LastSold = DateTime.Now;
            p29.TotalSell = 200;
            p29.TotalViewed = 5;
            p29.Star = 5;
            Console.WriteLine(ps.Insert(p29));

            Product p30 = new Product();
            p30.ProductName = "Green Saree";
            p30.Features = "Loreum Ispum";
            p30.Quantity = 10;
            p30.BuyingPrice = 3000;
            p30.SellingPrice = 3200;
            p30.Category = "Womens Wear";
            p30.SubCategory = "Saree";
            p30.Brand = "arong";
            p30.Size = 0;
            p30.Date = DateTime.Now;
            p30.LastSold = DateTime.Now;
            p30.LastSold = DateTime.Now;
            p30.TotalSell = 200;
            p30.TotalViewed = 5;
            p30.Star = 3;
            Console.WriteLine(ps.Insert(p30));


            Product p31 = new Product();
            p31.ProductName = "Printed Saree";
            p31.Features = "Loreum Ispum";
            p31.Quantity = 10;
            p31.BuyingPrice = 3000;
            p31.SellingPrice = 3200;
            p31.Category = "Womens Wear";
            p31.SubCategory = "Saree";
            p31.Brand = "arong";
            p31.Size = 0;
            p31.Date = DateTime.Now;
            p31.LastSold = DateTime.Now;
            p31.LastSold = DateTime.Now;
            p31.TotalSell = 200;
            p31.TotalViewed = 5;
            p31.Star = 4;
            Console.WriteLine(ps.Insert(p31));

            Product p32 = new Product();
            p32.ProductName = "Red saree";
            p32.Features = "Loreum Ispum";
            p32.Quantity = 10;
            p32.BuyingPrice = 3000;
            p32.SellingPrice = 3200;
            p32.Category = "Womens Wear";
            p32.SubCategory = "Saree";
            p32.Brand = "arong";
            p32.Size = 0;
            p32.Date = DateTime.Now;
            p32.LastSold = DateTime.Now;
            p32.LastSold = DateTime.Now;
            p32.TotalSell = 200;
            p32.TotalViewed = 5;
            p32.Star = 5;
            Console.WriteLine(ps.Insert(p32));

            Product p33 = new Product();
            p33.ProductName = "Shiffon Saree";
            p33.Features = "Loreum Ispum";
            p33.Quantity = 10;
            p33.BuyingPrice = 3000;
            p33.SellingPrice = 3200;
            p33.Category = "Womens Wear";
            p33.SubCategory = "Saree";
            p33.Brand = "arong";
            p33.Size = 0;
            p33.Date = DateTime.Now;
            p33.LastSold = DateTime.Now;
            p33.LastSold = DateTime.Now;
            p33.TotalSell = 200;
            p33.TotalViewed = 5;
            p33.Star = 3;
            Console.WriteLine(ps.Insert(p33));


            Product p34 = new Product();
            p34.ProductName = "Sky Blue Saree";
            p34.Features = "Loreum Ispum";
            p34.Quantity = 10;
            p34.BuyingPrice = 3000;
            p34.SellingPrice = 3200;
            p34.Category = "Womens Wear";
            p34.SubCategory = "Saree";
            p34.Brand = "arong";
            p34.Size = 0;
            p34.Date = DateTime.Now;
            p34.LastSold = DateTime.Now;
            p34.LastSold = DateTime.Now;
            p34.TotalSell = 200;
            p34.TotalViewed = 5;
            p34.Star = 4;
            Console.WriteLine(ps.Insert(p34));

            Product p35 = new Product();
            p35.ProductName = "Pink Saree";
            p35.Features = "Loreum Ispum";
            p35.Quantity = 10;
            p35.BuyingPrice = 3000;
            p35.SellingPrice = 3200;
            p35.Category = "Womens Wear";
            p35.SubCategory = "Saree";
            p35.Brand = "arong";
            p35.Size = 0;
            p35.Date = DateTime.Now;
            p35.LastSold = DateTime.Now;
            p35.LastSold = DateTime.Now;
            p35.TotalSell = 200;
            p35.TotalViewed = 5;
            p35.Star = 5;
            Console.WriteLine(ps.Insert(p35));



            ///three piece


            Product p36 = new Product();
            p36.ProductName = "Blue Three Piece";
            p36.Features = "Loreum Ispum";
            p36.Quantity = 10;
            p36.BuyingPrice = 3000;
            p36.SellingPrice = 3200;
            p36.Category = "Womens Wear";
            p36.SubCategory = "Three-Piece";
            p36.Brand = "arong";
            p36.Size = 1;
            p36.Date = DateTime.Now;
            p36.LastSold = DateTime.Now;
            p36.LastSold = DateTime.Now;
            p36.TotalSell = 200;
            p36.TotalViewed = 5;
            p36.Star = 3;
            Console.WriteLine(ps.Insert(p36));


            Product p37 = new Product();
            p37.ProductName = "Pink Three-Piece";
            p37.Features = "Loreum Ispum";
            p37.Quantity = 10;
            p37.BuyingPrice = 3000;
            p37.SellingPrice = 3200;
            p37.Category = "Womens Wear";
            p37.SubCategory = "Three-Piece";
            p37.Brand = "arong";
            p37.Size = 1;
            p37.Date = DateTime.Now;
            p37.LastSold = DateTime.Now;
            p37.LastSold = DateTime.Now;
            p37.TotalSell = 200;
            p37.TotalViewed = 5;
            p37.Star = 4;
            Console.WriteLine(ps.Insert(p37));


            Product p38 = new Product();
            p38.ProductName = "Purple Three-Piece";
            p21.Features = "Loreum Ispum";
            p38.Quantity = 10;
            p38.BuyingPrice = 3000;
            p38.SellingPrice = 3200;
            p38.Category = "Womens Wear";
            p38.SubCategory = "Three-Piece";
            p38.Brand = "arong";
            p21.Size = 2;
            p38.Date = DateTime.Now;
            p38.LastSold = DateTime.Now;
            p21.LastSold = DateTime.Now;
            p21.TotalSell = 200;
            p21.TotalViewed = 5;
            p21.Star = 5;
            Console.WriteLine(ps.Insert(p38));

            Product p39 = new Product();
            p39.ProductName = "Black Three-Piece";
            p39.Features = "Loreum Ispum";
            p39.Quantity = 10;
            p39.BuyingPrice = 3000;
            p39.SellingPrice = 3200;
            p39.Category = "Womens Wear";
            p39.SubCategory = "Three-Piece";
            p39.Brand = "arong";
            p39.Size = 3;
            p39.Date = DateTime.Now;
            p39.LastSold = DateTime.Now;
            p39.LastSold = DateTime.Now;
            p39.TotalSell = 200;
            p39.TotalViewed = 5;
            p39.Star = 3;
            Console.WriteLine(ps.Insert(p39));

            Product p40 = new Product();
            p40.ProductName = "White Three-Piece";
            p40.Features = "Loreum Ispum";
            p40.Quantity = 10;
            p40.BuyingPrice = 3000;
            p40.SellingPrice = 3200;
            p40.Category = "Womens Wear";
            p40.SubCategory = "Three-Piece";
            p40.Brand = "arong";
            p40.Size = 3;
            p40.Date = DateTime.Now;
            p40.LastSold = DateTime.Now;
            p40.LastSold = DateTime.Now;
            p40.TotalSell = 200;
            p40.TotalViewed = 5;
            p40.Star = 4;
            Console.WriteLine(ps.Insert(p4));


            Product p41 = new Product();
            p41.ProductName = "Embrodery Three-Piece";
            p41.Features = "Loreum Ispum";
            p41.Quantity = 10;
            p41.BuyingPrice = 3000;
            p41.SellingPrice = 3200;
            p41.Category = "Womens Wear";
            p41.SubCategory = "Three-Piece";
            p41.Brand = "arong";
            p41.Size = 2;
            p41.Date = DateTime.Now;
            p41.LastSold = DateTime.Now;
            p41.LastSold = DateTime.Now;
            p41.TotalSell = 200;
            p41.TotalViewed = 5;
            p41.Star = 5;
            Console.WriteLine(ps.Insert(p41));

            Product p42 = new Product();
            p42.ProductName = "Red Three-Piece";
            p42.Features = "Loreum Ispum";
            p42.Quantity = 10;
            p42.BuyingPrice = 3000;
            p42.SellingPrice = 3200;
            p42.Category = "Womens Wear";
            p42.SubCategory = "Three-Piece";
            p42.Brand = "arong";
            p42.Size = 1;
            p42.Date = DateTime.Now;
            p42.LastSold = DateTime.Now;
            p42.LastSold = DateTime.Now;
            p42.TotalSell = 200;
            p42.TotalViewed = 5;
            p42.Star = 4;
            Console.WriteLine(ps.Insert(p42));



            ////kids pant

            Product p43 = new Product();
            p43.ProductName = "Summer-shorts";
            p43.Features = "Loreum Ispum";
            p43.Quantity = 430;
            p43.BuyingPrice = 44;
            p43.SellingPrice = 450;
            p43.Category = "Kids Wear";
            p43.SubCategory = "Pant";
            p43.Brand = "easy";
            p43.Size = 3;
            p43.Date = DateTime.Now;
            p43.LastSold = DateTime.Now;
            p43.TotalSell = 200;
            p43.TotalViewed = 5;
            p43.Star = 4;
            Console.WriteLine(ps.Insert(p43));


            Product p44 = new Product();
            p44.ProductName = "children-cotton-pant";
            p44.Features = "Loreum Ispum";
            p44.Quantity = 44;
            p44.BuyingPrice = 44;
            p44.SellingPrice = 450;
            p44.Category = "Kids Wear";
            p44.SubCategory = "Pant";
            p44.Brand = "easy";
            p44.Size = 3;
            p44.Date = DateTime.Now;
            p44.LastSold = DateTime.Now;
            p44.TotalSell = 200;
            p44.TotalViewed = 5;
            p44.Star = 4;
            Console.WriteLine(ps.Insert(p44));

            Product p45 = new Product();
            p45.ProductName = "Kids-Pant-Children-Jeans";
            p45.Features = "Loreum Ispum";
            p45.Quantity = 450;
            p45.BuyingPrice = 44;
            p45.SellingPrice = 450;
            p45.Category = "Kids Wear";
            p45.SubCategory = "Pant";
            p45.Brand = "easy";
            p45.Size = 1;
            p45.Date = DateTime.Now;
            p45.LastSold = DateTime.Now;
            p45.TotalSell = 200;
            p45.TotalViewed = 5;
            p45.Star = 4;
            Console.WriteLine(ps.Insert(p45));

            Product p46 = new Product();
            p46.ProductName = "Kids-Pant-Fashion-Light-Blue-Jean";
            p46.Features = "Loreum Ispum";
            p46.Quantity = 460;
            p46.BuyingPrice = 44;
            p46.SellingPrice = 450;
            p46.Category = "Kids Wear";
            p46.SubCategory = "Pant";
            p46.Brand = "easy";
            p46.Size = 1;
            p46.Date = DateTime.Now;
            p46.LastSold = DateTime.Now;
            p46.TotalSell = 200;
            p46.TotalViewed = 5;
            p46.Star = 3;
            Console.WriteLine(ps.Insert(p46));

            Product p47 = new Product();
            p47.ProductName = "Three Quarter";
            p47.Features = "Loreum Ispum";
            p47.Quantity = 470;
            p47.BuyingPrice = 44;
            p47.SellingPrice = 450;
            p47.Category = "Kids Wear";
            p47.SubCategory = "Pant";
            p47.Brand = "easy";
            p47.Size = 1;
            p47.Date = DateTime.Now;
            p47.LastSold = DateTime.Now;
            p47.TotalSell = 200;
            p47.TotalViewed = 5;
            p47.Star = 4;
            Console.WriteLine(ps.Insert(p47));

            Product p48 = new Product();
            p48.ProductName = "Moana Girl Jeans";
            p48.Features = "Loreum Ispum";
            p48.Quantity = 480;
            p48.BuyingPrice = 44;
            p48.SellingPrice = 450;
            p48.Category = "Kids Wear";
            p48.SubCategory = "Pant";
            p48.Brand = "easy";
            p48.Size = 2;
            p48.Date = DateTime.Now;
            p48.LastSold = DateTime.Now;
            p48.TotalSell = 200;
            p48.TotalViewed = 5;
            p48.Star = 5;
            Console.WriteLine(ps.Insert(p48));


            Product p49 = new Product();
            p49.ProductName = "Cotton Pant";
            p49.Features = "Loreum Ispum";
            p49.Quantity = 490;
            p49.BuyingPrice = 44;
            p49.SellingPrice = 450;
            p49.Category = "Kids Wear";
            p49.SubCategory = "Pant";
            p49.Brand = "easy";
            p49.Size = 2;
            p49.Date = DateTime.Now;
            p49.LastSold = DateTime.Now;
            p49.TotalSell = 200;
            p49.TotalViewed = 5;
            p49.Star = 4;
            Console.WriteLine(ps.Insert(p49));



            ///Handbag




            Product p50 = new Product();
            p50.ProductName = "Blue Handbag";
            p50.Features = "Loreum Ispum";
            p50.Quantity = 12;
            p50.BuyingPrice = 1200;
            p50.SellingPrice = 140;
            p50.Category = "Accessories";
            p50.SubCategory = "Handbag";
            p50.Brand = "ectasy";
            p50.Size = 0;
            p50.Date = DateTime.Now;
            p50.LastSold = DateTime.Now;
            p50.TotalSell = 200;
            p50.TotalViewed = 5;
            p50.Star = 3;
            Console.WriteLine(ps.Insert(p50));


            Product p51 = new Product();
            p51.ProductName = "Brown Handbag";
            p51.Features = "Loreum Ispum";
            p51.Quantity = 12;
            p51.BuyingPrice = 1200;
            p51.SellingPrice = 140;
            p51.Category = "Accessories";
            p51.SubCategory = "Handbag";
            p51.Brand = "ectasy";
            p51.Size = 0;
            p51.Date = DateTime.Now;
            p51.LastSold = DateTime.Now;
            p51.TotalSell = 200;
            p51.TotalViewed = 5;
            p51.Star = 4;
            Console.WriteLine(ps.Insert(p51));



            Product p52 = new Product();
            p52.ProductName = "Green Handbag";
            p52.Features = "Loreum Ispum";
            p52.Quantity = 12;
            p52.BuyingPrice = 1200;
            p52.SellingPrice = 140;
            p52.Category = "Accessories";
            p52.SubCategory = "Handbag";
            p52.Brand = "ectasy";
            p52.Size = 0;
            p52.Date = DateTime.Now;
            p52.LastSold = DateTime.Now;
            p52.TotalSell = 200;
            p52.TotalViewed = 5;
            p52.Star = 5;
            Console.WriteLine(ps.Insert(p52));


            Product p53 = new Product();
            p53.ProductName = "Pink Handbag";
            p53.Features = "Loreum Ispum";
            p53.Quantity = 12;
            p53.BuyingPrice = 1200;
            p53.SellingPrice = 140;
            p53.Category = "Accessories";
            p53.SubCategory = "Handbag";
            p53.Brand = "ectasy";
            p53.Size = 0;
            p53.Date = DateTime.Now;
            p53.LastSold = DateTime.Now;
            p53.TotalSell = 200;
            p53.TotalViewed = 5;
            p53.Star = 4;
            Console.WriteLine(ps.Insert(p53));


            Product p54 = new Product();
            p54.ProductName = "White Handbag";
            p54.Features = "Loreum Ispum";
            p54.Quantity = 12;
            p54.BuyingPrice = 1200;
            p54.SellingPrice = 140;
            p54.Category = "Accessories";
            p54.SubCategory = "Handbag";
            p54.Brand = "ectasy";
            p54.Size = 0;
            p54.Date = DateTime.Now;
            p54.LastSold = DateTime.Now;
            p54.TotalSell = 200;
            p54.TotalViewed = 5;
            p54.Star = 4;
            Console.WriteLine(ps.Insert(p54));


            Product p55 = new Product();
            p55.ProductName = "Red Handbag";
            p55.Features = "Loreum Ispum";
            p55.Quantity = 12;
            p55.BuyingPrice = 1200;
            p55.SellingPrice = 140;
            p55.Category = "Accessories";
            p55.SubCategory = "Handbag";
            p55.Brand = "ectasy";
            p55.Size = 0;
            p55.Date = DateTime.Now;
            p55.LastSold = DateTime.Now;
            p55.TotalSell = 200;
            p55.TotalViewed = 5;
            p55.Star = 5;
            Console.WriteLine(ps.Insert(p55));

            Product p56 = new Product();
            p56.ProductName = "Black Handbag";
            p56.Features = "Loreum Ispum";
            p56.Quantity = 12;
            p56.BuyingPrice = 1200;
            p56.SellingPrice = 140;
            p56.Category = "Accessories";
            p56.SubCategory = "Handbag";
            p56.Brand = "ectasy";
            p56.Size = 0;
            p56.Date = DateTime.Now;
            p56.LastSold = DateTime.Now;
            p56.TotalSell = 200;
            p56.TotalViewed = 5;
            p56.Star = 4;
            Console.WriteLine(ps.Insert(p56));



            ///sunglass


            Product p57 = new Product();
            p57.ProductName = "Armani Sunglass";
            p57.Features = "Loreum Ispum";
            p57.Quantity = 12;
            p57.BuyingPrice = 200;
            p57.SellingPrice = 220;
            p57.Category = "Accessories";
            p57.SubCategory = "Sunglass";
            p57.Brand = "ectasy";
            p57.Size = 0;
            p57.Date = DateTime.Now;
            p57.LastSold = DateTime.Now;
            p57.TotalSell = 200;
            p57.TotalViewed = 5;
            p57.Star = 5;
            Console.WriteLine(ps.Insert(p57));


            Product p58 = new Product();
            p58.ProductName = "Black Shaded Sunglass";
            p58.Features = "Loreum Ispum";
            p58.Quantity = 12;
            p58.BuyingPrice = 200;
            p58.SellingPrice = 220;
            p58.Category = "Accessories";
            p58.SubCategory = "Sunglass";
            p58.Brand = "ectasy";
            p58.Size = 0;
            p58.Date = DateTime.Now;
            p58.LastSold = DateTime.Now;
            p58.TotalSell = 200;
            p58.TotalViewed = 5;
            p58.Star = 4;
            Console.WriteLine(ps.Insert(p58));


            Product p59 = new Product();
            p59.ProductName = "Brown Shaded Sunglass";
            p59.Features = "Loreum Ispum";
            p59.Quantity = 12;
            p59.BuyingPrice = 200;
            p59.SellingPrice = 220;
            p59.Category = "Accessories";
            p59.SubCategory = "Sunglass";
            p59.Brand = "ectasy";
            p59.Size = 0;
            p59.Date = DateTime.Now;
            p59.LastSold = DateTime.Now;
            p59.TotalSell = 200;
            p59.TotalViewed = 5;
            p59.Star = 3;
            Console.WriteLine(ps.Insert(p59));

            Product p60 = new Product();
            p60.ProductName = "Club Master Sunglass";
            p60.Features = "Loreum Ispum";
            p60.Quantity = 12;
            p60.BuyingPrice = 200;
            p60.SellingPrice = 220;
            p60.Category = "Accessories";
            p60.SubCategory = "Sunglass";
            p60.Brand = "ectasy";
            p60.Size = 0;
            p60.Date = DateTime.Now;
            p60.LastSold = DateTime.Now;
            p60.TotalSell = 200;
            p60.TotalViewed = 5;
            p60.Star = 4;
            Console.WriteLine(ps.Insert(p60));


            Product p61 = new Product();
            p61.ProductName = "Red Shaded Sunglass";
            p61.Features = "Loreum Ispum";
            p61.Quantity = 12;
            p61.BuyingPrice = 200;
            p61.SellingPrice = 220;
            p61.Category = "Accessories";
            p61.SubCategory = "Sunglass";
            p61.Brand = "ectasy";
            p61.Size = 0;
            p61.Date = DateTime.Now;
            p61.LastSold = DateTime.Now;
            p61.TotalSell = 200;
            p61.TotalViewed = 5;
            p61.Star = 3;
            Console.WriteLine(ps.Insert(p61));


            Product p62 = new Product();
            p62.ProductName = "Round Sunglass";
            p62.Features = "Loreum Ispum";
            p62.Quantity = 12;
            p62.BuyingPrice = 200;
            p62.SellingPrice = 220;
            p62.Category = "Accessories";
            p62.SubCategory = "Sunglass";
            p62.Brand = "yellow";
            p62.Size = 0;
            p62.Date = DateTime.Now;
            p62.LastSold = DateTime.Now;
            p62.TotalSell = 200;
            p62.TotalViewed = 5;
            p62.Star = 4;
            Console.WriteLine(ps.Insert(p62));


            Product p63 = new Product();
            p63.ProductName = "Blue Shaded Sunglass";
            p63.Features = "Loreum Ispum";
            p63.Quantity = 12;
            p63.BuyingPrice = 200;
            p63.SellingPrice = 220;
            p63.Category = "Accessories";
            p63.SubCategory = "Sunglass";
            p63.Brand = "yellow";
            p63.Size = 0;
            p63.Date = DateTime.Now;
            p63.LastSold = DateTime.Now;
            p63.TotalSell = 200;
            p63.TotalViewed = 5;
            p63.Star = 5;
            Console.WriteLine(ps.Insert(p63));


            ///jwellery


            Product p64 = new Product();
            p64.ProductName = "Necklace Diamond ";
            p64.Features = "Loreum Ispum";
            p64.Quantity = 12;
            p64.BuyingPrice = 30000;
            p64.SellingPrice = 3400;
            p64.Category = "Accessories";
            p64.SubCategory = "Jewelery";
            p64.Brand = "yellow";
            p64.Size = 0;
            p64.Date = DateTime.Now;
            p64.LastSold = DateTime.Now;
            p64.TotalSell = 200;
            p64.TotalViewed = 5;
            p64.Star = 4;
            Console.WriteLine(ps.Insert(p64));


            Product p65 = new Product();
            p65.ProductName = "Necklace Love";
            p65.Features = "Loreum Ispum";
            p65.Quantity = 12;
            p65.BuyingPrice = 30000;
            p65.SellingPrice = 3400;
            p65.Category = "Accessories";
            p65.SubCategory = "Jewelery";
            p65.Brand = "yellow";
            p65.Size = 0;
            p65.Date = DateTime.Now;
            p65.LastSold = DateTime.Now;
            p65.TotalSell = 200;
            p65.TotalViewed = 5;
            p65.Star = 4;
            Console.WriteLine(ps.Insert(p65));


            Product p66 = new Product();
            p66.ProductName = "Ear Ring Oval";
            p66.Features = "Loreum Ispum";
            p66.Quantity = 12;
            p66.BuyingPrice = 300;
            p66.SellingPrice = 340;
            p66.Category = "Accessories";
            p66.SubCategory = "Jewelery";
            p66.Brand = "ectasy";
            p66.Size = 0;
            p66.Date = DateTime.Now;
            p66.LastSold = DateTime.Now;
            p66.TotalSell = 200;
            p66.TotalViewed = 5;
            p66.Star = 3;
            Console.WriteLine(ps.Insert(p66));

            Product p67 = new Product();
            p67.ProductName = "Round Ear Ring";
            p67.Features = "Loreum Ispum";
            p67.Quantity = 12;
            p67.BuyingPrice = 300;
            p67.SellingPrice = 340;
            p67.Category = "Accessories";
            p67.SubCategory = "Jewelery";
            p67.Brand = "ectasy";
            p67.Size = 0;
            p67.Date = DateTime.Now;
            p67.LastSold = DateTime.Now;
            p67.TotalSell = 200;
            p67.TotalViewed = 5;
            p67.Star = 4;
            Console.WriteLine(ps.Insert(p67));


            Product p68 = new Product();
            p68.ProductName = "Premium Ear Ring";
            p68.Features = "Loreum Ispum";
            p68.Quantity = 12;
            p68.BuyingPrice = 300;
            p68.SellingPrice = 340;
            p68.Category = "Accessories";
            p68.SubCategory = "Jewelery";
            p68.Brand = "ectasy";
            p68.Size = 0;
            p68.Date = DateTime.Now;
            p68.LastSold = DateTime.Now;
            p68.TotalSell = 200;
            p68.TotalViewed = 5;
            p68.Star = 4;
            Console.WriteLine(ps.Insert(p68));



            Product p69 = new Product();
            p69.ProductName = "Gold Platted Ear Ring";
            p69.Features = "Loreum Ispum";
            p69.Quantity = 12;
            p69.BuyingPrice = 300;
            p69.SellingPrice = 340;
            p69.Category = "Accessories";
            p69.SubCategory = "Jewelery";
            p69.Brand = "ectasy";
            p69.Size = 0;
            p69.Date = DateTime.Now;
            p69.LastSold = DateTime.Now;
            p69.TotalSell = 200;
            p69.TotalViewed = 5;
            p69.Star = 5;
            Console.WriteLine(ps.Insert(p69));


            Product p70 = new Product();
            p70.ProductName = "Pearl Ear Ring";
            p70.Features = "Loreum Ispum";
            p70.Quantity = 12;
            p70.BuyingPrice = 300;
            p70.SellingPrice = 340;
            p70.Category = "Accessories";
            p70.SubCategory = "Jewelery";
            p70.Brand = "ectasy";
            p70.Size = 0;
            p70.Date = DateTime.Now;
            p70.LastSold = DateTime.Now;
            p70.TotalSell = 200;
            p70.TotalViewed = 5;
            p70.Star = 4;
            Console.WriteLine(ps.Insert(p70));


            ////watch

            Product p71 = new Product();
            p71.ProductName = "MvMt Watch";
            p71.Features = "Loreum Ispum";
            p71.Quantity = 12;
            p71.BuyingPrice = 1200;
            p71.SellingPrice = 1300;
            p71.Category = "Accessories";
            p71.SubCategory = "Watch";
            p71.Brand = "ectasy";
            p71.Size = 0;
            p71.Date = DateTime.Now;
            p71.LastSold = DateTime.Now;
            p71.TotalSell = 200;
            p71.TotalViewed = 5;
            p71.Star = 4;
            Console.WriteLine(ps.Insert(p71));



            Product p72 = new Product();
            p72.ProductName = "Omega Watch";
            p72.Features = "Loreum Ispum";
            p72.Quantity = 12;
            p72.BuyingPrice = 1300;
            p72.SellingPrice = 1400;
            p72.Category = "Accessories";
            p72.SubCategory = "Watch";
            p72.Brand = "ectasy";
            p72.Size = 0;
            p72.Date = DateTime.Now;
            p72.LastSold = DateTime.Now;
            p72.TotalSell = 200;
            p72.TotalViewed = 5;
            p72.Star = 4;
            Console.WriteLine(ps.Insert(p72));



            Product p73 = new Product();
            p73.ProductName = "Espoir Watch";
            p73.Features = "Loreum Ispum";
            p73.Quantity = 12;
            p73.BuyingPrice = 1400;
            p73.SellingPrice = 1500;
            p73.Category = "Accessories";
            p73.SubCategory = "Watch";
            p73.Brand = "ectasy";
            p73.Size = 0;
            p73.Date = DateTime.Now;
            p73.LastSold = DateTime.Now;
            p73.TotalSell = 200;
            p73.TotalViewed = 5;
            p73.Star = 4;
            Console.WriteLine(ps.Insert(p73));



            Product p74 = new Product();
            p74.ProductName = "Fossil Watch";
            p74.Features = "Loreum Ispum";
            p74.Quantity = 12;
            p74.BuyingPrice = 1500;
            p74.SellingPrice = 1600;
            p74.Category = "Accessories";
            p74.SubCategory = "Watch";
            p74.Brand = "ectasy";
            p74.Size = 0;
            p74.Date = DateTime.Now;
            p74.LastSold = DateTime.Now;
            p74.TotalSell = 200;
            p74.TotalViewed = 5;
            p74.Star = 4;
            Console.WriteLine(ps.Insert(p74));



            Product p75 = new Product();
            p75.ProductName = "MvMt Watch";
            p75.Features = "Loreum Ispum";
            p75.Quantity = 12;
            p75.BuyingPrice = 1500;
            p75.SellingPrice = 1600;
            p75.Category = "Accessories";
            p75.SubCategory = "Watch";
            p75.Brand = "ectasy";
            p75.Size = 0;
            p75.Date = DateTime.Now;
            p75.LastSold = DateTime.Now;
            p75.TotalSell = 200;
            p75.TotalViewed = 5;
            p75.Star = 4;
            Console.WriteLine(ps.Insert(p75));



            Product p76 = new Product();
            p76.ProductName = "Bulova Watch";
            p76.Features = "Loreum Ispum";
            p76.Quantity = 12;
            p76.BuyingPrice = 1300;
            p76.SellingPrice = 1400;
            p76.Category = "Accessories";
            p76.SubCategory = "Watch";
            p76.Brand = "ectasy";
            p76.Size = 0;
            p76.Date = DateTime.Now;
            p76.LastSold = DateTime.Now;
            p76.TotalSell = 200;
            p76.TotalViewed = 5;
            p76.Star = 4;
            Console.WriteLine(ps.Insert(p76));



            Product p77 = new Product();
            p77.ProductName = "Matrix Watch";
            p77.Features = "Loreum Ispum";
            p77.Quantity = 12;
            p77.BuyingPrice = 1300;
            p77.SellingPrice = 1500;
            p77.Category = "Accessories";
            p77.SubCategory = "Watch";
            p77.Brand = "ectasy";
            p77.Size = 0;
            p77.Date = DateTime.Now;
            p77.LastSold = DateTime.Now;
            p77.TotalSell = 200;
            p77.TotalViewed = 5;
            p77.Star = 4;
            Console.WriteLine(ps.Insert(p77));








            //Address--------------------

            AddressService ads = new AddressService(e);

            Address a1 = new Address();

            a1.MemberId = 5;
            a1.MemberAddress = "Khilkhet,Dhaka";
            Console.WriteLine(ads.Insert(a1));

            Address a2 = new Address();
            a2.MemberId = 5;
            a2.MemberAddress = "Khilgaon,Dhaka";
            Console.WriteLine(ads.Insert(a2));


            Address a3 = new Address();
            a3.MemberId = 5;
            a3.MemberAddress = "Mirpur,Dhaka";
            Console.WriteLine(ads.Insert(a3));




            //Cart--------------------
            CartService cs = new CartService(e);

            Cart c1 = new Cart();
            c1.MemberId = 5;
            c1.ProductId = 1;
            c1.ProductName = "Kakashi T Shirt";
            c1.Quantity = 1;
            c1.UnitPrice = 450;
            Console.WriteLine(cs.Insert(c1));


            Cart c2 = new Cart();
            c2.MemberId = 5;
            c2.ProductId = 2;
            c2.ProductName = "Naruto T Shirt";
            c2.Quantity = 1;
            c2.UnitPrice = 450;
            Console.WriteLine(cs.Insert(c2));


            Cart c3 = new Cart();
            c3.MemberId = 6;
            c3.ProductId = 3;
            c3.ProductName = "Avenger T Shirt";
            c3.Quantity = 1;
            c3.UnitPrice = 450;
            Console.WriteLine(cs.Insert(c3));



            //Coupon--------------------

            CouponService cus = new CouponService(e);

            Coupon cu1 = new Coupon();
            cu1.MemberId = 5;
            cu1.Percentage = 20;
            cu1.Availability = "1";
            cu1.IssueDate = DateTime.Now;
            cu1.DeadlineDate = DateTime.Now;
            Console.WriteLine(cus.Insert(cu1));


            Coupon cu2 = new Coupon();
            cu2.MemberId = 5;
            cu2.Percentage = 20;
            cu2.Availability = "0";
            cu2.IssueDate = DateTime.Now;
            cu2.DeadlineDate = DateTime.Now;
            Console.WriteLine(cus.Insert(cu2));


            Coupon cu3 = new Coupon();
            cu3.MemberId = 5;
            cu3.Percentage = 30;
            cu3.Availability = "2";
            cu3.IssueDate = DateTime.Now;
            cu3.DeadlineDate = DateTime.Now;
            Console.WriteLine(cus.Insert(cu3));


            //DeliveryMan--------------------

            DeliveryManService dms = new DeliveryManService(e);

            DeliveryMan dm1 = new DeliveryMan();
            dm1.AssignedBy = 1;
            dm1.MemberId = 5;
            dm1.Availability = "1";
            dm1.Zone = "khilkhet";
            Console.WriteLine(dms.Insert(dm1));

            DeliveryMan dm2 = new DeliveryMan();
            dm2.AssignedBy = 1;
            dm2.MemberId = 6;
            dm2.Availability = "1";
            dm2.Zone = "Mirpur";
            Console.WriteLine(dms.Insert(dm2));







            //Dislike--------------------

            DislikeService ds = new DislikeService(e);

            Dislike d1 = new Dislike();
            d1.MemberId = 6;
            d1.ProductId = 1;
            Console.WriteLine(ds.Insert(d1));



            //like--------------------
            LikeService ls = new LikeService(e);

            Like l1 = new Like();
            l1.MemberId = 4;
            l1.ProductId = 1;
            Console.WriteLine(ls.Insert(l1));



            Like l2 = new Like();
            l2.MemberId = 4;
            l2.ProductId = 2;
            Console.WriteLine(ls.Insert(l2));

            //Invoice--------------------

            InvoiceService ivs = new InvoiceService(e);


            Invoice i1 = new Invoice();
            i1.Date = DateTime.Now;
            i1.MemberId = 5;
            i1.DeliveryManId = 2;
            i1.Status = "0";
            i1.PaymentStatus = "0";
            i1.PaymentMethod = "1";
            i1.ShippingAddress = "khilkhet,dhaka";
            Console.WriteLine(ivs.Insert(i1));



            Invoice i2 = new Invoice();
            i2.Date = DateTime.Now;
            i2.MemberId = 6;
            i2.DeliveryManId = 9;
            i2.Status = "0";
            i2.PaymentStatus = "0";
            i2.PaymentMethod = "1";
            i2.ShippingAddress = "Mirpur,dhaka";
            Console.WriteLine(ivs.Insert(i2));

            //Order--------------------
            OrderService os = new OrderService(e);

            Order o1 = new Order();
            o1.ProductId = 1;
            o1.MemeberId = 5;
            o1.InvoiceId = 1;
            o1.Quantity = 1;
            o1.Profit = 10;
            o1.SellingDate = DateTime.Now;
            Console.WriteLine(os.Insert(o1));


            Order o2 = new Order();
            o2.ProductId = 2;
            o2.MemeberId = 5;
            o2.InvoiceId = 1;
            o2.Quantity = 1;
            o2.Profit = 10;
            o2.SellingDate = DateTime.Now;
            Console.WriteLine(os.Insert(o2));


            Order o3 = new Order();
            o3.ProductId = 3;
            o3.MemeberId = 6;
            o3.InvoiceId = 2;
            o3.Quantity = 1;
            o3.Profit = 10;
            o3.SellingDate = DateTime.Now;
            Console.WriteLine(os.Insert(o3));



            //ProductReview--------------------



            ProductReviewService prs = new ProductReviewService(e);

            ProductReview pr1 = new ProductReview();
            pr1.MemberId = 5;
            pr1.ProductId = 1;
            pr1.Review = "good";
            pr1.Date = DateTime.Now;
            Console.WriteLine(prs.Insert(pr1));


            ProductReview pr2 = new ProductReview();
            pr2.MemberId = 5;
            pr2.ProductId = 2;
            pr2.Review = "good";
            pr2.Date = DateTime.Now;
            Console.WriteLine(prs.Insert(pr2));


            ProductReview pr3 = new ProductReview();
            pr3.MemberId = 6;
            pr3.ProductId = 3;
            pr3.Review = "good";
            pr3.Date = DateTime.Now;
            Console.WriteLine(prs.Insert(pr3));




            //Report--------------------
            ReportService rs = new ReportService(e);

            Report r1 = new Report();
            r1.ReportTitle = "Faulty product";
            r1.MemeberId = 7;
            r1.Date = DateTime.Now;
            r1.Description = "loreum ispum";
            r1.SeenStatus = "0";
            Console.WriteLine(rs.Insert(r1));


            Report r2 = new Report();
            r2.ReportTitle = "Faulty product";
            r2.MemeberId = 8;
            r2.Date = DateTime.Now;
            r2.Description = "loreum ispum";
            r2.SeenStatus = "0";
            Console.WriteLine(rs.Insert(r2));

            //SearchHistory--------------------
            SearchHistoryService shs = new SearchHistoryService(e);

            SearchHistory sh1 = new SearchHistory();
            sh1.MemberId = 5;
            sh1.ProductCategory = "shirt";
            sh1.ProductId = 1;
            sh1.Date = DateTime.Now;
            Console.WriteLine(shs.Insert(sh1));


            SearchHistory sh2 = new SearchHistory();
            sh2.MemberId = 5;
            sh2.ProductCategory = "shirt";
            sh2.ProductId = 2;
            sh2.Date = DateTime.Now;
            Console.WriteLine(shs.Insert(sh2));


            SearchHistory sh3 = new SearchHistory();
            sh3.MemberId = 6;
            sh3.ProductCategory = "shirt";
            sh3.ProductId = 3;
            sh3.Date = DateTime.Now;
            Console.WriteLine(shs.Insert(sh3));

            //UserFavorite--------------------

            UserFavoriteService ufs = new UserFavoriteService(e);


            UserFavorite u1 = new UserFavorite();
            u1.ProductId = 4;
            u1.MemeberId = 6;
            u1.Date = DateTime.Now;
            Console.WriteLine(ufs.Insert(u1));

            UserFavorite u2 = new UserFavorite();
            u2.ProductId = 5;
            u2.MemeberId = 5;
            u2.Date = DateTime.Now;
            Console.WriteLine(ufs.Insert(u2));
        }
    }
}
