using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;

namespace Simple_Asp.Net_Core.EdgeDriverTests
{
    [TestClass]
    public class EdgeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        // �����޸�
        // step1: ���� https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
        // step2: �ŵ���ǰ��Ԫ���Գ�����
        // step3: �޸��ļ�����Ϊ MicrosoftWebDriver.exe
        // step4: ���ļ������޸ĳɡ�ʼ�ո��ơ�

        private EdgeDriver _driver;

        [TestInitialize]
        public void EdgeDriverInitialize()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };

            var s = AppDomain.CurrentDomain.BaseDirectory;

            _driver = new EdgeDriver(options);
        }

        [TestMethod]
        public void VerifyPageTitle()
        {
            // Replace with your own test logic
            _driver.Url = "https://www.bing.com";
            Assert.AreEqual("Bing", _driver.Title);
        }

        [TestCleanup]
        public void EdgeDriverCleanup()
        {
            _driver.Quit();
        }
    }
}
