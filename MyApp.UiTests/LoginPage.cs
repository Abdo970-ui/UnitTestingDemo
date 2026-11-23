using Microsoft.Playwright;

namespace MyApp.UiTests;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    private ILocator UsernameInput => _page.GetByPlaceholder("Username");
    private ILocator PasswordInput => _page.GetByPlaceholder("Password");
    private ILocator LoginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });

    public ILocator ErrorMessage => _page.Locator("[data-test='error']");

    public async Task GotoAsync()
    {
        await _page.GotoAsync("https://www.saucedemo.com");
    }

    public async Task LoginAsync(string username, string password)
    {
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(password);
        await LoginButton.ClickAsync();
    }
}
