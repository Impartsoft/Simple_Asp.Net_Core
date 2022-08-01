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

        // 运行修改
        // step1: 下载 https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
        // step2: 放到当前单元测试程序集下
        // step3: 修改文件名字为 MicrosoftWebDriver.exe
        // step4: 将文件属性修改成“始终复制”

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
