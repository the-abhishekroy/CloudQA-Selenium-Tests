using CloudQA.SeleniumTests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CloudQA.SeleniumTests.Tests;

[TestFixture]
public class PracticeFormTests
{
    private IWebDriver? _driver;
    private PracticeFormPage? _practiceFormPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");
        options.AddArgument("--disable-popup-blocking");
        
        _driver = new ChromeDriver(options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
        _practiceFormPage = new PracticeFormPage(_driver);
        _practiceFormPage.NavigateTo();
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _driver?.Dispose();
    }

    [Test]
    [Category("FormInput")]
    public void Test_FirstNameField_ShouldAcceptValidInput()
    {
        const string testFirstName = "John";

        _practiceFormPage!.EnterFirstName(testFirstName);
        var actualValue = _practiceFormPage.GetFirstNameValue();

        Assert.That(actualValue, Is.EqualTo(testFirstName), 
            "First Name field should contain the entered value");
    }

    [Test]
    [Category("FormInput")]
    public void Test_EmailField_ShouldAcceptValidEmail()
    {
        const string testEmail = "john.doe@example.com";

        _practiceFormPage!.EnterEmail(testEmail);
        var actualValue = _practiceFormPage.GetEmailValue();

        Assert.That(actualValue, Is.EqualTo(testEmail), 
            "Email field should contain the entered email address");
    }

    [Test]
    [Category("FormInput")]
    public void Test_MobileField_ShouldAcceptValidPhoneNumber()
    {
        const string testMobile = "9876543210";

        _practiceFormPage!.EnterMobile(testMobile);
        var actualValue = _practiceFormPage.GetMobileValue();

        Assert.That(actualValue, Is.EqualTo(testMobile), 
            "Mobile field should contain the entered phone number");
    }

    [Test]
    [Category("Integration")]
    public void Test_AllThreeFields_ShouldWorkTogether()
    {
        const string firstName = "Jane";
        const string email = "jane.smith@cloudqa.io";
        const string mobile = "1234567890";

        _practiceFormPage!.EnterFirstName(firstName);
        _practiceFormPage.EnterEmail(email);
        _practiceFormPage.EnterMobile(mobile);

        Assert.Multiple(() =>
        {
            Assert.That(_practiceFormPage.GetFirstNameValue(), Is.EqualTo(firstName), 
                "First Name should be populated correctly");
            Assert.That(_practiceFormPage.GetEmailValue(), Is.EqualTo(email), 
                "Email should be populated correctly");
            Assert.That(_practiceFormPage.GetMobileValue(), Is.EqualTo(mobile), 
                "Mobile should be populated correctly");
        });
    }
