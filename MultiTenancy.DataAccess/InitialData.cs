using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MultiTenancy.Domain;
using MultiTenancy.Domain.Enums;

namespace MultiTenancy.DataAccess
{
    public static class InitialData
    {

        private static List<string> TenantInfo = new List<string>
        {
            "Residence Gallery", "TruePhone Shop", "Light Hub"
        };
        public static List<Tenant> Tenants {
            get {
                var tenants = new List<Tenant>();
                for (int i = 0; i < TenantInfo.Count; i++)
                {
                    tenants.Add(new Tenant()
                    {
                        Id = i + 1,
                        Name = TenantInfo[i]
                    });
                }

                return tenants;
            }
        }


        public static List<string> CountryInfo = new List<string>()
        {
            "Serbia", "Germany", "United Kingdom", "Norway"
        };
        public static List<Country> Countries
        {
            get
            {
                var countries = new List<Country>();
                for (int i = 0; i < CountryInfo.Count; i++)
                {
                    countries.Add(new Country()
                    {
                        Id = i + 1,
                        Name = CountryInfo[i]
                    });
                }

                return countries;
            }
        }


        public static List<dynamic> SpecificationInfo = new List<dynamic>()
        {
            #region TenantOne

            // 1
            new
            {
                Name = "Collection",
                TenantId = 1
            },
            // 2
            new
            {
                Name = "Color",
                TenantId = 1
            },

	        #endregion

            #region TenantTwo
            
            // 3
            new
            {
                Name = "Screen Size",
                TenantId = 2
            },

            // 4
            new
            {
                Name = "RAM",
                TenantId = 2
            },

            // 5
            new
            {
                Name = "Internal Memory",
                TenantId = 2
            },

            // 6
            new
            {
                Name = "Battery Capacity",
                TenantId = 2
            },

            // 7
            new
            {
                Name = "Color",
                TenantId = 2
            },

            // 8
            new
            {
                Name = "Wireless",
                TenantId = 2
            },

            // 9
            new
            {
                Name = "With Mic",
                TenantId = 2
            },

	        #endregion

            #region TenantThree
            

            // 10
            new
            {
                Name = "Bulb Shape",
                TenantId = 3
            },

            // 11
            new
            {
                Name = "Wattage",
                TenantId = 3
            },

            // 12
            new
            {
                Name = "Color Temperature",
                TenantId = 3
            },
            
            // 13
            new
            {
                Name = "Lumens",
                TenantId = 3
            },
            
            // 14
            new
            {
                Name = "Dimensions",
                TenantId = 3
            },

            // 15
            new
            {
                Name = "Length",
                TenantId = 3
            },

	        #endregion
        };
        public static List<Specification> Specifications
        {
            get
            {
                var spec = new List<Specification>();
                for (int i = 0; i < SpecificationInfo.Count; i++)
                {
                    spec.Add(new Specification()
                    {
                        Id = i + 1,
                        Name = SpecificationInfo[i].Name,
                        TenantId = SpecificationInfo[i].TenantId
                    });
                }

                return spec;
            }
        }


