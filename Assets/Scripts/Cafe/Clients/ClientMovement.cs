using System;
using UnityEngine;
using VContainer;

namespace Cafe.Clients
{
    public class ClientMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private OrderManager _orderManager;
        private ClientQueue _clientQueue;
        private int _positionIndex;

        [Inject]
        private void Construct(OrderManager orderManager, ClientQueue clientQueue)
        {
            _orderManager = orderManager;
            _clientQueue = clientQueue;
        }

        private void Start()
        {
            _orderManager.OnOrderCompleted += MoveToNextPositionInQueue;
            _positionIndex = _clientQueue.TakePlace();
        }

        private void Update()
        {
            transform.position =
                Vector2.MoveTowards(
                    transform.position,
                    _clientQueue.GetPosition(_positionIndex),
                    speed * Time.deltaTime);
        }

        private void MoveToNextPositionInQueue()
        {
            if (_positionIndex == 0)
            {
                Debug.LogError("Already the first in the queue", this);
                Debug.LogError("Leaving the cafe");
                _clientQueue.LeavePlace();
                _orderManager.OnOrderCompleted -= MoveToNextPositionInQueue;
                return;
            }

            _positionIndex--;
            print(_clientQueue.GetPosition(_positionIndex));
        }

        private void OnDestroy()
        {
            _orderManager.OnOrderCompleted -= MoveToNextPositionInQueue;
        }
    }
}