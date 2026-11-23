using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace MyApp.UiTests;

public class ProductsPageTests : PageTest
{
    [Test]
    public async Task AddToCart_OneProduct_ShowsBadgeWithOne()
    {
        // Arrange
        var loginPage = new LoginPage(Page);
        await loginPage.GotoAsync();
        await loginPage.LoginAsync("standard_user", "secret_sauce");

        var productsPage = new ProductsPage(Page);

        // Act
        await productsPage.AddToCartAsync("sauce-labs-backpack");

        // Assert
        await Expect(productsPage.CartBadge).ToHaveTextAsync("1");
    }
}