using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RockItGear.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Climbing Shoes"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Harness"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Climbing Ropes"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Belays"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Accessories"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Black Diamond Focus Climbing Shoes",
                    Description = "Built to handle nail-biting crux moves that require laser precision, " +
                                  "the men's Black Diamond Focus climbing shoes help you edge through tricky sequences and dig in on steeper terrain.",
                    ImagePath="bdfocusshoes.png",
                    UnitPrice = 179.95,
                    CategoryID = 1
               },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Black Diamond Momentum Climbing Shoes",
                    Description = "A great choice for new climbers, the Black Diamond Momentum climbing " +
                                  "shoes have breathable fabric uppers and neutral lasts that offer serious " +
                                  "comfort without sacrificing performance.",
                    ImagePath="bdmomentumshoes.png",
                    UnitPrice = 94.95,
                     CategoryID = 1
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Black Diamond Shadow Climbing Shoes",
                    Description = "When the going gets steep and the footholds get tiny, Black Diamond Shadow " +
                                  "climbing shoes help you power through with their aggressive downturn and a dialed, " +
                                  "grippy combo of printed and molded rubber.",
                    ImagePath="bdshadowsshoes.png",
                    UnitPrice = 189.95,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Evolv Kronos Climbing Shoes",
                    Description = "Anatomically engineered parts and design provide the men's evolv Kronos climbing shoes " +
                                  "with a comfortable fit without sacrificing performance.",
                    ImagePath="evolvkronosshoes.png",
                    UnitPrice = 130.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "La Sportiva Finale Climbing Shoes",
                    Description = "The all-around La Sportiva Finale climbing shoes can help novice climbers move to the next " +
                                  "level at the crag, in the gym or out bouldering thanks to sticky outsoles and a neutral design.",
                    ImagePath="lasportivafinaleshoes.png",
                    UnitPrice = 109.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "La Sportiva Miura Climbing Shoes",
                    Description = "With a slingshot rand connecting to a powerhinge to help keep you on the edges, the La Sportiva " +
                                  "Miura men's climbing shoes are high-performance lace-ups made for edging control and pocket climbing.",
                    ImagePath="lasportivashoes.png",
                    UnitPrice = 165.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Scarpa Origin Climbing Shoes",
                    Description = "Great for beginners, the men's Scarpa Origin climbing shoes feature " +
                                  "luxurious padded leather uppers so you’ll enjoy climbing as you build " +
                                  "strength and work on your technique.",
                    ImagePath="scarpashoes.png",
                    UnitPrice = 95.00,
                    CategoryID = 1
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "Black Diamond Momentum Harness",
                    Description = "With 4 gear loops, adjustable leg loops and a comfortable waistbelt, the men's Black Diamond Momentum " +
                                  "harness is great for everything from learning the ropes to multi-pitch climbs and hanging belays.",
                    ImagePath="bdharness.png",
                    UnitPrice = 59.95,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Edelrid Sendero Harness",
                    Description = "A comfy fit, minimal packing size and easy on-off—even when wearing " +
                                  "skis or crampons—make the men's Edelrid Sendero harness a great pick for " +
                                  "climbing on both sunny days and snowy ones.",
                    ImagePath="edelridharness.png",
                    UnitPrice = 84.95,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 10,
                    ProductName = "Mammut Ophir 3 Slide Harness",
                    Description = "At the crag, in the gym or on an alpine peak, the men's Mammut Ophir 3 Slide climbing harness offers " +
                                  "all-around performance with adjustable leg loops and a lightweight, comfortable design.",
                    ImagePath="mammutharness.png",
                    UnitPrice = 64.95,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 11,
                    ProductName = "Metolius Safe Tech All-Around Harness",
                    Description = "All structural components of the Metolius Safe Tech All-Around climbing harness have been made as redundant " +
                                  "and error-proof as possible to keep you calm and climbing on.",
                    ImagePath="metolius.png",
                    UnitPrice = 119.95,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 12,
                    ProductName = "Petzl Sama Sport Harness",
                    Description = "Ideal for both indoor and outdoor climbs, the padded Petzl Sama Sport climbing harness offers comfort and freedom " +
                                  "of movement in the gym, at the crag or on a multi-pitch route.",
                    ImagePath="petzelharness.png",
                    UnitPrice = 69.95,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 13,
                    ProductName = "Black Diamond 9mm Climbing Rope",
                    Description = "Designed for heavy use and year-round climbing, the burly Black Diamond " +
                                  "9.9mm Non-Dry rope boasts a thick diameter for heavy use on varied climbs.",
                    ImagePath="ropebd9.png",
                    UnitPrice = 99.95,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 14,
                    ProductName = "BlueWater Assaultline 11mm Climbing Rope",
                    Description = "A standard for police and military applications, " +
                                  "the low-visibility BlueWater Assaultline 11mm x 46m " +
                                  "static rope is designed for tactical and rescue work.",
                    ImagePath="bw11rope.png",
                    UnitPrice = 140.00,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 15,
                    ProductName = "Mammut Phoenix 8mm Climbing Rope",
                    Description = "Certified as both a half rope and a twin rope, the Mammut " +
                                  "Phoenix 8mm x 30m dry rope is ideal for glacier travel, " +
                                  "technical scrambles, running belays and short rappels on technical terrain.",
                    ImagePath="mammut8rope.png",
                    UnitPrice = 95.00,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 16,
                    ProductName = "Sterling Rope Evolution VR9 9mm Climbing Rope",
                    Description = "Just getting into the sport or steadily moving through the ranks? " +
                                  "The Sterling Evolution VR9 9.8mm x 60m Dry-Core rope has a beefy core " +
                                  "and 9.8mm diameter for a lightweight rope on multi-pitch routes.",
                    ImagePath="sterlingevo9rope.png",
                    UnitPrice = 149.95,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 17,
                    ProductName = "Metolius Rope Tarp",
                    Description = "Designed for easy storage in your pack, the Metolius Rope Tarp " +
                                  "is a lightweight, affordable way to keep your rope out of the dirt. " +
                                  "It works well for alpine, cragging or the climbing gym.",
                    ImagePath="metoliusropetarp.png",
                    UnitPrice = 19.95,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID = 18,
                    ProductName = "Black Diamond ATC-XP Belay Device",
                    Description = "The Black Diamond ATC-XP Belay Device offers the same great hold and stopping power as the original version, " +
                                   "only it's now 30% lighter. It's available in new colors, too.",
                    ImagePath="belaybdatc.png",
                    UnitPrice = 21.95,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 19,
                    ProductName = "Petzl GRIGRI Belay Device",
                    Description = "With assisted braking for improved belaying comfort both in the " +
                                  "gym and at the crag, the light and compact the Petzl GRIGRI belay device can be used with 8.5-11mm dynamic single rope diameters.",
                    ImagePath="belaypetzlgrigri.png",
                    UnitPrice = 109.95,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 20,
                    ProductName = "Black Diamond GridLock Belay Screwgate Carabiner",
                    Description = "The hot-forged Black Diamond GridLock Belay Screwgate locking carabiner " +
                                  "has a patent-pending design that keeps the carabiner properly oriented " +
                                  "while you're belaying.",
                    ImagePath="bdgridlockcarabiner.png",
                    UnitPrice = 19.95,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 21,
                    ProductName = "Black Diamond Position Straight Gate Carabiner",
                    Description = "Delivering the antisnag benefits of a keylock nose, the classic Black " +
                                  "Diamond Positron Straight Gate carabiner is built for racking and placing " +
                                  "stoppers or clipping and cleaning bolts.",
                    ImagePath="bdstraightcarabiner.png",
                    UnitPrice = 10.95,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 22,
                    ProductName = "Black Diamond RockLock TwistLock Carabiner",
                    Description = "The largest locking carabiner from Black Diamond, the Black Diamond " +
                                  "RockLock Twistlock carabiner is designed with a keylock nose that won't " +
                                  "snag on bolts or gear.",
                    ImagePath="bdtwistlockcarabiner.png",
                    UnitPrice = 18.95,
                    CategoryID = 4
                },
                new Product
                {
                    ProductID = 23,
                    ProductName = "Black Diamond Mojo Zip Chalk Bag",
                    Description = "The Black Diamond Mojo Zip Chalk Bag features a rear zippered pocket " +
                                  "that holds small essentials like your keys, a route topo or a smartphone.",
                    ImagePath="bagbdmojo.png",
                    UnitPrice = 22.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 24,
                    ProductName = "Metolius Chalk Bag",
                    Description = "This brightly colored, ergonomic Metolius chalk bag holds chalk on your belt for secure, easy access.",
                    ImagePath="metoliuschalkbag.png",
                    UnitPrice = 14.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 25,
                    ProductName = "Metolius Access Fund Chalk Bag",
                    Description = "Purchase this Metolius Chalk Bag and a portion of the proceeds goes to the Access Fund to help protect American climbing areas.",
                    ImagePath="metoliusaccessbag.png",
                    UnitPrice = 19.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 26,
                    ProductName = "Metolius Super Chalk Bag",
                    Description = "Specially formulated for rock climbing, Metolius Super chalk will help keep your hands dry as you push through hard moves.",
                    ImagePath="metoliuschalk.png",
                    UnitPrice = 13.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 27,
                    ProductName = "Metolius Refillable Super Chalk Sock",
                    Description = "Keep the clouds of chalk dust to a minimum with the refillable Metolius Super Chalk Sock.",
                    ImagePath="metoliuschalksock.png",
                    UnitPrice = 4.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 28,
                    ProductName = "Metolius Climbing Tape",
                    Description = "Keep climbing despite sore wrists and tweaked fingers--this athletic tape strengthens aching joints on long endurance climbs.",
                    ImagePath="metoliusclimbtape.png",
                    UnitPrice = 3.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 29,
                    ProductName = "Climb On! Skin Repair Mini Bar",
                    Description = "All-natural, soothing Climb On! Skin Repair Mini Bar protects and moisturizes dry or chapped skin. it's great for climbers, skiers and mountaineers.",
                    ImagePath="climbonbar.png",
                    UnitPrice = 6.95,
                    CategoryID = 5
                },
                new Product
                {
                    ProductID = 30,
                    ProductName = "Metolius Shortstop Crash Pad",
                    Description = "An affordable addition to your bouldering essentials, the Metolius Shortstop crash pad covers gaps and offers extra protection with little added weight.",
                    ImagePath="metoliuscrashpad.png",
                    UnitPrice = 49.95,
                    CategoryID = 5
                }


            };

            return products;
        }
    }
}