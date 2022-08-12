using Services.Input;
using Zenject;

namespace Services
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstaller.Install(Container);
        }
    }
}