using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OraRend
{
    internal class Scraper
    {
        private static string _url = @"https://neptun3r.web.uni-corvinus.hu/Hallgatoi/login.aspx";

        public static List<UniClass> ScrapeClasses(string username, string password)
        {
            List<UniClass> classes = new List<UniClass>();

            // Minden böngészőre máshogy kell konfigurálni a Selenium motort, it a Chrome-ot használjuk
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl(_url);


            var usernameField = driver.FindElement(By.Name("user"));
            var passwordField = driver.FindElement(By.Id("pwd"));


            usernameField.SendKeys(username);
            passwordField.SendKeys(password);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            var loginButton = wait.Until(driver => driver.FindElement(By.Id("btnSubmit")));


            loginButton.Click();
            var studiesLink = wait.Until(driver =>
            {
                try
                {
                    return driver.FindElement(By.XPath("//li[contains(text(), 'Tanulmányok')]"));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
            Actions actions = new Actions(driver);
            actions.MoveToElement(studiesLink).Perform();
            var scheduleLink = driver.FindElement(By.Id("mb1_Tanulmanyok_Órarend"));
            actions.MoveToElement(scheduleLink).Perform();
            scheduleLink.Click();
            wait.Until(driver => driver.FindElement(By.Id("c_common_timetable_tabOrarend_body")));
            Thread.Sleep(3000);
            var days = driver.FindElements(By.ClassName("tg-col"));
            int d = 0;


            foreach (var day in days)
            {

                var classesInDay = day.FindElements(By.ClassName("chip"));

                foreach (IWebElement classElement in classesInDay)
                {

                    string title = classElement.GetAttribute("title");


                    string[] titleParts = title.Split('\n');
                    string[] timeRange = titleParts[0].Split(" - ");
                    string startingTime = timeRange[0].Substring(timeRange[0].LastIndexOf(" ") + 1);
                    string finishingTime = timeRange[1].Split("\r")[0].Trim();


                    string classTitle = titleParts[1].Split("[Óra] ")[1];


                    classes.Add(new UniClass
                    {

                        StartTime = TimeSpan.ParseExact(startingTime, "h\\:mm", null),
                        EndTime = TimeSpan.ParseExact(finishingTime, "h\\:mm", null),
                        Title = classTitle,
                        DayOfWeek = d
                    });

                }

                d++;
            }

            driver.Close();
            driver.Quit();
            return classes;
        
        }
    }
}
