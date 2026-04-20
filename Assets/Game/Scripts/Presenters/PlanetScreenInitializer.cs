using Modules.Planets;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetScreenInitializer : IInitializable
    {
        private readonly IPlanet[] _planets;
        private readonly PlanetPresenter[] _planetPresenters;

        public PlanetScreenInitializer(IPlanet[] planets, PlanetPresenter[] planetPresenters)
        {
            _planets = planets;
            _planetPresenters = planetPresenters;
        }

        public void Initialize()
        {
            for (int i = 0; i < _planets.Length; i++)
                _planetPresenters[i].Show(_planets[i]);
        }
    }
}