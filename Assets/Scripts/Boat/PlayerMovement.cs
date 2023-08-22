using UnityEngine;

namespace Boat
{
    public class PlayerMovement
    {
        private readonly Transform _boat;
        private readonly float _speed;

        public PlayerMovement(Transform boat, float speed)
        {
            _boat = boat;
            _speed = speed;
        }

        public void Move(Vector2 direction)
        {
            _boat.transform.position += (Vector3)direction * (Time.deltaTime * _speed);
        }
    }
}