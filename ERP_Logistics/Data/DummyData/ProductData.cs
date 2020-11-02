using ERP_Logistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Data.DummyData
{
    public class ProductData
    {
        public List<Product> Get()
        {
            var list = new List<Product>();
            list.Add( new Product() {
                Name = "MyPhone XL",
                Description = "The bigest screen for a phone in the market, it barely fits on your pocket!",
                Price = 1200,
                Category = Product.ProductCategories.Electronic,
                ImageUrl = "./../../../assets/img/phone-large.jpg",
        });
            list.Add( new Product() {
                Name = "MyPhone M",
                Description = "This phone is a good combination between price and quality",
                Price = 600,
                Category = Product.ProductCategories.Electronic,
                ImageUrl = "./../../../assets/img/phone-medium.jpg",
            });
            list.Add( new Product() {
                Name = "MyPhone Small",
                Description = "Is not a big deal, but at least is cheap",
                Price = 250,
                Category = Product.ProductCategories.Electronic,
                ImageUrl = "./../../../assets/img/phone-small.jpg",
            });
            list.Add( new Product() {
                Name = "Pet Food",
                Description = "The best food for your puppy",
                Price = 30,
                Category = Product.ProductCategories.Food,
                ImageUrl = "./../../../assets/img/pet-food.jpg",
            });
            list.Add( new Product() {
                Name = "Pet Toy",
                Description = "Pets love this toy, hours of fun guaranteed or we give you the money back",
                Price = 15,
                Category = Product.ProductCategories.Toys,
                ImageUrl = "./../../../assets/img/pet-toy.jpg",
            });
            list.Add( new Product() {
                Name = "Myntendo Witch",
                Description = "The original and best portable gaming console",
                Price = 220,
                Category = Product.ProductCategories.Electronic,
                ImageUrl = "./../../../assets/img/myntend-witch.jpg",
            });
            list.Add( new Product() {
                Name = "Water",
                Description = "Just water... ",
                Price = 1,
                Category = Product.ProductCategories.Food,
                ImageUrl = "./../../../assets/img/water-bottle.jpg",
            });
            list.Add( new Product() {
                Name = "Laptop Asmer 800 GB Ram",
                Description = "If you want more ram, this is your laptop, also we gift you a toy of a dancing t-rex",
                Price = 4500,
                Category = Product.ProductCategories.Electronic,
                ImageUrl = "./../../../assets/img/laptop.jpg",
            });
            list.Add( new Product() {
                Name = "Guitar Lets Bowl Standard",
                Description = "Electric guitar with strong personality, best quality",
                Price = 1800,
                Category = Product.ProductCategories.Instruments,
                ImageUrl = "./../../../assets/img/guitar.png",
            });
            list.Add( new Product() {
                Name = "Yamasa Keyboard",
                Description = "This keyboard is not for newbies, is for pros, if you are newbie the piano won't sound",
                Price = 2200,
                Category = Product.ProductCategories.Instruments,
                ImageUrl = "./../../../assets/img/keyboard.jpg",
            });
            list.Add( new Product() {
                Name = "Skateboard",
                Description = "This skateboard is very good if you want to brake your bones, we dont care, dont sue us, we are covered",
                Price = 120,
                Category = Product.ProductCategories.Sports,
                ImageUrl = "./../../../assets/img/skateboard.jpg",
            });
            return list;
        }
    }
}
