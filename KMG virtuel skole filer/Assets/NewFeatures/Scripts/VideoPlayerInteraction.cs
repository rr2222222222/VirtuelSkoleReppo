using UnityEngine;

public class VideoPlayerInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEngine.Video.VideoPlayer video;
    [SerializeField] private bool restartOnPress = false;
    public void Interact()
    {
        if (!video.isPlaying)
            video.Play();
        else if (restartOnPress)
            video.Stop();
        else
            video.Pause();
    }
}
