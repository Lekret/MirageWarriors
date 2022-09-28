using StaticData;

namespace Heroes
{
    public class HeroState
    {
        public int Shield;
        public int Health;
        public int Cooldown;

        public HeroState(HeroData data)
        {
            Shield = data.Shield;
            Health = data.Health;
            Cooldown = 0;
        }
    }
}