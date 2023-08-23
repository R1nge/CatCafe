using Cafe;
using VContainer;
using VContainer.Unity;

namespace LifeTimes
{
    public class GameCafeLifeTime : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<OrderManager>(Lifetime.Scoped).AsSelf();
        }
    }
}