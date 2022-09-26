using System;
using UnityEngine;

namespace Hero
{
    public class ActionArea : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _collider;

        public event Action Entered;
        
        public void SetDiameter(int diameter)
        {
            _collider.radius = diameter / 2f;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Entered?.Invoke();
        }
    }
}