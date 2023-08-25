using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Music
{
    public class MusicPlayer
    {
        public event Action OnSongsLoaded;
        private readonly string _audioPath = $"{Application.persistentDataPath}/Music/";
        private readonly List<string> _songs = new();
        private int _lastSongIndex;

        public void LoadSongs()
        {
            if (!Directory.Exists(_audioPath))
            {
                Directory.CreateDirectory(_audioPath);
            }

            var files = Directory.EnumerateFiles(_audioPath, "*.mp3", SearchOption.AllDirectories);
            var length = 0;

            foreach (var audio in files)
            {
                length++;
                _songs.Add(audio);
                Debug.Log($"file://{audio}");
            }

            Debug.Log($"LOADED SONGS {length}");

            OnSongsLoaded?.Invoke();
        }

        private string GetFirstSong()
        {
            return $"file://{_songs[0]}";
        }

        private string GetNextSong()
        {
            _lastSongIndex = (_lastSongIndex + 1) % _songs.Count;
            Debug.Log(_songs[_lastSongIndex]);
            return $"file://{_songs[_lastSongIndex]}";
        }

        private string GetPreviousSong()
        {
            _lastSongIndex = Mathf.Abs(_lastSongIndex - 1) % _songs.Count;
            return $"file://{_songs[_lastSongIndex]}";
        }

        public IEnumerator PlayFirstSong(AudioSource audioSource)
        {
            using (var uwr = UnityWebRequestMultimedia.GetAudioClip(GetFirstSong(), AudioType.MPEG))
            {
                ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = true;
                yield return uwr.SendWebRequest();
                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(uwr.error);
                    yield break;
                }

                AudioClip clip = DownloadHandlerAudioClip.GetContent(uwr);
                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        public bool SongEnded(AudioSource audioSource) => audioSource.isPlaying == false;

        public IEnumerator PlayNextSong(AudioSource audioSource)
        {
            using (var uwr = UnityWebRequestMultimedia.GetAudioClip(GetNextSong(), AudioType.MPEG))
            {
                ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = true;
                yield return uwr.SendWebRequest();
                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(uwr.error);
                    yield break;
                }

                AudioClip clip = DownloadHandlerAudioClip.GetContent(uwr);
                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        public IEnumerator PlayPreviousSong(AudioSource audioSource)
        {
            using (var uwr = UnityWebRequestMultimedia.GetAudioClip(GetPreviousSong(), AudioType.MPEG))
            {
                ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = true;
                yield return uwr.SendWebRequest();
                if (uwr.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(uwr.error);
                    yield break;
                }

                AudioClip clip = DownloadHandlerAudioClip.GetContent(uwr);
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}