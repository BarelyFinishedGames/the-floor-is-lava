using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        public List<string> volumesToChange = new();
        
        private Slider slider;
        private void Start()
        {
            slider = gameObject.GetComponent<Slider>();
            
            if (volumesToChange.Count > 0)
            {
                var volume = AudioManager.GetVolumeByTag(volumesToChange[0]);
                slider.value = volume;
            }
        }

        public void ChangeVolume()
        {
            foreach (var toChange in volumesToChange)
            {
                AudioManager.Instance.ChangeVolume(toChange, slider.value);
            }
        }
    }
}
