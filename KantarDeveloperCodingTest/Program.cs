using System.Globalization;

namespace Kantar.Developer.Coding.Test
{
    public class TestClass
    {
        const string keyWord = "shoppingbasket ";
        private static string userInputRewritten = "";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.WriteLine("Insert your shop list");
            string userInput = Console.ReadLine();
            if (!VerifyInputStringFormat(userInput))
            {
                return;
            }
            string[] shopList = ConvertUserInput(userInputRewritten);
            MarketCashier(shopList);
        }

        public static bool VerifyInputStringFormat(string userInput)
        {
            if (userInput != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(userInput.Trim(), "^"+keyWord+ "[a-zA-Z].*", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("ERROR: Invalid command");
                    return false;
                }
                userInputRewritten = System.Text.RegularExpressions.Regex.Replace(userInput.ToLower().Trim(), @"\s+", " ");
                userInputRewritten = userInputRewritten.Replace("shoppingbasket", "");
            }
            else
            {
                Console.WriteLine("ERROR: Invalid command");
                return false;
            }
            if (userInputRewritten.Replace(keyWord, "").Length == 0)
            {
                Console.WriteLine("ERROR: shoppingbasket is empty");
                return false;
            }
            return true;
        }

        public static string[] ConvertUserInput(string input)
        {
            string[] shopList = { };
            if (input == null)
            {
                return shopList;
            }
            shopList = input.Trim().Split(' ');
            if ((input.Contains("soup")) && (input.Contains("bread")))
            {
                int soupCounter = 0;
                int breadPromoQuantity = 0;

                for (int i = 0; i < shopList.Length; i++)
                {
                    if (String.Compare(shopList[i], "soup") == 0)
                    {
                        soupCounter++;
                    }
                }

                if (soupCounter >= 2)
                {
                    breadPromoQuantity = soupCounter / 2;
                }

                for (int i = 0; i <= shopList.Length; i++)
                {
                    if ((breadPromoQuantity > 0) && (shopList[i].Equals("bread")))
                    {
                        shopList[i] = "breadMultiBuyPromo";
                        breadPromoQuantity--;
                    }
                }

            }
            return shopList;
        }

        public static List<string> MarketCashier(string[] shopList)
        {
            int applePromoCounter = 0;
            int breadPromoCounter = 0;
            float finalValue = 0;
            float finalValueWithDisccount = 0;
            int disccountCounter = 0;
            float appleValue = 1.00f;
            DateTime appleStartPromotionDate = new DateTime(2022, 09, 04);
            DateTime appleEndPromotionDate = new DateTime(2022, 09, 10);
            List<string> response = new List<string>();
            if (shopList == null)
            {
                return response;
            }

            for (int i = 0; i < shopList.Length; i++)
            {
                string item = shopList[i];
                switch (item)
                {
                    case "soup":
                        finalValue = finalValue + 0.65f;
                        finalValueWithDisccount = finalValueWithDisccount + 0.65f;
                        break;
                    case "bread":
                        finalValue = finalValue + 0.80f;
                        finalValueWithDisccount = finalValueWithDisccount + 0.80f;
                        break;
                    case "breadMultiBuyPromo":
                        finalValue = finalValue + 0.80f;
                        finalValueWithDisccount = finalValueWithDisccount + 0.40f;
                        breadPromoCounter++;
                        break;
                    case "milk":
                        finalValue = finalValue + 1.30f;
                        finalValueWithDisccount = finalValueWithDisccount + 1.30f;
                        break;
                    case "apples":
                        appleValue = 1.00f;
                        finalValue = finalValue + appleValue;
                        bool isPromotionTime = VerifyIsInPromotion(appleStartPromotionDate, appleEndPromotionDate);
                        if (isPromotionTime)
                        {
                            appleValue = (appleValue * 90f) / 100f;
                            applePromoCounter++;
                        }
                        finalValueWithDisccount = finalValueWithDisccount + appleValue;
                        break;
                    default:
                        Console.WriteLine("Whoops! something went wrong, can't find item with the name " + item);
                        response.Add("Whoops! something went wrong, can't find item with the name " + item);
                        return response;
                }
            }
            Console.WriteLine("Shopping Cost");
            Console.WriteLine("Subtotal: €" + String.Format("{0:0.00}", finalValue));
            response.Add("Subtotal: €" + String.Format("{0:0.00}", finalValue));
            if (applePromoCounter > 0)
            {
                float appleDisccountedValue = applePromoCounter * 0.10f;
                Console.WriteLine("Apples 10% off: -€" + String.Format("{0:0.00}", appleDisccountedValue));
                response.Add("Apples 10% off: -€" + String.Format("{0:0.00}", appleDisccountedValue));
                disccountCounter++;
            }
            if (breadPromoCounter > 0)
            {
                float breadDisccountedValue = breadPromoCounter * 0.40f;
                Console.WriteLine("Bread 50% off: -€" + String.Format("{0:0.00}", breadDisccountedValue));
                response.Add("Bread 50% off: -€" + String.Format("{0:0.00}", breadDisccountedValue));
                disccountCounter++;

            }
            if (disccountCounter == 0)
            {
                Console.WriteLine("(No offers available)");
                response.Add("(No offers available)");
            }
            Console.WriteLine("Total price: €" + String.Format("{0:0.00}", finalValueWithDisccount));
            response.Add("Total price: €" + String.Format("{0:0.00}", finalValueWithDisccount));
            return response;
        }

        public static bool VerifyIsInPromotion(DateTime startPromotion, DateTime endPromotion)
        {
            bool isPromotionTime = true;
            DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            int resultDateEarlier = DateTime.Compare(todaysDate, startPromotion);
            int resultDateLater = DateTime.Compare(todaysDate, endPromotion);
            if (resultDateEarlier < 0)
            {
                isPromotionTime = false;
            }

            if (resultDateLater > 0)
            {
                isPromotionTime = false;
            }
            return isPromotionTime;
        }
    }
}