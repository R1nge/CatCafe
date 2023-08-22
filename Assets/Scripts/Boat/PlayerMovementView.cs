using UnityEngine;

namespace Boat
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private InputButton leftButton, rightButton;
        private PlayerMovement _playerMovement;

        private void Awake() => _playerMovement = new PlayerMovement(transform, speed);

        private void Update()
        {
            if (leftButton.IsPressed)
            {
                MoveLeft();
            }
            else if (rightButton.IsPressed)
            {
                MoveRight();
            }
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