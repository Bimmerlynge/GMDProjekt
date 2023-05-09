using UnityEngine;
using Util;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5f;
    
        private Rigidbody _rb;
        private Vector3 _moveDirection;
        private Vector3 _orientation;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        void FixedUpdate()
        {
            Rotation();
            Move();
        }
    
        public void SetMoveDirection(Vector2 input)
        {
            _moveDirection = input.GetIsometricVector3();
            Orient();
        }
        private void Rotation()
        {
            var lookRotation = Quaternion.LookRotation(_orientation, Vector3.up);
            _rb.MoveRotation(lookRotation);
        }

        private void Move()
        {
            var moveDelta = _moveDirection * moveSpeed;
            _rb.velocity = moveDelta;
      
        }

        private void Orient()
        {
            if (_moveDirection == Vector3.zero)
                _orientation = transform.forward;
            else
                _orientation = _moveDirection;
        }
    }
}
