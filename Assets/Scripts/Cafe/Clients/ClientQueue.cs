using UnityEngine;

namespace Cafe.Clients
{
    public class ClientQueue : MonoBehaviour
    {
        [SerializeField] private Transform[] positions;
        private int _lastIndex;

        public Vector3 GetPosition(int index) => positions[index].position;

        public int TakePlace() => _lastIndex++;

        public void LeavePlace() => _lastIndex--;
    }
}