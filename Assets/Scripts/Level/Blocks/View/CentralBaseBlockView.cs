using System;
using UnityEngine;

namespace Level.Blocks
{
    public class CentralBaseBlockView : MonoBehaviour
    {
        public event Action OnPlayersSquareTouch; 

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<BaseBlockView>())
            {
                OnPlayersSquareTouch?.Invoke();
            }
        }
    }
}