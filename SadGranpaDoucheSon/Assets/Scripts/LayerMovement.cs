using UnityEngine;

namespace DefaultNamespace
{  
    public class LayerMovement : MonoBehaviour
    {
        public ChaserEngine engine;
        public float damp = 1;

        private void Awake()
        {
            engine = GameObject.FindObjectOfType<ChaserEngine>();
        }
        
        private void Update()
        {
            transform.position += Vector3.left * 5 * Time.deltaTime;
        }
    }
}