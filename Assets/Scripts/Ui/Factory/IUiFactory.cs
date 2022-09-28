using System.Collections.Generic;
using Heroes;

namespace Ui.Factory
{
    public interface IUiFactory
    {
        void CreateUiRoot();
        ProgressUi CreateProgress();
        HeroInfo CreateHeroInfo(IEnumerable<HeroPreview> previews);
        SetupUi CreateSetup();
    }
}