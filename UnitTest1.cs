namespace CRIFTestsDzurko;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Tests
{
    IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void displayingHomePage()
    {
        string url = "https://sk.margo.crif.com/login";
        string cssPath = "#root > div > div.TwoColumnFullPageLayout__LeftPart-sc-17mxd22-1.cOkVnb > div.components__LeftContent-sc-16242qy-1.dolKQZ > div.components__FormWrapper-sc-16242qy-2.dlmdFm > div.components__ContentWrapper-sc-16242qy-8.hljmQv > div > div > div.rsw_2f.rsw_3G > form > div > div > div.components__FormRow-sc-16242qy-0.jAJELE > div > img";

        driver.Navigate().GoToUrl(url);
        IWebElement margoLogo = driver.FindElement(By.CssSelector(cssPath));

        if (margoLogo.Displayed) {
            Assert.Pass();
        }
        else {
            Assert.Fail();
        }
    }

    [Test]
    public void failedLoginAttempt()
    {
        string url = "https://sk.margo.crif.com/login";
        string invalidLoginCssPath = "#root > div > div.TwoColumnFullPageLayout__LeftPart-sc-17mxd22-1.cOkVnb > div.components__LeftContent-sc-16242qy-1.dolKQZ > div.components__FormWrapper-sc-16242qy-2.dlmdFm > div.components__ContentWrapper-sc-16242qy-8.hljmQv > div > div > div.rsw_2f.rsw_3G > form > div > div > div.components__FormRow-sc-16242qy-0.dbCPkj > div > div > div > div";
        string invalidLoginString = "The user or password entered is incorrect";

        driver.Navigate().GoToUrl(url);

        IWebElement usernameField = driver.FindElement(By.Id("ta-username"));
        IWebElement passwordField = driver.FindElement(By.Id("ta-password"));
        IWebElement loginButton = driver.FindElement(By.Id("ta-login"));

        usernameField.SendKeys("testCaseUsername");
        passwordField.SendKeys("testCasePassword");
        loginButton.Click();
        Thread.Sleep(1000);

        IWebElement invalidLogin = driver.FindElement(By.CssSelector(invalidLoginCssPath));
        Assert.That(invalidLogin.Text,Is.EqualTo(invalidLoginString));
    }

    [Test]
    public void analyzeMarketClick() 
    {
        string url = "https://sk.margo.crif.com/login";
        string anaylzeMarketIconCSS = "#root > div > div.TwoColumnFullPageLayout__RightPart-sc-17mxd22-2.cdgANH > div.components__RightContent-sc-16242qy-3.dYhwsL > div.InformationSlider__Wrapper-sc-1m27g3z-0.bbEeEd > div > div.sc-AxiKw.InformationSlider__ContentCol-sc-1m27g3z-3.coRDbe > div > div.ant-radio-group.ant-radio-group-outline.Radio__RadioButtonGroup-sc-sagves-2.bmXYmQ > label:nth-child(3) > span:nth-child(2) > img";
        string headlineCSS = "#root > div > div.TwoColumnFullPageLayout__RightPart-sc-17mxd22-2.cdgANH > div.components__RightContent-sc-16242qy-3.dYhwsL > div.InformationSlider__Wrapper-sc-1m27g3z-0.bbEeEd > div > div.sc-AxiKw.InformationSlider__ContentCol-sc-1m27g3z-3.coRDbe > div > h2";

        driver.Navigate().GoToUrl(url);

        IWebElement analyzeMarketIcon = driver.FindElement(By.CssSelector(anaylzeMarketIconCSS));
        analyzeMarketIcon.Click();
        Thread.Sleep(500);

        IWebElement headline = driver.FindElement(By.CssSelector(headlineCSS));
        Assert.That(headline.Text, Is.EqualTo("A new way to look at your clients"));
    }

    [OneTimeTearDown]
    public void close() 
    {
        driver.Quit();
    }
}