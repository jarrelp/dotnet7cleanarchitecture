using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
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
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
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
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new ApplicationUser { UserName = "admin@localhost", Email = "admin@localhost" };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "Admin1!");
            await _userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
        }

        // Default data
        // Seed, if necessary
        if (!_context.Questions.Any())
        {
            var s1 = new Skill { Name = "Skill 1" };
            var s2 = new Skill { Name = "Skill 2" };
            var s3 = new Skill { Name = "Skill 3" };
            var s4 = new Skill { Name = "Skill 4" };
            var s5 = new Skill { Name = "Skill 5" };
            var s6 = new Skill { Name = "Skill 6" };
            var s7 = new Skill { Name = "Skill 7" };
            var s8 = new Skill { Name = "Skill 8" };

            _context.Skills.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);

            _context.Questions.Add(new Question
            {
                Description = "Question",
                Options =
                {
                    new Option
                    {
                        Description = "option 1: 📃",
                        OptionSkills =
                        {
                            new OptionSkill
                            {
                                Skill = s1,
                                Priority = PriorityLevel.Low
                            },
                            new OptionSkill
                            {
                                Skill = s2,
                                Priority = PriorityLevel.Medium
                            },
                        }
                    },
                    new Option
                    {
                        Description = "option 2: ✅",
                        OptionSkills =
                        {
                            new OptionSkill
                            {
                                Skill = s1,
                                Priority = PriorityLevel.Low
                            },
                            new OptionSkill
                            {
                                Skill = s2,
                                Priority = PriorityLevel.Medium
                            },
                        }
                    },
                    new Option
                    {
                        Description = "option 3: 🤯",
                        OptionSkills =
                        {
                            new OptionSkill
                            {
                                Skill = s1,
                                Priority = PriorityLevel.Low
                            },
                            new OptionSkill
                            {
                                Skill = s2,
                                Priority = PriorityLevel.Medium
                            },
                        }
                    }
                }
            });

            await _context.SaveChangesAsync();
        }
    }
}
