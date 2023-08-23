using Interactable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cafe
{
    public class CafeEnter : MonoBehaviour, IInteractable
    {
        public void Interact() => SceneManager.LoadSceneAsync("GameCafe", LoadSceneMode.Single);
    }
}