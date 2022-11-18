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

            _context.Skills.AddRange(s1, s2, s3, s4, s5, s6);

            var os1 = new OptionSkill
            {
                SkillId = 1,
                Priority = PriorityLevel.Low
            };
            var os2 = new OptionSkill
            {
                SkillId = 2,
                Priority = PriorityLevel.Medium
            };
            var os3 = new OptionSkill
            {
                SkillId = 3,
                Priority = PriorityLevel.Low
            };
            var os4 = new OptionSkill
            {
                SkillId = 4,
                Priority = PriorityLevel.Medium
            };
            var os5 = new OptionSkill
            {
                SkillId = 5,
                Priority = PriorityLevel.Low
            };
            var os6 = new OptionSkill
            {
                SkillId = 6,
                Priority = PriorityLevel.Medium
            };

            var o1 = new Option { Description = "option 1: 📃", OptionSkills = new List<OptionSkill>(){ os1, os2 } };
            var o2 = new Option { Description = "option 2: ✅", OptionSkills = new List<OptionSkill>() { os3, os4 } };
            var o3 = new Option { Description = "option 3: 🤯", OptionSkills = new List<OptionSkill>() { os5, os6 } };
            IList<Option> options = new List<Option>();
            options.Add(o1);
            options.Add(o2);
            options.Add(o3);

            _context.Options.AddRange(o1, o2, o3);

            /*var os1 = new OptionSkill
            {
                SkillId = 1,
                OptionId = 1,
                Priority = PriorityLevel.Low
            };
            var os2 = new OptionSkill
            {
                SkillId = 2,
                OptionId = 1,
                Priority = PriorityLevel.Medium
            };
            var os3 = new OptionSkill
            {
                SkillId = 3,
                OptionId = 2,
                Priority = PriorityLevel.Low
            };
            var os4 = new OptionSkill
            {
                SkillId = 4,
                OptionId = 2,
                Priority = PriorityLevel.Medium
            };
            var os5 = new OptionSkill
            {
                SkillId = 5,
                OptionId = 3,
                Priority = PriorityLevel.Low
            };
            var os6 = new OptionSkill
            {
                SkillId = 6,
                OptionId = 3,
                Priority = PriorityLevel.Medium
            };

            _context.OptionSkills.AddRange(os1, os2, os3);*/

            _context.Questions.Add(new Question
            {
                Description = "Question",
                Options = options
                /*{
                    new Option
                    {
                        Description = "option 1: 📃"*//*,
                        OptionSkills =
                        {
                            new OptionSkill
                            {
                                SkillId = 1,
                                OptionId = 1,
                                Priority = PriorityLevel.Low
                            },
                            new OptionSkill
                            {
                                SkillId = 2,
                                OptionId = 1,
                                Priority = PriorityLevel.Medium
                            },
                        }*//*
                    },
                    new Option
                    {
                        Description = "option 2: ✅"*//*,
                        OptionSkills =
                        {
                            new OptionSkill
                            {
                                SkillId = 3,
                                OptionId = 2,
                                Priority = PriorityLevel.Low
                            },
                            new OptionSkill
                            {
                                SkillId = 4,
                                OptionId = 2,
                                Priority = PriorityLevel.Medium
                            },
                        }*//*
                    },
                    new Option
                    {
                        Description = "option 3: 🤯"*//*,
                        OptionSkills =
                        {
                            new OptionSkill
                            {
                                SkillId = 5,
                                OptionId = 3,
                                Priority = PriorityLevel.Low
                            },
                            new OptionSkill
                            {
                                SkillId = 6,
                                OptionId = 3,
                                Priority = PriorityLevel.Medium
                            },
                        }*//*
                    }
                }*/
            });

            await _context.SaveChangesAsync();
        }
    }
}
