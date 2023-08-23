using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cafe
{
    public class CafeExit : MonoBehaviour, IInteractable
    {
        public void Interact() => SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }
}