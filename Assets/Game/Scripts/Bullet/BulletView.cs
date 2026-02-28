using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Game.Bullets
{
    public sealed class BulletView : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<TeamType, GameObject> _skinsByTeams;
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private Bullet _bullet;

        private TeamType _currentTeam;

        private void Awake() => _bullet.OnTeamChanged += OnConfigChangedHandler;

        private void OnEnable()
        {
            _bullet.OnHit += OnHit;
            SetupSkins(_currentTeam);
        }

        private void OnDisable() => _bullet.OnHit -= OnHit;

        private void OnDestroy()
        {
            _bullet.OnHit -= OnHit;
            _bullet.OnTeamChanged -= OnConfigChangedHandler;
        }

        private void OnConfigChangedHandler(TeamType team)
        {
            _currentTeam = team;
            SetupSkins(team);
        }

        private void SetupSkins(TeamType team)
        {
            foreach (KeyValuePair<TeamType, GameObject> skin in _skinsByTeams)
                skin.Value.SetActive(skin.Key == team);
        }

        private void OnHit() => Instantiate(_explosionPrefab, transform.position, _explosionPrefab.transform.rotation);
    }
}