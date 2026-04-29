using System;
using ModernPortfolio.Models;

namespace ModernPortfolio.Repositories;

public class SkillReposityory : GenericRepository<Skill>, ISkillRepository
{
    public SkillReposityory(IConfiguration configuration) : base(configuration)
    {

    }
}