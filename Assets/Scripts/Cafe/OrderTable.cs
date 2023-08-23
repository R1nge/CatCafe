using Interactable;
using UnityEngine;
using VContainer;

namespace Cafe
{
    public class OrderTable : MonoBehaviour, IInteractable
    {
        [SerializeField] private Order[] possibleOrders;
        private OrderManager _orderManager;

        [Inject]
        private void Construct(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public void Interact()
        {
            if (_orderManager.HasOrder())
            {
                Debug.LogError("Already has an order");
                return;
            }

            var order = possibleOrders[Random.Range(0, possibleOrders.Length)];
            print($"Has taken an order {order.DishName}");
            _orderManager.SetOrder(order);
        }
    }
}