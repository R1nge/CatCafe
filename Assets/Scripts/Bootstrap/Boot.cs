using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootstrap
{
    public class Boot : MonoBehaviour
    {
        private void Start() => SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }
}