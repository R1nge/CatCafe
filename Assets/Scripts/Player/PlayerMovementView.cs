using UnityEngine;

namespace Player
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private InputButton leftButton, rightButton;
        [SerializeField] private LayerMask obstacleLayer;
        private PlayerMovement _playerMovement;

        private void Awake() => _playerMovement = new PlayerMovement(transform, speed);

        private void Update()
        {
            if (leftButton.IsPressed && CanMoveLeft())
            {
                MoveLeft();
            }
            else if (rightButton.IsPressed && CanMoveRight())
            {
                MoveRight();
            }
        }

        private bool CanMoveRight() => Raycast(Vector2.right);

        private bool CanMoveLeft() => Raycast(Vector2.left);

        private bool Raycast(Vector2 direction)
        {
            return !Physics2D.Raycast(transform.position, direction, .4f, obstacleLayer);
        }

        private void MoveLeft()
        {
            _playerMovement.Move(Vector2.left);
        }

        private void MoveRight()
        {
            _playerMovement.Move(Vector2.right);
        }
    }
}