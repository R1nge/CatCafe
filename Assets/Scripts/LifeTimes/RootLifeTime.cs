using Music;
using VContainer;
using VContainer.Unity;

namespace LifeTimes
{
    public class RootLifeTime : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<MusicPlayer>(Lifetime.Singleton).AsSelf();
        }
    }
}