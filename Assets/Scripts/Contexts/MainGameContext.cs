using Commands;
using Mediators.MainGame;
using Mediators.Managers;
using Mediators.UI;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;
using Views.MainGame;
using Views.Managers;
using Views.UI;

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
            injectionBinder.Bind<GameOverSignal>().ToSingleton();

            // Init commands
            commandBinder.Bind<OnBuyTurretItemSignal>().To<OnBuyTurretItemCommand>();
            commandBinder.Bind<OnHitPlayerSignal>().To<OnHitPlayerCommand>();
            commandBinder.Bind<OnHitEnemySignal>().To<OnHitEnemyCommand>();

            // Init services
            injectionBinder.Bind<WayPointsService>().ToSingleton();
            injectionBinder.Bind<PlayerStartsService>().ToSingleton();
            injectionBinder.Bind<WaveService>().ToSingleton();
            injectionBinder.Bind<BuildManagerService>().ToSingleton();

            // Init mediators
            mediationBinder.Bind<EnemyView>().To<EnemyMediator>();
            mediationBinder.Bind<BuildManagerView>().To<BuildManagerMediator>();
            mediationBinder.Bind<WaveSpawnerView>().To<WaveSpawnerMediator>();
            mediationBinder.Bind<NodeView>().To<NodeMediator>();
            mediationBinder.Bind<BulletView>().To<BulletMediator>();
            mediationBinder.Bind<TurretView>().To<TurretMediator>();
            mediationBinder.Bind<GameOverView>().To<GameOverMediator>();
        }
    }
}