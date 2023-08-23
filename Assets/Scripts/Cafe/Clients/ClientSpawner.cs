using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Cafe.Clients
{
    public class ClientSpawner : MonoBehaviour
    {
        [SerializeField] private ClientMovement client;
        private IObjectResolver _objectResolver;

        [Inject]
        private void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                _objectResolver.Instantiate(client, Vector3.zero, Quaternion.identity);
            }
        }
    }
}