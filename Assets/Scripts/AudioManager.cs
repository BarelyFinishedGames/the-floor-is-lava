using System;
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
    
    public static float GetVolumeByTag(string tag)
    {
        var obj = GameObject.FindWithTag(tag);

        if (obj is null) return 0.0f;
        
        var component = obj.GetComponent<AudioSource>();

        return component != null ? component.volume : 0.0f;
    }
    
    public static AudioSource GetAudioSourceByTag(string tag)
    {
        var obj = GameObject.FindWithTag(tag);

        if (obj is null) return null;
        
        return obj.GetComponent<AudioSource>();
    }

    public void ChangeVolume(string tag, float volume)
    {
        onVolumeChanged.Invoke(tag, volume);
    }

    public static void StopSound(string tag)
    {
        var obj = GameObject.FindWithTag(tag);

        if (obj is null) return;

        var component = obj.GetComponent<AudioSource>();
        
        component.Stop();
    }
    
    public static void StartSound(string tag)
    {
        var obj = GameObject.FindWithTag(tag);

        if (obj is null) return;

        var component = obj.GetComponent<AudioSource>();
        
        component.Play();
    }

    private void OnGameOver()
    {
        StopSound("backgroundSound");
        StartSound("gameOverSound");
    }
    
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GameManager.Instance.OnGameOver.AddListener(OnGameOver);
    }
}
