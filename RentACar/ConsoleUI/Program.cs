
using AutoMapper;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {



            //TestColor();

            //TestBrand();

            //TestCar();

            //TestUSer();

            //TestCustomer();

            //TestRental();
           


        }

        //private static void TestRental()
        //{
        //    //RentalManager rentalManager = new RentalManager(new EfRentalDal());


        //    /*foreach (var item in rentalManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "    " + item.CarId + "    " + item.CustumorId + "    " + item.RentDate + "      " + item.ReturnDate);

        //    }


        //    Console.WriteLine("*****************************************************");
        //    Rental rental2= new Rental();
        //    rental2.CarId = 1;
        //    rental2.CustumorId = 1;
        //    rental2.RentDate = DateTime.Now;
        //    rentalManager.Add(rental2);

            
        //    Rental rental=new Rental();
        //    rental.Id = 4;
        //    rental.ReturnDate = DateTime.Now;
        //    rentalManager.Update(rental);*/


        //   // foreach (var item in rentalManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "    " + item.CarId + "    " + item.CustumorId + "    " + item.RentDate + "      " + item.ReturnDate);

        //    }

        //    Rental rental3 = new Rental();
        //    rental3.Id = 1;
        //    rental3.ReturnDate = DateTime.Now;
        //    rental3.CarId = 1;
        //    rental3.CustumorId = 1;
        //    rentalManager.Update(rental3);

        //    foreach (var item in rentalManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "    " + item.CarId + "    " + item.CustumorId + "    " + item.RentDate + "      " + item.ReturnDate);

        //    }
        //    Rental rental5 = new Rental();
        //    rental5.RentDate = DateTime.Now;
        //    rental5.CustumorId = 1;
        //    rental5.CarId = 1;
        //    rentalManager.Add(rental5);

        //    Console.WriteLine("************************************************");

        //    foreach (var item in rentalManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "    " + item.CarId + "    " + item.CustumorId + "    " + item.RentDate + "      " + item.ReturnDate);

        //    }

        //    rentalManager.Delete(6);
        //    foreach (var item in rentalManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "    " + item.CarId + "    " + item.CustumorId + "    " + item.RentDate + "      " + item.ReturnDate);

        //    }
        //}

        //private static void TestCustomer()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    Customer customer = new Customer();
        //    customer.Id = 3;
        //    customer.UserId = 2;


        //    // customerManager.Add(customer);
        //    foreach (var entity in customerManager.GetAll().Data)
        //    {
        //        Console.WriteLine(entity.UserId + "    " + entity.CompanyName);
        //    }
        //    Console.WriteLine("******************");
        //    //customerManager.Delete(9);
        //    foreach (var entity in customerManager.GetAll().Data)
        //    {
        //        Console.WriteLine(entity.Id + "  " + entity.UserId + "    " + entity.CompanyName);
        //    }

        //    Console.WriteLine(customerManager.GetById(1).Data.CompanyName);
        //    Console.WriteLine("******************");
        //    customerManager.Update(customer);
        //    foreach (var entity in customerManager.GetAll().Data)
        //    {
        //        Console.WriteLine(entity.Id + "  " + entity.UserId + "    " + entity.CompanyName);
        //    }
        //}

        //private static void TestUSer()
        //{
        //    User user = new User();
        //    user.Id = 5;
        //    user.FirstName = "fatma";
        //    user.LastName = "Bekgggtas";

        //    user.Password = "password";

        //    UserManager userManager = new UserManager(new EfUserDal());
        //    //userManager.Add(user);

        //    foreach (var item in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.Id + "  " + item.FirstName + "    " + item.LastName);
        //    }

        //    //Console.WriteLine(userManager.GetById(7).Data.FirstName);

        //    //userManager.Delete(4);
        //    foreach (var item in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.Id + "  " + item.FirstName + "    " + "    " + item.LastName + "    " + item.Email);
        //    }

        //    userManager.Update(user);

        //    foreach (var item in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.Id + "  " + item.FirstName + "    " + "    " + item.LastName + "   " + item.Email);
        //    }
        //}


        //private static void TestCar()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    /*Car car=new Car();
        //    car.Id = 5;
        //    car.Description= "Description 8";
           

        //    //carManager.Add(car);

   
            
        //    Console.WriteLine("************************************************");

        //    foreach (var item in carManager.GetAll().Data) {
              
        //            Console.WriteLine(item.Name);      
        //    }
        //    Console.WriteLine("************************************************");
        //    carManager.Delete(6);

        //    foreach (var item in carManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Name);
        //    }
        //    Console.WriteLine("************************************************");
        //    Console.WriteLine(carManager.GetById(6).Data);
        //    foreach (var item in carManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Description + "    " + item.Name +"      "+item.BrandId);
        //    }
        //    carManager.Update(car);*/
        //    foreach (var item in carManager.GetDetailCars().Data)
        //    {

        //        Console.WriteLine( item.CarName+"    "+item.BrandName+"          "+item.ColorName);
        //    }
            
        //}

        //private static void TestBrand()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());


        //    Brand brand = new Brand();
        //    brand.Id = 4;
        //    brand.Name = "Suziki";
        //    //brandManager.Add(brand);

        //    Console.WriteLine(brandManager.GetById(1).Data.Name);

        //    foreach (var item in brandManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.Name);
        //    }

        //    brandManager.Delete(5);
        //    brandManager.Update(brand);
        //}

        //private static void TestColor()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());

        //    /*
        //    //Add Get ve GetAll Test Edildi
        //    Color color = new Color() { Name = "Sarı" };
        //    colorManager.Add(color);

        //   Console.WriteLine(colorManager.Get(4).Data.Name);
        //   foreach(var item in colorManager.GetAll().Data) {
                 
        //        Console.WriteLine(item.Id+"**************"+item.Name);
            
        //    }
        //    */

        //    /*
        //    //delete test edildi
        //    foreach (var item in colorManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "**************" + item.Name);

        //    }
        //    colorManager.Delete(5);
        //    foreach (var item in colorManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "**************" + item.Name);

        //    }*/


        //    //Update işlemi test edildi
        //    /*
        //    foreach (var item in colorManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "**************" + item.Name);

        //    }
        //    Color color = new Color();
        //    color.Id = 4;
        //    color.Name = "Lacivert";
       
           
        //   colorManager.Update(color);
        //    foreach (var item in colorManager.GetAll().Data)
        //    {

        //        Console.WriteLine(item.Id + "**************" + item.Name);

        //    }
        //    */
        
    }
}