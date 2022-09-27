using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class SetupUi : MonoBehaviour
    {
        [SerializeField] private Button _start;

        public event Action StartPressed;
        
        private void Awake()
        {
            _start.onClick.AddListener(BeginBattle);
        }

        private void OnDestroy()
        {
            _start.onClick.RemoveListener(BeginBattle);
        }
        
        private void BeginBattle()
        {
            StartPressed?.Invoke();
            Destroy(gameObject);
        }
    }
}