using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
            
        AudioManager.Instance.onVolumeChanged.AddListener(OnVolumeChanged);

        audioSource.volume = AudioManager.Instance.GetVolumeByTag(tag);
    }

    private void OnVolumeChanged(string toChange, float volume)
    {
        if (!gameObject.CompareTag(toChange)) return;

        audioSource.volume = volume;
    }
}
