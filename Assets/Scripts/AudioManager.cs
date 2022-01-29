using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public UnityEvent<string, float> onVolumeChanged = new();

    /*
    private float _introVolume;
    public float IntroVolume
    {
        get => _introVolume;
        set
        {
            _introVolume = value;
            onVolumeChanged.Invoke("introSound", _introVolume);
        }
    }
    
    private float _backgroundVolume;
    public float BackgroundVolume
    {
        get => _backgroundVolume;
        set
        {
            _backgroundVolume = value;
            onVolumeChanged.Invoke("backgroundSound", _backgroundVolume);
        }
    }
    
    private float _rainVolume;
    public float RainVolume
    {
        get => _rainVolume;
        set
        {
            _rainVolume = value;
            onVolumeChanged.Invoke("rainSound", _introVolume);
        }
    }
    */
    
    public float GetVolumeByTag(string tag)
    {
        var obj = GameObject.FindWithTag(tag);
        var component = obj.GetComponent<AudioSource>();

        return component != null ? component.volume : 0.0f;
    }

    public void ChangeVolume(string tag, float volume)
    {
        onVolumeChanged.Invoke(tag, volume);
    }
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }
}
