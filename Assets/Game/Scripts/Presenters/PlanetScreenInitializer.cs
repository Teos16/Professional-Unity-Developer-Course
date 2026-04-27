using System.Collections.Generic;
using Modules.Planets;
using Zenject;

namespace Game.Presenters
{
    public sealed class PlanetScreenInitializer : IInitializable
    {
        private readonly Dictionary<PlanetPresenter, IPlanet> _planetPresenterMap = new();

        public PlanetScreenInitializer(IPlanet[] planets, PlanetPresenter[] planetPresenters)
        {
            Dictionary<string, IPlanet> planetByName = new Dictionary<string, IPlanet>(planets.Length);
            for (int i = 0; i < planets.Length; i++)
                planetByName[planets[i].Name] = planets[i];

            for (int j = 0; j < planetPresenters.Length; j++)
                if (planetByName.TryGetValue(planetPresenters[j].Name, out IPlanet planet))
                    _planetPresenterMap.Add(planetPresenters[j], planet);
        }

        public void Initialize()
        {
            foreach ((PlanetPresenter presenter, IPlanet planet) in _planetPresenterMap)
                presenter.Show(planet);
        }
    }
}