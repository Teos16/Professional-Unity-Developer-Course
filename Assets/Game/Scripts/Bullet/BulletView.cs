using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Game.BulletRelated
{
    public sealed class BulletView : MonoBehaviour
    {
        [SerializeField] private SerializedDictionary<TeamType, GameObject> _skinsByTeams;
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private Bullet _bullet;

        private void Start() => _bullet.OnConfigChanged += SetupSkins;

        private void OnEnable() => _bullet.OnHit += OnHit;

        private void OnDisable() => _bullet.OnHit -= OnHit;

        private void OnDestroy()
        {
            _bullet.OnHit -= OnHit;
            _bullet.OnConfigChanged -= SetupSkins;
        }

        private void SetupSkins(TeamType team)
        {
            foreach (KeyValuePair<TeamType, GameObject> skin in _skinsByTeams) 
                skin.Value.SetActive(skin.Key == team);
        }

        private void OnHit() => Instantiate(_explosionPrefab, transform.position, _explosionPrefab.transform.rotation);
    }
}