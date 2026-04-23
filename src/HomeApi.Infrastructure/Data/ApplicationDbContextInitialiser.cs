using HomeApi.Domain.Constants;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.Currencies.ValueObjects;
using HomeApi.Domain.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomeApi.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(
        ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager
    )
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole(Roles.Administrator);

        if (await _roleManager.Roles.AllAsync(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser
        {
            UserName = "administrator@localhost",
            Email = "administrator@localhost",
        };

        if (await _userManager.Users.AllAsync(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        if (!await _context.Currencies.AnyAsync())
        {
            var currencies = new List<Currency>()
            {
                Currency.Create(
                    Code.Create("PLN"),
                    Symbol.Create("zł"),
                    Name.Create("Polish złoty"),
                    CurrencyId.Create(1)),
                Currency.Create(
                    Code.Create("USB"),
                    Symbol.Create("$"),
                    Name.Create("US Dollar"),
                    CurrencyId.Create(2)),
                Currency.Create(
                    Code.Create("EUR"),
                    Symbol.Create("€"),
                    Name.Create("Euro"),
                    CurrencyId.Create(3)),
                Currency.Create(
                    Code.Create("GBP"),
                    Symbol.Create("£"),
                    Name.Create("British Pound"),
                    CurrencyId.Create(4)),
                Currency.Create(
                    Code.Create("CHF"),
                    Symbol.Create("Fr"),
                    Name.Create("Swiss Franc"),
                    CurrencyId.Create(5)),
                Currency.Create(
                    Code.Create("CZK"),
                    Symbol.Create("Kč"),
                    Name.Create("Czech Koruna"),
                    CurrencyId.Create(6)),
                Currency.Create(
                    Code.Create("SEK"),
                    Symbol.Create("kr"),
                    Name.Create("Swedish Krone"),
                    CurrencyId.Create(7)),
                Currency.Create(
                    Code.Create("NOK"),
                    Symbol.Create("kr"),
                    Name.Create("Norwegian Krone"),
                    CurrencyId.Create(8)),
                Currency.Create(
                    Code.Create("JPY"),
                    Symbol.Create("¥"),
                    Name.Create("Japanese Yen"),
                    CurrencyId.Create(9)),
                Currency.Create(
                    Code.Create("CAD"),
                    Symbol.Create("C$"),
                    Name.Create("Canadian Dollar"),
                    CurrencyId.Create(10)),
            };
            
            await _context.Currencies.AddRangeAsync(currencies);
                
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
