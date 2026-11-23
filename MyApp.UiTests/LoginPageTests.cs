using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.UiTests
{
    public class LoginPageTests : PageTest
    {
        [Test]
        public async Task LoginPage_HasCorrectTitle()
        {
            await Page.GotoAsync("https://www.saucedemo.com");

            await Expect(Page).ToHaveTitleAsync("Swag Labs");
        }
        [Test]
        public async Task Login_ValidCredentials_GoesToProductsPage()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync();

            await loginPage.LoginAsync("standard_user", "secret_sauce");

            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
            await Expect(Page.Locator("[data-test='title']")).ToHaveTextAsync("Products");
        }

        [Test]
        public async Task Login_WrongPassword_ShowsErrorMessage()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GotoAsync();

            await loginPage.LoginAsync("standard_user", "wrong_password");

            await Expect(loginPage.ErrorMessage)
                .ToContainTextAsync("Username and password do not match");
        }
    }
}
