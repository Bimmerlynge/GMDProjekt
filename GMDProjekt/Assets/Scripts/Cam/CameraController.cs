using UnityEngine;

namespace Cam
{
    public class CameraController : MonoBehaviour
    {
        private Transform target;
        private Vector3 _offset;

        private void Awake()
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        void Start()
        {
            _offset = transform.position - target.transform.position;
            transform.LookAt(target);
        }
    
        void LateUpdate()
        {
            transform.position = target.transform.position + _offset;
        }
    }
}
