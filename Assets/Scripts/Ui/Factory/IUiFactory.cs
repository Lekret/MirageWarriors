namespace Ui.Factory
{
    public interface IUiFactory
    {
        void CreateUiRoot();
        HeroInfo CreateHeroInfo();
        SetupUi CreateSetup();
    }
}