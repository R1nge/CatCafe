using Music;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace Bootstrap
{
    public class Boot : MonoBehaviour
    {
        private MusicPlayer _musicPlayer;

        [Inject]
        private void Construct(MusicPlayer musicPlayer)
        {
            _musicPlayer = musicPlayer;
        }

        private void Start()
        {
            _musicPlayer.LoadSongs();
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
        }
    }
}