using HomeApi.Domain.Constants;
using HomeApi.Domain.Entities.ApplicationUsers;
using HomeApi.Domain.Entities.Currencies;
using HomeApi.Domain.Entities.Currencies.ValueObjects;
using HomeApi.Domain.Entities.EntryEntityKinds;
using HomeApi.Domain.Enums;
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

    private async Task TrySeedAsync()
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

        if (!await _context.EntryEntityKinds.AnyAsync())
        {
            await _context.EntryEntityKinds.AddRangeAsync(ExpensesEntityKinds());
            await _context.EntryEntityKinds.AddRangeAsync(IncomesEntityKinds());
            await _context.EntryEntityKinds.AddRangeAsync(EventsEntityKinds());

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }

    private List<EntryEntityKind> ExpensesEntityKinds()
    {
        return
        [
            EntryEntityKind.Create(
                Name.Create("Food & Dining"),
                EntryKind.Expense,
                Emoji.Create("🍽️"),
                Color.Create("#e07b39"),
                EntryEntityKindId.Create(1)),

            EntryEntityKind.Create(
                Name.Create("Transport"),
                EntryKind.Expense,
                Emoji.Create("🚗"),
                Color.Create("#3b82f6"),
                EntryEntityKindId.Create(2)),

            EntryEntityKind.Create(
                Name.Create("Shopping"),
                EntryKind.Expense,
                Emoji.Create("🛍️"),
                Color.Create("#8b5cf6"),
                EntryEntityKindId.Create(3)),

            EntryEntityKind.Create(
                Name.Create("Health"),
                EntryKind.Expense,
                Emoji.Create("💊"),
                Color.Create("#10b981"),
                EntryEntityKindId.Create(4)),

            EntryEntityKind.Create(
                Name.Create("Entertainment"),
                EntryKind.Expense,
                Emoji.Create("🎬"),
                Color.Create("#e7b394"),
                EntryEntityKindId.Create(5)),

            EntryEntityKind.Create(
                Name.Create("Utilities"),
                EntryKind.Expense,
                Emoji.Create("💡"),
                Color.Create("#6b7280"),
                EntryEntityKindId.Create(6))
            // EntryEntityKind.Create(
            //     Name.Create("Eating Out"),
            //     EntryKind.Expense,
            //     EntryEntityKindId.Create(7)),
            // EntryEntityKind.Create(
            //     Name.Create("Sport"),
            //     EntryKind.Expense,
            //     EntryEntityKindId.Create(8)),

        ];
    }
    
    private List<EntryEntityKind> IncomesEntityKinds()
    {
        return
        [
            EntryEntityKind.Create(
                Name.Create("Salary"),
                EntryKind.Income,
                Emoji.Create("💼"),
                Color.Create("#2d6a4f"),
                EntryEntityKindId.Create(401)),

            EntryEntityKind.Create(
                Name.Create("Freelance"),
                EntryKind.Income,
                Emoji.Create("💻"),
                Color.Create("#0891b2"),
                EntryEntityKindId.Create(402)),

            EntryEntityKind.Create(
                Name.Create("Investment"),
                EntryKind.Income,
                Emoji.Create("📈"),
                Color.Create("#7c3aed"),
                EntryEntityKindId.Create(403)),

            EntryEntityKind.Create(
                Name.Create("Rental"),
                EntryKind.Income,
                Emoji.Create("🏠"),
                Color.Create("#be185d"),
                EntryEntityKindId.Create(404)),

            EntryEntityKind.Create(
                Name.Create("Gift / Bonus"),
                EntryKind.Income,
                Emoji.Create("🎁"),
                Color.Create("#c47a1a"),
                EntryEntityKindId.Create(405))

        ];
    }
    
    private List<EntryEntityKind> EventsEntityKinds()
    {
        return
        [
            EntryEntityKind.Create(
                Name.Create("Meeting"),
                EntryKind.Event,
                Emoji.Create("🤝"),
                Color.Create("#374151"),
                EntryEntityKindId.Create(801)),

            EntryEntityKind.Create(
                Name.Create("Medical"),
                EntryKind.Event,
                Emoji.Create("🩺"),
                Color.Create("#dc2626"),
                EntryEntityKindId.Create(802)),

            EntryEntityKind.Create(
                Name.Create("Personal"),
                EntryKind.Event,
                Emoji.Create("🧘"),
                Color.Create("#7c3aed"),
                EntryEntityKindId.Create(803)),

            EntryEntityKind.Create(
                Name.Create("Travel"),
                EntryKind.Event,
                Emoji.Create("✈️"),
                Color.Create("#0891b2"),
                EntryEntityKindId.Create(804)),

            EntryEntityKind.Create(
                Name.Create("Social"),
                EntryKind.Event,
                Emoji.Create("🎉"),
                Color.Create("#f59e0b"),
                EntryEntityKindId.Create(805))

        ];
    }
}
