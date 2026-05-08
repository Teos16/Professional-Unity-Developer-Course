using SampleGame.Components;
using UnityEngine;

namespace SampleGame
{
    public sealed class ArmorComponent : MonoBehaviour
    {
        public int CurrentArmor => _armor;
        public int MaxArmor => _maxArmor;

        [SerializeField] private int _armor = 50;
        [SerializeField] private int _maxArmor = 50;
        [Range(0f, 1f)] [SerializeField] private float _damageAbsorption = 0.5f;

        public int AbsorbDamage(int incomingDamage)
        {
            if (_armor <= 0 || _damageAbsorption <= 0f)
                return incomingDamage;

            int damageToArmor = Mathf.RoundToInt(incomingDamage * _damageAbsorption);

            int absorbed = Mathf.Min(_armor, damageToArmor);

            _armor -= absorbed;

            int damageToHealth = incomingDamage - absorbed;
            return damageToHealth;
        }

        public void RestoreArmor(int amount)
        {
            _armor = Mathf.Clamp(_armor + amount, 0, _maxArmor);
        }
    }
}