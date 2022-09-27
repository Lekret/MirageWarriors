using Heroes;

namespace Services.HeroRaycaster
{
    public interface IHeroRaycaster
    {
        bool TryRaycast(out Hero hero);
    }
}