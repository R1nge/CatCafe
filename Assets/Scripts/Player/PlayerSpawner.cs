using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform spawnPoint;
        private IObjectResolver _objectResolver;

        [Inject]
        private void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private void Start()
        {
            _objectResolver.Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}