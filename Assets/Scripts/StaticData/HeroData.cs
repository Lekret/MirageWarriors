using Heroes;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Hero", fileName = "HeroData")]
    public class HeroData : ScriptableObject
    {
        public int Initiative = 10;
        public int ActionDiameter = 20;
        public int Enthusiasm = 7800;
        public int Search = 500;
        public int Speed = 100;
        public int Collection = 20;
        public int Damage = 100;
        public int Shield = 500;
        public int Health = 500;
        public int Cooldown = 4;
        public Character Character;
    }
}