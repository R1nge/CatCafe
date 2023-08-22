using System;
using UnityEngine;
using UnityEngine.UI;

namespace Boat
{
    public class BoatMovementView : MonoBehaviour
    {
        [SerializeField] private InputButton leftButton, rightButton;
        private BoatMovement _boatMovement;

        private void Awake()
        {
            _boatMovement = new BoatMovement(transform);
        }

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
            _boatMovement.Move(Vector2.left);
        }

        private void MoveRight()
        {
            _boatMovement.Move(Vector2.right);
        }
    }
}