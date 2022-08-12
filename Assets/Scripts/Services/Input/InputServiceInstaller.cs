using Services.Input.EventsProvider;
using Zenject;

namespace Services.Input
{
    public class InputServiceInstaller : Installer<InputServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<TouchInputEventsProvider>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<InputService>()
                .AsSingle()
                .NonLazy();
        }
    }
}