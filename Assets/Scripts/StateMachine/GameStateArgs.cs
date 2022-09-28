using System.Collections.Generic;

namespace StateMachine
{
    public readonly struct GameStateArgs
    {
        public readonly List<HeroSpawnData> SpawnData;

        public GameStateArgs(List<HeroSpawnData> spawnData)
        {
            SpawnData = spawnData;
        }
    }
}