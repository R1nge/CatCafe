using Interactable;
using UnityEngine;
using VContainer;

namespace Cafe.Devices
{
    public class CutTable : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject game;
        [SerializeField] private Transform fishSpawnPoint;
        [SerializeField] private Fish fish;
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
            game.SetActive(true);
            Instantiate(fish, fishSpawnPoint.position, Quaternion.identity);
            Debug.Log("Cut the fish");
            //_orderManager.Order.CutFish();
        }
    }
}