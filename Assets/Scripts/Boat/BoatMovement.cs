using UnityEngine;

namespace Boat
{
    public class BoatMovement
    {
        private readonly Transform _boat;
        public BoatMovement(Transform boat)
        {
            _boat = boat;
        }
        
        public void Move(Vector2 direction)
        {
            _boat.transform.position += (Vector3) direction * Time.deltaTime;
        }
    }
}