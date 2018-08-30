using Mediators.MainGame;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;
using Views.MainGame;

namespace Contexts
{
    public class MainGameContext : MVCSContext
    {
        public MainGameContext(MonoBehaviour view) : base(view)
        {
            _instance = this;
        }

        public MainGameContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
            _instance = this;
        }

        private static MainGameContext _instance;

        public static T Get<T>()
        {
            return _instance.injectionBinder.GetInstance<T>();
        }

        /// <inheritdoc />
        /// <summary>
        /// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        /// </summary>
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        /// <summary>
        /// Override Start so that we can fire the StartSignal 
        /// </summary>
        /// <returns></returns>
        public override IContext Start()
        {
            base.Start();
//            var startSignal = injectionBinder.GetInstance<StartGameSignal>();
//            startSignal.Dispatch();
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// Override Bindings map
        /// </summary>
        protected override void mapBindings()
        {
            // init Signals
            injectionBinder.Bind<OnBuildTurretSignal>().ToSingleton();
            injectionBinder.Bind<OnInitTurretSignal>().ToSingleton();

            // Init commands

            // Init services
            injectionBinder.Bind<WayPointsService>().ToSingleton();
            injectionBinder.Bind<WaveService>().ToSingleton();

            // Init mediators
            mediationBinder.Bind<EnemyView>().To<EnemyMediator>();
            mediationBinder.Bind<BuildManagerView>().To<BuildManagerMediator>();
            mediationBinder.Bind<WaveSpawnerView>().To<WaveSpawnerMediator>();
            mediationBinder.Bind<NodeView>().To<NodeMediator>();
            mediationBinder.Bind<BulletView>().To<BulletMediator>();
            mediationBinder.Bind<TurretView>().To<TurretMediator>();
        }
    }
}