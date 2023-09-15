using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovementView : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private LayerMask obstacleLayer;
        private PlayerMovement _playerMovement;
        private float _positionX;

        private void Awake() => _playerMovement = new PlayerMovement(transform, speed);

        private void Start() => _positionX = transform.position.x;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _positionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            }

            _playerMovement.MoveTo(_positionX);
        }

        private bool Raycast(Vector2 direction)
        {
            return !Physics2D.Raycast(transform.position, direction, .4f, obstacleLayer);
        }
    }
}