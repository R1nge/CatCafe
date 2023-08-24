using Interactable;
using UnityEngine;
using VContainer;

namespace Cafe.Devices
{
    public class CutTable : MonoBehaviour, IInteractable
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

            //TODO: create a cut mini game,
            //Player can cut the fish however he'd like
            _orderManager.Order.CutFish();
            Debug.Log("Cut the fish");
        }
    }
}