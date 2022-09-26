using Heroes;
using StaticData;

namespace Services.HeroFactory
{
    public interface IHeroFactory
    {
        Hero CreateHero(HeroData data);
    }
}