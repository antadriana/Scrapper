using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using log4net;
using System.Threading;

namespace SeleniumScrapper
{
    class Program
    {
        public static IWebDriver driver;
        public static List<string> textresults;
        public static string message = "";
        private static Timer timer;
     
        static void Main(string[] args)
        {

            //driver.Url = "https://www.washingtonpost.com/world/?gclid=Cj0KCQjw4dr0BRCxARIsAKUNjWQuju-f1SmohLpMxXfcNzov8fWZeRgXlOs6gnofW47DHoMNlYuDoUgaArjVEALw_wcB&utm_campaign=intl_news_search_global&utm_medium=google&utm_source=acquisition";

            timer = new Timer((o) =>
            {
                ScrapAndSend();

            }, null, 0, 100000);

            Console.ReadKey();
     
        }

        public static void ScrapAndSend()
        {
            driver = new ChromeDriver();
            driver.Url = "https://money.cnn.com/data/hotstocks/index.html";
            scrap();
            Sender.Send("check", message);
            driver.Quit();
        }

        public static void scrap()
        {
            HtmlAgilityPack.HtmlDocument htmlDocument0 = new HtmlAgilityPack.HtmlDocument();
            List<string> datetime = new List<string>();
            string times = driver.FindElement(By.CssSelector(".wsod_fRight.wsod_disclaimer")).FindElement(By.TagName("span")).Text;
            string date = times.Substring(times.Length - 3);
         
            /*string[] s= times.Split(':');
            if (s[1].Contains("pm"))
                s[0] = (Convert.ToInt32(s[0]) + 12).ToString();
            s[1]=s[1].Remove(2);
            string res = s[0];
            double h = Convert.ToDouble(res);
            double m = Convert.ToDouble(s[1]);*/
            if (readDate(Convert.ToDouble(date)))
            {
                DateTime dateInWash = DateTime.Now.AddHours(-7);
                System.IO.File.WriteAllText(@"C:\Users\Adriana\Desktop\logger.txt", string.Empty);
               System.IO.File.WriteAllText(@"C:\Users\Adriana\Desktop\logger.txt", date);
            //  System.IO.File.WriteAllText(@"C:\Users\Adriana\Desktop\logger.txt", h.ToString() + ':' + m.ToString()+ " "+dateInWash.Date);
            List<Info> infos = new List<Info>();
                IList<IWebElement> searchElements = driver.FindElements(By.TagName("tbody"));
                foreach (IWebElement i in searchElements)
                {
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    var text = i.GetAttribute("innerHTML");
                    htmlDocument.LoadHtml(text);
                    var inputs = htmlDocument.DocumentNode.Descendants("tr").ToList();

                    foreach (var items in inputs)
                    {
                        HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument1.LoadHtml(items.InnerHtml);
                        var tds = htmlDocument1.DocumentNode.Descendants("td").ToList();
                        if (tds.Count != 0)
                        {

                            Info current = new Info(tds[0].InnerText, tds[1].InnerText, tds[2].InnerText, tds[3].InnerText);
                            infos.Add(current);
                            // textresults.Add(tds[0].InnerText.ToString() + " " + tds[1].InnerText.ToString() + " " + tds[2].InnerText.ToString() + " " + tds[3].InnerText.ToString());
                        }
                    }
                }
                AssembledInfo assembled = new AssembledInfo(infos);
                message = Newtonsoft.Json.JsonConvert.SerializeObject(infos);
            }
            else
            {
                DateTime dt = DateTime.Now;
                DateTime washington = dt.AddHours(-7);
               
                System.IO.File.WriteAllText(@"C:\Users\Adriana\Desktop\errorLog.txt", "Info is up to date to "+washington.Hour+":" + DateTime.Now.Minute);
            }
        }
        public static void scrapWP()
        {
            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            // var children = main.FindElements(By.TagName("div"));
            // List<IWebElement> links = new List<IWebElement>();
            // foreach (var child in children)
            /*{
               links.Add( child.FindElement(By.TagName("href")));
            }*/
            /*  foreach (IWebElement i in children)
              {
                  HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                  var text = i.GetAttribute("innerHTML");
                  htmlDocument.LoadHtml(text);
                  var inputs = htmlDocument.DocumentNode.Descendants("tr").ToList();
                  foreach (var items in inputs)
                  {
                      HtmlAgilityPack.HtmlDocument htmlDocument1 = new HtmlAgilityPack.HtmlDocument();
                      htmlDocument1.LoadHtml(items.InnerHtml);
                      var tds = htmlDocument1.DocumentNode.Descendants("td").ToList();
                      if (tds.Count != 0)
                          textresults.Add(tds[0].InnerText.ToString() + " " + tds[1].InnerText.ToString() + " " + tds[2].InnerText.ToString() + " " + tds[3].InnerText.ToString());
                  }
                  textresults.Add("\t\r");
              }*/

        }
        public static bool read(double  hourNow, double minuteNow)
        {
            string read = System.IO.File.ReadAllText(@"C:\Users\Adriana\Desktop\logger.txt");
            //string[] elemnts = read.Split(' ');
            string[] hour = read.Split(':');
            double hours = Convert.ToDouble(hour[0]);
            double minutes = Convert.ToDouble(hour[1]);

            return ((hourNow > hours) || ((hourNow == hours) && (minuteNow > minutes)));
        }

        public static bool readDate(double date)
        {
            string read = System.IO.File.ReadAllText(@"C:\Users\Adriana\Desktop\logger.txt");
            double dateLast = Convert.ToDouble(read);
            return ((date > dateLast));
        }
    }   
}