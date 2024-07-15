using Default;
using Sample.Implementations;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //Container.Bind<SpeedUpgrade>().AsSingle().NonLazy();
        Container.Bind<PlayerStats>().AsSingle().NonLazy();
        Container.Bind<MoneyStorage>().AsSingle().NonLazy();
    }
}