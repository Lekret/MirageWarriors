using Heroes;

namespace Services.HeroRaycaster
{
    public interface IHeroRaycaster
    {
        bool TryGet(out Hero hero);
    }
}