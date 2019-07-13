using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public static class Program
    {
        static List<Model.ProductCategory> listProductCategory = new List<Model.ProductCategory>();
        static List<Model.Product> listProduct = new List<Model.Product>();
        static List<Model.ProductSellPrice> listProductSellPrice = new List<Model.ProductSellPrice>();

        static List<Model.Transaction> listTransaction = new List<Model.Transaction>();
        static List<Model.TransactionDetail> listTransactionDetail = new List<Model.TransactionDetail>();
        static List<string> l_color = new List<string>();
        static List<string> l_size = new List<string>();

        
        static void Main(string[] args)
        {
            InitDataCategories();
            int type;
         
              
            Console.WriteLine("Store Management");
            Console.WriteLine("Press 1 to Buy , 2 to Sell, 5  Exit  ");
            Console.WriteLine("-------------------------------------------------------------------\n");
            bool doApp = true;
            do
            {
               
                try
                {
                    type = Convert.ToInt16(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            Guid id = new Guid();
                            BuyProduct( ref id);
                            Model.Transaction tr = listTransaction.Where(x => x.ID == id).FirstOrDefault();
                             List< Model.TransactionDetail> list_detial = listTransactionDetail.Where(x => x.TransactionID == id).ToList();
                            Console.Clear();
                            Console.WriteLine("Store Management");
                            Console.WriteLine("Press 1 to Buy , 2 to Sell,  5  Exit  ");
                            Console.WriteLine("-------------------------------------------------------------------\n");

                            Console.WriteLine("--------------Buy Items-----------------");
                            int count = 1;
                            foreach (var item in list_detial)
                            {
                                Console.WriteLine(count.ToString() + "   " + item.ProductID + "   " + item.Size + "   " + item.Color + "   " + item.Quantity.ToString() + "   " + item.Price.ToString() + "   " + item.Amount.ToString());
                                count++;
                            }
                            Console.WriteLine("-----------------------------------");
                            
                            Console.WriteLine("Total quantiy : " + tr.Quantity.ToString());
                            Console.WriteLine("Total amount : " + tr.Amount.ToString());
                            Console.ReadLine();
                            break;

                        case 2:
                            Guid ids = new Guid();
                            SellProduct(ref ids);
                            Model.Transaction trs = listTransaction.Where(x => x.ID == ids).FirstOrDefault();
                            List<Model.TransactionDetail> list_detials = listTransactionDetail.Where(x => x.TransactionID == ids).ToList();
                            Console.Clear();
                            Console.WriteLine("Store Management");
                            Console.WriteLine("Press 1 to Buy , 2 to Sell,  5  Exit  ");
                            Console.WriteLine("-------------------------------------------------------------------\n");

                            Console.WriteLine("--------------Sell Items-----------------");
                            int counts = 1;
                            foreach (var item in list_detials)
                            {
                                Console.WriteLine(counts.ToString() + "   " + item.ProductID + "   " + item.Size + "   " + item.Color + "   " + item.Quantity.ToString() + "   " + item.Price.ToString() + "   " + item.Amount.ToString());
                                counts++;
                            }
                            Console.WriteLine("-----------------------------------");

                            Console.WriteLine("Total quantiy : " + trs.Quantity.ToString());
                            Console.WriteLine("Total amount : " + trs.Amount.ToString());
                            Console.ReadLine();
                            break;

                        case 5:
                            doApp = false;
                            break;

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Has Error");
                }
            } while (doApp);
        }

        private static void InitDataCategories()
        {
            // ProductCategory
            Model.ProductCategory model1 = new Model.ProductCategory();
            model1.ID = Guid.NewGuid();
            model1.Name = "Shirt";
            listProductCategory.Add(model1);
            // Product

            Model.Product model2 = new Model.Product();
            model2.ID = "1";
            model2.ProductCategoryID = listProductCategory.Find(x => x.Name == "Shirt").ID;
            model2.Name = "T-Shirt";
            model2.IsUsed = true;

            listProduct.Add(model2);

            model2 = new Model.Product();
            model2.ID = "2";
            model2.ProductCategoryID = listProductCategory.Find(x => x.Name == "Shirt").ID;
            model2.Name = "Dress Shirt";
            model2.IsUsed = true;

            listProduct.Add(model2);

            // ProductPrice
            Model.ProductSellPrice model3 = new Model.ProductSellPrice();
            model3.ID = Guid.NewGuid();
            model3.ProductID = listProduct.Find(x => x.Name == "T-Shirt").ID;
            model3.Price = 12;

            listProductSellPrice.Add(model3);

            model3 = new Model.ProductSellPrice();
            model3.ID = Guid.NewGuid();
            model3.ProductID = listProduct.Find(x => x.Name == "Dress Shirt").ID;
            model3.Price = 20;
            listProductSellPrice.Add(model3);
            l_color.Add("Red");
            l_color.Add("Blue");
            l_size.Add("S");
            l_size.Add("M");
        }

        private static void BuyProductDetail(ref Model.TransactionDetail detail1)
        {
            try
            {
                string l_pname = "";
                string l_pcolor = "";
                string l_psize = "";

                List<string> l_pId = new List<string>();
                foreach (var item in listProduct)
                {
                    l_pname += (string.IsNullOrEmpty(l_pname) ? "" : ";") + item.ID + " for " + item.Name;
                    l_pId.Add(item.ID);

                }
                foreach (var item in l_size)
                {
                    l_psize += (string.IsNullOrEmpty(l_psize) ? "" : ";") + item;

                }
                foreach (var item in l_color)
                {
                    l_pcolor += (string.IsNullOrEmpty(l_pcolor) ? "" : ";") + item;

                }
                Console.WriteLine("Select Product (" + l_pname + "): ");
                string productID = Console.ReadLine();
                string size = "";
                string color = "";
                int quantity_d = 0;
                decimal amount_d = 0;
                decimal price = 0;

                bool exists = false;
                var itemsP = (l_pId.Find(p => p.ToString() == productID));
                if (itemsP == null)
                    exists = false;
                else
                    exists = (itemsP.Count() > 0 ? true : false);
                
                if (exists)
                {
                    Console.WriteLine("Select Size (" + l_psize + ") ");
                    size = Console.ReadLine();
                    var itemsF = l_size.Find(p => p.ToString() == size);
                    bool exists_s;
                    if (itemsF == null)
                        exists_s = false;
                    else
                        exists_s = (itemsF.Count() > 0 ? true : false);
                    if (exists_s)
                    {
                        Console.WriteLine("Select Color (" + l_pcolor + ") ");
                        color = Console.ReadLine();
                        bool exists_c = (l_color.Find(p => p.ToString() == color).Count() > 0 ? true : false);
                        if (exists_c)
                        {
                            Console.WriteLine("Input Quantity:");
                            try
                            {
                                quantity_d = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("Input Price:");
                                price = Convert.ToDecimal(Console.ReadLine());
                                amount_d = quantity_d * price;

                                detail1.ID = Guid.NewGuid();
                                detail1.ProductID = productID;
                                detail1.Quantity = quantity_d;
                                detail1.Size = size;
                                detail1.Color = color;
                                detail1.Amount = amount_d;
                                detail1.Price = price;
                              
                            }
                            catch
                            {
                                Console.WriteLine(" Please input quantity");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Please select size item in list  " + l_psize);
                            Console.ReadKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine(" Please  select color item in list  " + l_psize);
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine(" Please selct item in list  " + l_pname);
                    Console.ReadKey();
                }
               

            }
            catch (Exception ex)
            {
                Console.WriteLine("Has error when buy item");
                throw;
            }
        }
        private static void BuyProduct ( ref Guid id )
        {
            int quantity = 0;
            decimal amount = 0;
            Model.Transaction trc1 = new Model.Transaction();
            List<Model.TransactionDetail> list_detial = new List<Model.TransactionDetail>();
            trc1.Cashier = "Admin";
            trc1.Type = 1;
            trc1.Date = DateTime.Now;
            trc1.ID = Guid.NewGuid();
            bool add = true;
            while(add)
            {
                Model.TransactionDetail detail1 = new Model.TransactionDetail();
                BuyProductDetail(ref detail1);
                detail1.TransactionID = trc1.ID;
                quantity += detail1.Quantity;
                amount += detail1.Amount;
                list_detial.Add(detail1);
                Console.WriteLine("Press 1 to Add New Item, 2 to  Payment");
                try
                {
                   int type = Convert.ToInt16(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            add = true;
                            break;
                        case 2:
                            add = false;
                            id = trc1.ID;
                            break;
                        default:
                            add = false;
                            break;

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Has Error");
                }



            }
            trc1.Quantity = quantity;
            trc1.Amount = amount;
            listTransaction.Add(trc1);
            listTransactionDetail.AddRange(list_detial);





        }
        private static void SellProduct( ref Guid id)
        {
            int quantity = 0;
            decimal amount = 0;
            Model.Transaction trc1 = new Model.Transaction();
            List<Model.TransactionDetail> list_detial = new List<Model.TransactionDetail>();
            trc1.Cashier = "Admin";
            trc1.Type = 2;
            trc1.Date = DateTime.Now;
            trc1.ID = Guid.NewGuid();
            bool add = true;
            while (add)
            {
                Model.TransactionDetail detail1 = new Model.TransactionDetail();
                SellProductDetail(ref detail1);
                detail1.TransactionID = trc1.ID;
                quantity += detail1.Quantity;
                amount += detail1.Amount;
                list_detial.Add(detail1);
                Console.WriteLine("Press 1 to Add New Item, 2 to  Payment");
                try
                {
                    int type = Convert.ToInt16(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            add = true;
                            break;
                        case 2:
                            add = false;
                            id = trc1.ID;
                            break;
                        default:

                            break;

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Has Error");
                }



            }
            trc1.Quantity = quantity;
            trc1.Amount = amount;
            listTransaction.Add(trc1);
            listTransactionDetail.AddRange(list_detial);





        }
        private static void SellProductDetail(ref Model.TransactionDetail detail1)
        {
            try
            {
                string l_pname = "";
                string l_pcolor = "";
                string l_psize = "";

                List<string> l_pId = new List<string>();
                foreach (var item in listProduct)
                {
                    l_pname += (string.IsNullOrEmpty(l_pname) ? "" : ";") + item.ID + " for " + item.Name;
                    l_pId.Add(item.ID);

                }
                foreach (var item in l_size)
                {
                    l_psize += (string.IsNullOrEmpty(l_psize) ? "" : ";") + item;

                }
                foreach (var item in l_color)
                {
                    l_pcolor += (string.IsNullOrEmpty(l_pcolor) ? "" : ";") + item;

                }
                Console.WriteLine("Select Product (" + l_pname + "): ");
                string productID = Console.ReadLine();
                string size = "";
                string color = "";
                int quantity_d = 0;
                decimal amount_d = 0;
                decimal price = 0;

                bool exists = (l_pId.Find(p => p.ToString() == productID).Count() > 0 ? true : false);

                Model.ProductSellPrice selectedProduct = listProductSellPrice.Where(p => p.ProductID == productID && p.DateApply < DateTime.Now).OrderByDescending(x =>x.DateApply).FirstOrDefault();
                if (exists)
                {
                    Console.WriteLine("Select Size (" + l_psize + ") ");
                    size = Console.ReadLine();
                    bool exists_s = (l_size.Find(p => p.ToString() == size).Count() > 0 ? true : false);
                    if (exists_s)
                    {
                        Console.WriteLine("Select Color (" + l_pcolor + ") ");
                        color = Console.ReadLine();
                        bool exists_c = (l_color.Find(p => p.ToString() == color).Count() > 0 ? true : false);
                        if (exists_c)
                        {
                            Console.WriteLine("Input Quantity:");
                            try
                            {
                                quantity_d = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("Price:" + selectedProduct.Price.ToString());
                                price = selectedProduct.Price;
                                amount_d = quantity_d * price;

                                detail1.ID = Guid.NewGuid();
                                detail1.ProductID = productID;
                                detail1.Quantity = quantity_d;
                                detail1.Size = size;
                                detail1.Color = color;
                                detail1.Amount = amount_d;
                                detail1.Price = price;

                            }
                            catch
                            {
                                Console.WriteLine(" Please input quantity");
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Please select size item in list  " + l_psize);
                        }

                    }
                    else
                    {
                        Console.WriteLine(" Please  select color item in list  " + l_psize);
                    }
                }
                else
                {
                    Console.WriteLine(" Please selct item in list  " + l_pname);
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Has error when buy item");
                throw;
            }
        }
    }
}
