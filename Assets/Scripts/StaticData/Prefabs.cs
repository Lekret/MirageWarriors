using Heroes;
using Ui;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Prefabs", fileName = "Prefabs")]
    public class Prefabs : ScriptableObject
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private GameObject _uiRoot;
        [SerializeField] private SetupUi _setupUi;
        [SerializeField] private HeroInfo _heroInfo;
        [SerializeField] private ProgressUi _progressUi;

        public Hero Hero => _hero;
        public GameObject UiRoot => _uiRoot;
        public SetupUi SetupUi => _setupUi;
        public HeroInfo HeroInfo => _heroInfo;
        public ProgressUi ProgressUi => _progressUi;
    }
}