        public static List<dynamic> CategoryInfo = new List<dynamic>()
        {
            #region TenantOne

            // 1
            new
            {
                Name = "Bedroom",
                Specifications = new List<int> {1,2},
                TenantId = 1
            },

            // 2
            new
            {
                Name = "Dining Room",
                Specifications = new List<int> {1,2},
                TenantId = 1
            },

            // 3
            new
            {
                Name = "Living Room",
                Specifications = new List<int> {1,2},
                TenantId = 1
            },

            // 4
            new
            {
                Name = "Outdoor Spaces",
                Specifications = new List<int> {1,2},
                TenantId = 1
            },

            #endregion

            #region TenantTwo
            
            // 5
            new
            {
                Name = "Smartphones",
                Specifications = new List<int> {3,4,5,6,7},
                TenantId = 2
            },

            // 6
            new
            {
                Name = "Power Banks",
                Specifications = new List<int> {6,7},
                TenantId = 2
            },
            
            // 7
            new
            {
                Name = "Headphones",
                Specifications = new List<int> {7,8,9},
                TenantId = 2
            },

	        #endregion

            #region TenantThree

            // 8
            new
            {
                Name = "LED Lamps",
                Specifications = new List<int> {10,11,12,13},
                TenantId = 3
            },

            // 9
            new
            {
                Name = "LED Panels",
                Specifications = new List<int> {11,12,13,14},
                TenantId = 3
            },

            // 10
            new
            {
                Name = "LED Tubes",
                Specifications = new List<int> {11,12,13,15},
                TenantId = 3
            },

	        #endregion
        };
        public static List<Category> Categories
        {
            get
            {
                var cat = new List<Category>();
                for (int i = 0; i < CategoryInfo.Count; i++)
                {
                    cat.Add(new Category()
                    {
                        Id = i + 1,
                        Name = CategoryInfo[i].Name,
                        TenantId = CategoryInfo[i].TenantId
                    });
                }

                return cat;
            }
        }
        public static List<CategorySpecification> CategorySpecifications
        {
            get
            {
                var catSpec = new List<CategorySpecification>();
                int j = 1;

                for (int i = 0; i < CategoryInfo.Count; i++)
                {
                    foreach (var spec in CategoryInfo[i].Specifications)
                    {
                        catSpec.Add(new CategorySpecification()
                        {
                            Id = j++,
                            SpecificationId = spec,
                            CategoryId = i + 1

                        });
                    }
                }

                return catSpec;
            }
        }


        public static List<dynamic> ProductInfo = new List<dynamic>()
        {
            #region TenantOne

            //1 - t1c1
            new
            {
                Name = "Lugano Double Dresser",
                Desc = "The design is completed with beveled edges. This fine detail ensures harmony and brings an elegance and exclusivity to the expression.",
                Price = 599m,
                Image = "1640903.jpg",
                CategoryId = 1,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Lugano" },
                    new { SpecId = 2, Value = "Gray" }
                }
            },

            //2 - t1c1
            new
            {
                Name = "Lugano Nightstand",
                Desc = "Looking sleek, elegant and exclusive, Lugano will solve all your storage needs without breaking a sweat. Keep your books, chargers and bedroom knick-knacks neatly hidden in this nifty little nightstand that will put the finishing touch on your bedroom décor.",
                Price = 299m,
                Image = "1640739.jpg",
                CategoryId = 1,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Lugano" },
                    new { SpecId = 2, Value = "Gray" }
                }
            },

