using Interactable;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class InteractController : MonoBehaviour
    {
        [SerializeField] private Button interact;
        [SerializeField] private float rayDistance;
        [SerializeField] private LayerMask ignoreLayer;

        private void Awake()
        {
            interact.onClick.AddListener(Interact);
        }

        private void Interact()
        {
            var hit = Physics2D.Raycast(transform.position, -Vector2.up, rayDistance, ~ignoreLayer);

            if (hit.collider != null)
            {
                print(hit.collider.name);

                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
            else
            {
                Debug.LogError("No collider found", this);
            }
        }

        private void OnDestroy()
        {
            interact.onClick.RemoveAllListeners();
        }
    }
}