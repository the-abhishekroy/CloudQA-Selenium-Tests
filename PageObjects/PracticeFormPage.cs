using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CloudQA.SeleniumTests.PageObjects;

public class PracticeFormPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private const string BaseUrl = "https://app.cloudqa.io/home/AutomationPracticeForm";

    public PracticeFormPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void NavigateTo()
    {
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
    public void NavigateTo()
    {
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }

    private IWebElement FindFirstNameField()
    {
        var strategies = new Func<IWebElement>[]
        {
            () => _driver.FindElement(By.XPath("//label[contains(text(), 'First Name')]/following-sibling::input | //label[contains(text(), 'First Name')]/..//input")),
            () => _driver.FindElement(By.XPath("//input[contains(@placeholder, 'First') or contains(@placeholder, 'first')]")),
            () => _driver.FindElement(By.XPath("//input[contains(@name, 'first') or contains(@name, 'First') or @name='fname']")),
            () => _driver.FindElement(By.XPath("(//form//input[@type='text'])[1]")),
            () => _driver.FindElement(By.XPath("//*[contains(text(), 'First Name')]/ancestor::*[1]//input | //*[contains(text(), 'First Name')]/following::input[1]"))
        };ummary>
    /// Finds the Email field using multiple fallback strategies.
    /// Tries: type attribute, label text, placeholder, name attribute, and pattern matching.
    /// </summary>
    private IWebElement FindEmailField()
    {
        var strategies = new Func<IWebElement>[]
        {
            // Strategy 1: Find by input type email
            () => _driver.FindElement(By.XPath("//input[@type='email']")),
        return FindElementWithFallback(strategies, "First Name field");
    }

    private IWebElement FindEmailField()
    {
        var strategies = new Func<IWebElement>[]
        {
            () => _driver.FindElement(By.XPath("//input[@type='email']")),
            () => _driver.FindElement(By.XPath("//label[contains(text(), 'Email')]/following-sibling::input | //label[contains(text(), 'Email')]/..//input")),
            () => _driver.FindElement(By.XPath("//input[contains(@placeholder, 'email') or contains(@placeholder, 'Email') or contains(@placeholder, '@')]")),
            () => _driver.FindElement(By.XPath("//input[contains(@name, 'email') or contains(@name, 'Email') or @name='emailId']")),
            () => _driver.FindElement(By.XPath("//*[contains(text(), 'Email')]/ancestor::*[1]//input | //*[contains(text(), 'Email')]/following::input[1]"))
        };  // Strategy 1: Find by associated label
            () => _driver.FindElement(By.XPath("//label[contains(text(), 'Mobile')]/following-sibling::input | //label[contains(text(), 'Mobile')]/..//input")),
        return FindElementWithFallback(strategies, "Email field");
    }

    private IWebElement FindMobileField()
    {
        var strategies = new Func<IWebElement>[]
        {
            () => _driver.FindElement(By.XPath("//label[contains(text(), 'Mobile')]/following-sibling::input | //label[contains(text(), 'Mobile')]/..//input")),
            () => _driver.FindElement(By.XPath("//input[contains(@placeholder, 'Mobile') or contains(@placeholder, 'mobile') or contains(@placeholder, 'Phone') or contains(@placeholder, 'phone')]")),
            () => _driver.FindElement(By.XPath("//input[contains(@name, 'mobile') or contains(@name, 'Mobile') or contains(@name, 'phone') or @name='mobileNumber']")),
            () => _driver.FindElement(By.XPath("//input[@type='tel' or (@type='text' and (contains(@placeholder, 'number') or contains(@name, 'number')))]")),
            () => _driver.FindElement(By.XPath("//*[contains(text(), 'Mobile')]/ancestor::*[1]//input | //*[contains(text(), 'Mobile')]/following::input[1]"))
        };  try
            {
                var element = _wait.Until(d =>
                {
                    try
                    {
                        var el = strategy();
                        return el.Displayed ? el : null;
                    }
                    catch
                    {
                        return null;
                    }
                });

        return FindElementWithFallback(strategies, "Mobile field");
    }

    private IWebElement FindElementWithFallback(Func<IWebElement>[] strategies, string fieldName)
                continue;
            }
        }

        throw new NoSuchElementException($"Could not locate {fieldName} using any fallback strategy");
    }

    public void EnterFirstName(string firstName)
    {
                if (element != null)
                {
                    return element;
                }
            }
            catch (WebDriverTimeoutException)
            {
                continue;
            }nt.SendKeys(email);
    }

    public void EnterMobile(string mobile)
    {
        var element = FindMobileField();
        element.Clear();
        element.SendKeys(mobile);
    }

    public string GetFirstNameValue()
    {
        var element = FindFirstNameField();
        return element.GetAttribute("value") ?? string.Empty;
    }

    public string GetEmailValue()
    {
        var element = FindEmailField();
        return element.GetAttribute("value") ?? string.Empty;
    }

    public string GetMobileValue()
    {
        var element = FindMobileField();
        return element.GetAttribute("value") ?? string.Empty;
    }
}