            //3 - t1c2
            new
            {
                Name = "Augusta Table",
                Desc = "The Augusta dining table presents a clear and undisguised play with shapes.",
                Price = 799m,
                Image = "SgGEDYPUJj99fktljukQA957lgPP3nADl3hvBkyR.jpg",
                CategoryId = 2,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 2, Value = "Brown" }
                }
            },

            //4 - t1c2
            new
            {
                Name = "Vienna Chair",
                Desc = "The Vienna chair distinctively combines creased lines, soft shapes and emphasised edges to ensure a comfortable and beautiful expression in you dining or working area.",
                Price = 599m,
                Image = "yaiOXj3cHCt087xDoDdEw9UlFegKJIqTXK3oAQHY.jpg",
                CategoryId = 2,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Vienna" },
                    new { SpecId = 2, Value = "Beige" }
                }
            },

            //5 - t1c3
            new
            {
                Name = "Bergamo sofa with round lounging unit",
                Desc = "Bergamo by Morten Georgsen is organic luxury made comfortable. Bergamo elegantly combines extraordinary individual comfort with an elegant esthetic.",
                Price = 3499m,
                Image = "1682829.jpg",
                CategoryId = 3,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Bergamo" },
                    new { SpecId = 2, Value = "White" }
                }
            },

            //6 - t1c3
            new
            {
                Name = "Charlotte armchair",
                Desc = "Feel the warm embrace of the Charlotte armchair. Charlotte’s comfort, durability, and beautiful design allow it to easily finds its place in any room.",
                Price = 799m,
                Image = "1096851.jpg",
                CategoryId = 3,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Charlotte" },
                    new { SpecId = 2, Value = "Beige" }
                }
            },

            //7 - t1c3
            new
            {
                Name = "Madrid Coffee Table",
                Desc = "Clean lines and organic shapes come together in a floating design to make the Madrid table a sensory, vibrant piece for your interior.",
                Price = 199m,
                Image = "856671.jpg",
                CategoryId = 3,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Madrid" },
                    new { SpecId = 2, Value = "Black" }
                }
            },

            //8 - t1c4
            new
            {
                Name = "Rome Ourdoor Sofa",
                Desc = "Get a comfortable place to enjoy the open air and transform your terrace into a contemporary living space with Rome.",
                Price = 899m,
                Image = "563132.jpg",
                CategoryId = 4,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Rome" },
                    new { SpecId = 2, Value = "Gray" }
                }
            },

            //9 - t1c4
            new
            {
                Name = "Sydney Trolley",
                Desc = "Much more than just a place to put down a bottle, the Sydney trolley is a statement in your home.",
                Price = 799m,
                Image = "660512.jpg",
                CategoryId = 4,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Sydney" },
                    new { SpecId = 2, Value = "Black" }
                }
            },

            //10 - t1c4
            new
            {
                Name = "Rome Ourdoor Sofa 2 seater",
                Desc = "Get a comfortable place to enjoy the open air and transform your terrace into a contemporary living space with Rome.",
                Price = 1599m,
                Image = "563155.jpg",
                CategoryId = 4,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Rome" },
                    new { SpecId = 2, Value = "Gray" }
                }
            },

            //11 - t1c4
            new
            {
                Name = "Rome Coffee Table",
                Desc = "Add an elegant centerpiece to your outdoor setting and keep food and drinks conveniently at hand.",
                Price = 499m,
                Image = "563119.jpg",
                CategoryId = 4,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 1, Value = "Rome" },
                    new { SpecId = 2, Value = "Black" }
                }
            },



	        #endregion

            #region TenantTwo
            
            // 12
            new
            {
                Name = "SAMSUNG Z Flip4 8/256GB Purple",
                Desc = "The era of planning looks around your phone is over. Small but mighty when folded, Galaxy Z Flip4 is a compact full-sized smartphone, and just the right size to slip in a pocket when it's time to slay.",
                Price = 1199m,
                Image = "galaxy-z-flip4_highlights_compact_img.jpg",
                CategoryId = 5,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 3, Value = "6.7\"" },
                    new { SpecId = 4, Value = "8GB" },
                    new { SpecId = 5, Value = "128GB" },
                    new { SpecId = 6, Value = "3700mAh" },
                    new { SpecId = 7, Value = "Purple" }
                }
            },

            // 13
            new
            {
                Name = "SAMSUNG Z Flip4 8/256GB Blue",
                Desc = "The era of planning looks around your phone is over. Small but mighty when folded, Galaxy Z Flip4 is a compact full-sized smartphone, and just the right size to slip in a pocket when it's time to slay.",
                Price = 1199m,
                Image = "galaxy-z-flip4_highlights_durability_top.jpg",
                CategoryId = 5,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 3, Value = "6.7\"" },
                    new { SpecId = 4, Value = "8GB" },
                    new { SpecId = 5, Value = "128GB" },
                    new { SpecId = 6, Value = "3700mAh" },
                    new { SpecId = 7, Value = "Blue" }
                }
            },

            // 14
            new
            {
                Name = "SAMSUNG Galaxy Z Fold 3 256GB Silver",
                Desc = "It's basically two phones in one. Slimmed down everywhere but the screen, minimised bezels and lightweight materials make this Fold even more pocket-friendly.",
                Price = 2199m,
                Image = "40e7a2aad06ac84dcd2c23145436a773.png",
                CategoryId = 5,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 3, Value = "7.6\"" },
                    new { SpecId = 4, Value = "12GB" },
                    new { SpecId = 5, Value = "256GB" },
                    new { SpecId = 6, Value = "4400mAh" },
                    new { SpecId = 7, Value = "Silver" }
                }
            },


            // 15
            new
            {
                Name = "SAMSUNG Galaxy Z Fold 3 256GB Black",
                Desc = "It's basically two phones in one. Slimmed down everywhere but the screen, minimised bezels and lightweight materials make this Fold even more pocket-friendly.",
                Price = 2199m,
                Image = "blackfr-96.png",
                CategoryId = 5,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 3, Value = "7.6\"" },
                    new { SpecId = 4, Value = "12GB" },
                    new { SpecId = 5, Value = "256GB" },
                    new { SpecId = 6, Value = "4400mAh" },
                    new { SpecId = 7, Value = "Black" }
                }
            },

            // 16
            new
            {
                Name = "HUAWEI P50 Pro 256GB Black",
                Desc = "Legend Reborn - Elegant Outside, Powerful Inside.",
                Price = 1399m,
                Image = "image623b028fcccad.png",
                CategoryId = 5,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 3, Value = "6.6\"" },
                    new { SpecId = 4, Value = "8GB" },
                    new { SpecId = 5, Value = "256GB" },
                    new { SpecId = 6, Value = "4360mAh" },
                    new { SpecId = 7, Value = "Black" }
                }
            },

            // 17
            new
            {
                Name = "HUAWEI P50 Pocket 256GB White",
                Desc = "Experience immersive big screen views and innovative features in folded mode, giving you a versatile device to open up your world.",
                Price = 1499m,
                Image = "image623b141c0752f.png",
                CategoryId = 5,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 3, Value = "6.9\"" },
                    new { SpecId = 4, Value = "8GB" },
                    new { SpecId = 5, Value = "256GB" },
                    new { SpecId = 6, Value = "4000mAh" },
                    new { SpecId = 7, Value = "White" }
                }
            },

            // 18
            new
            {
                Name = "XIAOMI Mi Power bank Essential",
                Desc = "High 10000 mAh capacity housed in a body weighing just 230 g. Easy to use and portable.",
                Price = 25m,
                Image = "image5f8054ce43eaf.png",
                CategoryId = 6,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 6, Value = "10000mAh" },
                    new { SpecId = 7, Value = "Black" }
                }
            },

            // 19
            new
            {
                Name = "CELLY Power bank PBPD22W10000WH",
                Desc = "The Powerbank for all your devices! PD22W are Power Banks equipped with two USB-A output ports, one Micro Usb charging port and a USB-C input/output port.",
                Price = 39m,
                Image = "image620e0db050ac4.png",
                CategoryId = 6,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 6, Value = "10000mAh" },
                    new { SpecId = 7, Value = "White" }
                }
            },

            // 20
            new
            {
                Name = "SENNHEISER earphones CX 300S White",
                Desc = "Boost your sound with Sennheiser’s CX 300S earphones which offer amazingly detailed sound reproduction and enhanced bass response thanks to Sennheisers transducer technology.",
                Price = 39m,
                Image = "image5c8b6941a03c3.png",
                CategoryId = 7,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 7, Value = "White" },
                    new { SpecId = 8, Value = "No" },
                    new { SpecId = 9, Value = "Yes" }
                }
            },

            // 21
            new
            {
                Name = "SENNHEISER Momentum TW3 TWS",
                Desc = "Discover unrivaled high-fidelity sound with our TrueResponse technology.",
                Price = 299m,
                Image = "image62d134f7a38f7.png",
                CategoryId = 7,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 7, Value = "Black" },
                    new { SpecId = 8, Value = "Yes" },
                    new { SpecId = 9, Value = "Yes" }
                }
            },
            

            // 22
            new
            {
                Name = "JBL Live Pro+ TWS",
                Desc = "Providing the best audio solution for any device, Live Pro+ TWS earbuds are small but powerful, with 11mm dynamic drivers for extraordinary JBL Signature Sound all day, every day.",
                Price = 249m,
                Image = "JBL-Bežične-bubice-Live-Pro-TWS-(Crna)-JBLLIVEPROPTWSBLK-69.png",
                CategoryId = 7,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 7, Value = "Black" },
                    new { SpecId = 8, Value = "Yes" },
                    new { SpecId = 9, Value = "Yes" }
                }
            },
	        #endregion

            #region TenantThree
            

            // 23
            new
            {
                Name = "OSRAM LED Lamp Value 4.9W E27 Warm White",
                Desc = "OSRAM LED VALUE lamps are used when economical lighting is needed.",
                Price = 1.5m,
                Image = "4052899326927_1.jpg",
                CategoryId = 8,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 10, Value = "E27" },
                    new { SpecId = 11, Value = "4.9W" },
                    new { SpecId = 12, Value = "2700K" },
                    new { SpecId = 13, Value = "470LM" },
                }
            },

            // 24
            new
            {
                Name = "OSRAM LED Lamp Value 10W E27 Natural White",
                Desc = "OSRAM LED VALUE lamps are used when economical lighting is needed.",
                Price = 1.9m,
                Image = "led-sij10w-e27-230v-4000k-valuecla75-mlecna-osram.jpg",
                CategoryId = 8,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 10, Value = "E27" },
                    new { SpecId = 11, Value = "10W" },
                    new { SpecId = 12, Value = "4000K" },
                    new { SpecId = 13, Value = "950LM" },
                }
            },

            // 25
            new
            {
                Name = "OSRAM LED Lamp Value 6.5W E27 Clear Natural White",
                Desc = "OSRAM LED VALUE lamps are used when economical lighting is needed.",
                Price = 2.5m,
                Image = "led-sij65w-e27-230v-4000k-806lm-value-cla60-bistra-osram.jpg",
                CategoryId = 8,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 10, Value = "E27" },
                    new { SpecId = 11, Value = "6.5W" },
                    new { SpecId = 12, Value = "4000K" },
                    new { SpecId = 13, Value = "806LM" },
                }
            },

            // 26
            new
            {
                Name = "OSRAM LED Lamp Value 5.5W E14 White",
                Desc = "LED Lamps with \"mini-candle\" shape. OSRAM LED VALUE lamps are used when economical lighting is needed.",
                Price = 2m,
                Image = "4052899971066_1.jpg",
                CategoryId = 8,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 10, Value = "E14" },
                    new { SpecId = 11, Value = "5.5W" },
                    new { SpecId = 12, Value = "6500K" },
                    new { SpecId = 13, Value = "470LM" },
                }
            },

            // 27
            new
            {
                Name = "OSRAM LEDSSTICK60 8W E14 Natural White",
                Desc = "Attractive lamp appearance wherever compact and efficient lamps are needed.",
                Price = 3.5m,
                Image = "led-sij8w-e14-4000k-230v-mlecna-ledsstick60-osram.jpg",
                CategoryId = 8,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 10, Value = "E14" },
                    new { SpecId = 11, Value = "8W" },
                    new { SpecId = 12, Value = "4000K" },
                    new { SpecId = 13, Value = "806LM" },
                }
            },

            // 28
            new
            {
                Name = "OSRAM LED STAR 3.2W GU10 Warm White",
                Desc = "Long-lasting lamp used for focused illuminating. Low energy consumption.",
                Price = 1.6m,
                Image = "4052899958135_1.jpg",
                CategoryId = 8,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 10, Value = "GU10" },
                    new { SpecId = 11, Value = "3.2W" },
                    new { SpecId = 12, Value = "2700K" },
                    new { SpecId = 13, Value = "290LM" },
                }
            },

            // 29
            new
            {
                Name = "LEDVANCE LED SLIM FI118/105 6W Natural White",
                Desc = "LEDVANCE LED SLIM PANELS are used as a direct alternative to lamps. Slim case and easy installation.",
                Price = 11m,
                Image = "led-panel-fi118105-6w-ugr-4000k-420lm-beli-downlight-ledvance.jpg",
                CategoryId = 9,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 11, Value = "6W" },
                    new { SpecId = 12, Value = "4000K" },
                    new { SpecId = 13, Value = "430LM" },
                    new { SpecId = 14, Value = "D 118(105) / H 30" },
                }
            },

            // 30
            new
            {
                Name = "LEDVANCE LED SLIM FI169/158 12W Warm White",
                Desc = "LEDVANCE LED SLIM PANELS are used as a direct alternative to lamps. Slim case and easy installation.",
                Price = 15m,
                Image = "led-panel-169x169155x155-12w-ugr6500k-1020lm-beli-ledvance.jpg",
                CategoryId = 9,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 11, Value = "12W" },
                    new { SpecId = 12, Value = "2700K" },
                    new { SpecId = 13, Value = "1020LM" },
                    new { SpecId = 14, Value = "D 169(158) / H 30" },
                }
            },

            // 31
            new
            {
                Name = "SubstiTUBE T8 EM 1200MM 15.6W Natural White",
                Desc = "LED replacement for classic T8 fluorescent lamps. No bending thanks to glass tube.",
                Price = 8m,
                Image = "led-cev-t8-14w-230v-1200mm-4000k-2100lm-rl-t8-36-s-840-em-radium.jpg",
                CategoryId = 10,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 11, Value = "15.6W" },
                    new { SpecId = 12, Value = "4000K" },
                    new { SpecId = 13, Value = "2250LM" },
                    new { SpecId = 15, Value = "1200mm" },
                }
            },
            
            // 32
            new
            {
                Name = "SubstiTUBE T8 EM 800MM 14W White",
                Desc = "LED replacement for classic T8 fluorescent lamps. No bending thanks to glass tube.",
                Price = 7m,
                Image = "led-cev-t8-14w-230v-1200mm-4000k-2100lm-rl-t8-36-s-840-em-radium.jpg",
                CategoryId = 10,
                Specifications = new List<dynamic>()
                {
                    new { SpecId = 11, Value = "14W" },
                    new { SpecId = 12, Value = "6500K" },
                    new { SpecId = 13, Value = "2100LM" },
                    new { SpecId = 15, Value = "800mm" },
                }
            }


            #endregion

        };
        public static List<Image> Images
        {
            get
            {
                var img = new List<Image>();
                for (int i = 0; i < ProductInfo.Count; i++)
                {
                    img.Add(new Image()
                    {
                        Id = i + 1,
                        Path = ProductInfo[i].Image
                    });
                }

                return img;
            }
        }
        public static List<Product> Products
        {
            get
            {
                var prod = new List<Product>();
                for (int i = 0; i < ProductInfo.Count; i++)
                {
                    prod.Add(new Product()
                    {
                        Id = i + 1,
                        Name = ProductInfo[i].Name,
                        Description = ProductInfo[i].Desc,
                        Price = ProductInfo[i].Price,
                        ImageId = i + 1,
                        CategoryId = ProductInfo[i].CategoryId
                    });
                }

                return prod;
            }
        }
        public static List<ProductSpecification> ProductSpecifications
        {
            get
            {
                var prodSpec = new List<ProductSpecification>();
                int j = 1;

                for (int i = 0; i<ProductInfo.Count; i++)
                {
                    foreach (var spec in ProductInfo[i].Specifications)
                    {
                        prodSpec.Add(new ProductSpecification()
                        {
                            Id = j++,
                            ProductId = i + 1,
                            SpecificationId = spec.SpecId,
                            Value = spec.Value
                        });
                    }
                }

                return prodSpec;
            }
        }


        public static List<dynamic> UserInfo = new List<dynamic>()
        {
            #region TenantOne

            new
            {
                Username = "admin",
                FullName = "Global Admin",
                Email = "admin@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Role = UserRole.SuperUserGlobal,
                TenantId = 1
            },
            new
            {
                Username = "rgadmin",
                FullName = "Home Gallery Admin",
                Email = "rgadmin@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Role = UserRole.SuperUserTenant,
                TenantId = 1
            },
            new
            {
                Username = "dalibor",
                FullName = "Dalibor Stojanovic",
                Email = "ds3442@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 1, Value = "Svetozara Markovica 25, Beograd"},
                    new { CountryId = 1, Value = "Omladinskih brigada 42, Beograd"}
                },
                Orders = new List<dynamic>
                {
                    new 
                    { 
                        Location = "Omladinskih brigada 42, Beograd, Serbia", 
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 1, Quantity = 2 },
                            new { ProductId = 9, Quantity = 1 }
                        }
                    },
                    new
                    {
                        Location = "Omladinskih brigada 42, Beograd, Serbia",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 4, Quantity = 1 }
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 1
            },
            new
            {
                Username = "urosb",
                FullName = "Uros Babic",
                Email = "urosb@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 1, Value = "Takovska 54, Beograd" }
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "Takovska 54, Beograd, Serbia",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 10, Quantity = 1 }
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 1
            },
            new
            {
                Username = "weissr1",
                FullName = "Weiss Ramone",
                Email = "weissr1@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 2, Value = "Meininger Strasse 74, Niederbrombach" }
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "Meininger Strasse 74, Niederbrombach, Germany",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 5, Quantity = 1 },
                        }
                    },
                    new
                    {
                        Location = "Meininger Strasse 74, Niederbrombach, Germany",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 3, Quantity = 2 },
                        }
                    },
                },
                Role = UserRole.User,
                TenantId = 1
            },

	        #endregion

            #region TenantTwo

                
            new
            {
                Username = "tsadmin",
                FullName = "TruePhone Shop Admin",
                Email = "tsadmin@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Role = UserRole.SuperUserTenant,
                TenantId = 2
            },

            new
            {
                Username = "jacobh",
                FullName = "Jacob Henry",
                Email = "jacob.henry1@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 3, Value = "31 Colorado Way, Wyberton"},
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "31 Colorado Way, Wyberton, United Kingdom",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 13, Quantity = 2 },
                        }
                    },
                    new
                    {
                        Location = "31 Colorado Way, Wyberton, United Kingdom",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 19, Quantity = 1 }
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 2
            },

            new
            {
                Username = "lara12",
                FullName = "Lara Sanders",
                Email = "lara.s12@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 3, Value = "27 Terrick Rd, EGGESFORD BARTON"},
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "27 Terrick Rd, EGGESFORD BARTON, United Kingdom",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 12, Quantity = 1 },
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 2
            },

            new
            {
                Username = "aimeenorth",
                FullName = "Aimee North",
                Email = "aimeenorth@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 3, Value = "34 Fox Lane, Blindcrake"},
                    new { CountryId = 3, Value = "92 Castledore Road, Tunstall"},
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "92 Castledore Road, Tunstall, United Kingdom",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 16, Quantity = 1 },
                            new { ProductId = 17, Quantity = 2 },
                        }
                    },
                    new
                    {
                        Location = "34 Fox Lane, Blindcrake, United Kingdom",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 21, Quantity = 1 },
                        }
                    },
                },
                Role = UserRole.User,
                TenantId = 2
            },
	        #endregion

            #region TenantThree

            new
            {
                Username = "lhadmin",
                FullName = "Light Hub Admin",
                Email = "lhadmin@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Role = UserRole.SuperUserTenant,
                TenantId = 3
            },

            new
            {
                Username = "bjen",
                FullName = "Benjamin Jensen",
                Email = "jensenb1@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 4, Value = "Roligheten 209, DRAMMEN"},
                    new { CountryId = 4, Value = "Skogstadveien 135, SKI"},
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "Roligheten 209, DRAMMEN, Norway",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 24, Quantity = 2 },
                            new { ProductId = 26, Quantity = 2 },
                        }
                    },
                    new
                    {
                        Location = "Roligheten 209, DRAMMEN, Norway",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 30, Quantity = 1 }
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 3
            },

            new
            {
                Username = "samiraa",
                FullName = "Samira Brandal",
                Email = "samirabran@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 4, Value = "Tjernveien 95, Oslo"},
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "Tjernveien 95, Oslo, Norway",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 30, Quantity = 2 },
                            new { ProductId = 31, Quantity = 1 },
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 3
            },

            new
            {
                Username = "joakimhil",
                FullName = "Joakim Hilmarsen",
                Email = "joakimhil@mail.com",
                Password = "$2a$11$bTAkbk.QchTxo5u9iTxNvejTJVbfI.G7Qj8dgW5EmhuL7XMpEc1ny",
                Addresses = new List<dynamic>
                {
                    new { CountryId = 4, Value = "Studalsmyro 73, Stord"},
                },
                Orders = new List<dynamic>
                {
                    new
                    {
                        Location = "Studalsmyro 73, Stord, Norway",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 30, Quantity = 1 },
                            new { ProductId = 24, Quantity = 2 },
                        }
                    },
                    new
                    {
                        Location = "Studalsmyro 73, Stord, Norway",
                        Items = new List<dynamic>()
                        {
                            new { ProductId = 25, Quantity = 2 },
                        }
                    }
                },
                Role = UserRole.User,
                TenantId = 3
            },

	        #endregion
        };
        public static List<User> Users
        {
            get
            {
                var users = new List<User>();

                for (int i = 0; i < UserInfo.Count; i++)
                {
                    users.Add(new User()
                    {
                        Id = i + 1,
                        Username = UserInfo[i].Username,
                        FullName = UserInfo[i].FullName,
                        Email = UserInfo[i].Email,
                        Password = UserInfo[i].Password,
                        RoleId = (byte) UserInfo[i].Role,
                        TenantId = UserInfo[i].TenantId
                    });
                }

                return users;
            }
        }
        public static List<Address> Addresses
        {
            get
            {
                var addr = new List<Address>();
                int j = 1;

                for (int i = 0; i < UserInfo.Count; i++)
                {
                    if(UserInfo[i].GetType().GetProperty("Addresses") != null)
                    foreach (var a in UserInfo[i].Addresses)
                    {
                        addr.Add(new Address()
                        {
                            Id = j++,
                            UserId = i + 1,
                            CountryId = a.CountryId,
                            Value = a.Value
                        });
                    }
                }

                return addr;
            }
        }
        public static List<Order> Orders
        {
            get
            {
                var orders = new List<Order>();
                int j = 1;

                for (int i = 0; i < UserInfo.Count; i++)
                {
                    if (UserInfo[i].GetType().GetProperty("Orders") != null)
                        foreach (var order in UserInfo[i].Orders)
                        {
                            orders.Add(new Order()
                            {
                                Id = j++,
                                UserId = i + 1,
                                DeliveryLocation = order.Location,
                                CreatedAt = DateTime.Now
                                
                            });
                        }
                }

                return orders;
            }
        }
        public static List<OrderItem> OrderItems
        {
            get
            {
                var items = new List<OrderItem>();
                int j = 1, k = 1;

                for (int i = 0; i < UserInfo.Count; i++)
                {
                    if (UserInfo[i].GetType().GetProperty("Orders") != null)
                        foreach (var order in UserInfo[i].Orders)
                        {
                            foreach (var item in order.Items)
                            {
                                var product = ProductInfo[item.ProductId - 1];
                                items.Add(new OrderItem()
                                {
                                    Id = k++,
                                    OrderId = j,
                                    ProductId = item.ProductId,
                                    ProductName = product.Name,
                                    UnitPrice = product.Price,
                                    Quantity = item.Quantity
                                });
                            }

                            j++;
                        }
                }

                return items;
            }
        }

    }
}
