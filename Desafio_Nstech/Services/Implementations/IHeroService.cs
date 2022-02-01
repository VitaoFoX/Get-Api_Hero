﻿using Desafio_Nstech.Data.ValueObjects;
using Desafio_Nstech.Model;

namespace Desafio_Nstech.Services.Implementations
{
    public interface IHeroService
    {
        IEnumerable<HeroVO> FindAll();
        List<Hero> FindByPowerStat(string powerstat);
    }
}
