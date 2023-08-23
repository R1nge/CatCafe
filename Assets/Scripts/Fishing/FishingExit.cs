using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fishing
{
    public class FishingExit : MonoBehaviour, IInteractable
    {
        public void Interact() => SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }
}