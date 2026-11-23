using Microsoft.Playwright;

namespace MyApp.UiTests;

public class ProductsPage
{
    private readonly IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public ILocator CartBadge => _page.Locator("[data-test='shopping-cart-badge']");

    public async Task AddToCartAsync(string productSlug)
    {
        await _page.Locator($"[data-test='add-to-cart-{productSlug}']").ClickAsync();
    }
}