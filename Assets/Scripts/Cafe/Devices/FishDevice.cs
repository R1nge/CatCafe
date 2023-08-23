using Interactable;
using UnityEngine;
using VContainer;

namespace Cafe.Devices
{
    public class FishDevice : MonoBehaviour, IInteractable
    {
        private OrderManager _orderManager;

        [Inject]
        private void Construct(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public void Interact()
        {
            if (!_orderManager.HasOrder())
            {
                Debug.LogError("Don't have any orders yet", this);
                return;
            }

            if (_orderManager.Order.FishCut)
            {
                Debug.LogError("Already cut the fish", this);
                return;
            }

            _orderManager.Order.CutFish();
            Debug.Log("Cut the fish");
        }
    }
}