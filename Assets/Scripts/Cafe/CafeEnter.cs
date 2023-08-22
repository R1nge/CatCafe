using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cafe
{
    public class CafeEnter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) => SceneManager.LoadSceneAsync("GameCafe", LoadSceneMode.Single);
    }
}