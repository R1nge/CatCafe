using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cafe
{
    public class CafeExit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) => SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }
}