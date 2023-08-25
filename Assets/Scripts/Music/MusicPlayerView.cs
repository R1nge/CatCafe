using UnityEngine;
using VContainer;

namespace Music
{
    public class MusicPlayerView : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        private MusicPlayer _musicPlayer;

        [Inject]
        private void Construct(MusicPlayer musicPlayer)
        {
            _musicPlayer = musicPlayer;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _musicPlayer.OnSongsLoaded += () => { StartCoroutine(_musicPlayer.PlayFirstSong(audioSource)); };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(_musicPlayer.PlayPreviousSong(audioSource));
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(_musicPlayer.PlayNextSong(audioSource));
            }
        }
    }
}