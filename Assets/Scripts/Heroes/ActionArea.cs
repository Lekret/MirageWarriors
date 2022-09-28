using System.Collections.Generic;
using UnityEngine;

namespace Heroes
{
    public class ActionArea : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _collider;
        
        private readonly HashSet<Hero> _nearestHeroes = new HashSet<Hero>();
        public IEnumerable<Hero> NearestHeroes => _nearestHeroes;

        public void SetDiameter(int diameter)
        {
            _collider.radius = diameter / 2f;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero))
            {
                _nearestHeroes.Add(hero);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Hero hero))
            {
                _nearestHeroes.Remove(hero);
            }
        }
    }
}