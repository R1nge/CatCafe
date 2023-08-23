using Cafe;
using Cafe.Clients;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LifeTimes
{
    public class GameCafeLifeTime : LifetimeScope
    {
        [SerializeField] protected ClientQueue clientQueue;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<OrderManager>(Lifetime.Scoped).AsSelf();
            builder.RegisterComponent(clientQueue).AsSelf();
        }
    }
}