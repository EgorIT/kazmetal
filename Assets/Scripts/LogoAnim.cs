using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LogoAnim : MonoBehaviour {

    public RawImage image;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;

    private AudioSource audioSource;

    public Button buttonStart, buttonStop;
    private Coroutine coroutine;
    private bool isPlay = false;
    
    void Start () {
        Application.runInBackground = true;
        buttonStart.onClick.AddListener(PlayVideo);
        buttonStop.onClick.AddListener(StopVideo);
        StartCoroutine(playVideo());
    }

    private void PlayVideo()
    {
        isPlay = true;
    }

    private void StopVideo()
    {
        isPlay = false;
    }

    private IEnumerator playVideo()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = true;
        videoPlayer.waitForFirstFrame = false;
        audioSource.playOnAwake = false;
        audioSource.Pause();
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);
        videoPlayer.clip = videoToPlay;
        
        while (true)
        {
            if (isPlay && !videoPlayer.isPlaying)
            {
                videoPlayer.Prepare();
                while (!videoPlayer.isPrepared)
                {
                    yield return null;
                }
                image.texture = videoPlayer.texture;
                videoPlayer.Play();
                audioSource.Play();
            }
            
            if (!isPlay && videoPlayer.isPlaying)
            {
                videoPlayer.Stop();
                audioSource.Stop();
            }
            yield return null;
        }
    }
    
    void Update () {
		
	}
}
