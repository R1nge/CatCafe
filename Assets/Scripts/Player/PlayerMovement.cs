using UnityEngine;

namespace Player
{
    public class PlayerMovement
    {
        private readonly Transform _player;
        private readonly float _speed;

        public PlayerMovement(Transform player, float speed)
        {
            _player = player;
            _speed = speed;
        }

        public void MoveTo(float positionX)
        {
            _player.transform.position = Vector2.Lerp(
                _player.position,
                new Vector2(positionX, _player.position.y),
                _speed * Time.deltaTime
            );
        }
    }
}