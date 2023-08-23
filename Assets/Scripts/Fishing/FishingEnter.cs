using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fishing
{
    public class FishingEnter : MonoBehaviour, IInteractable
    {
        public void Interact() => SceneManager.LoadSceneAsync("GameFishing", LoadSceneMode.Single);
    }
}