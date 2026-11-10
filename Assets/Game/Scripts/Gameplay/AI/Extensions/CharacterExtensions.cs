using UnityEngine;

namespace SampleGame
{
    public static class CharacterExtensions
    {
        public static bool IsAlive(this GameObject target) =>
            target && target.activeInHierarchy &&
            target.TryGetComponent(out HealthComponent health) && health.IsAlive;

        public static bool IsWithin(this GameObject character, Vector3 point, float distance)
        {
            Vector3 delta = point - character.transform.position;
            delta.y = 0;
            return delta.sqrMagnitude <= distance * distance;
        }

        public static void MoveTowards(this GameObject character, Vector3 destination, float deltaTime)
        {
            Vector3 direction = destination - character.transform.position;
            direction.y = 0;
            character.GetComponent<MoveComponent>().MoveStep(direction.normalized, deltaTime);
        }

        public static void RotateTo(this GameObject character, Vector3 point, float stoppingAngle, float deltaTime)
        {
            Vector3 direction = point - character.transform.position;
            direction.y = 0;
            direction.Normalize();

            if (Vector3.Angle(character.transform.forward, direction) > stoppingAngle)
                character.GetComponent<RotateTransformComponent>().RotateTowards(direction, deltaTime);
        }

        public static void AttackInRange(this GameObject character, GameObject target, float attackDistance)
        {
            if (character.IsWithin(target.transform.position, attackDistance))
                character.GetComponent<AttackComponent>().Attack(target);
        }

        public static void Fight(this GameObject character, GameObject enemy,
            float chaseDistance, float attackDistance, float stoppingAngle, float deltaTime)
        {
            Vector3 enemyPosition = enemy.transform.position;

            if (!character.IsWithin(enemyPosition, chaseDistance))
                character.MoveTowards(enemyPosition, deltaTime);
            else
                character.RotateTo(enemyPosition, stoppingAngle, deltaTime);

            character.AttackInRange(enemy, attackDistance);
        }
    }
}
