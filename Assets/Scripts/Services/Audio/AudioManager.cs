using UnityEngine;
using UnityEngine.UI;

namespace Services.Audio {
    public class AudioManager : MonoBehaviour {
        private const string VolumeSettingsPlayerPrefsKey = "volume_settings";
        
        [SerializeField] 
        private AudioSource _bgAudioSource;
        
        [SerializeField] 
        private AudioSource _soundEffectAudioSource;

        [SerializeField]
        private Slider _volumeSlider;
        

        private void Start() {

            if (PlayerPrefs.HasKey(VolumeSettingsPlayerPrefsKey)) {
                var volume = PlayerPrefs.GetFloat(VolumeSettingsPlayerPrefsKey);
                _bgAudioSource.volume = volume;
                _soundEffectAudioSource.volume = volume;
            }
            
            if (_volumeSlider != null) {
                _volumeSlider.onValueChanged.AddListener(ChangeVolume);
                _volumeSlider.value = _bgAudioSource.volume;
            }
        }

        private void ChangeVolume(float value) {
            PlayerPrefs.SetFloat(VolumeSettingsPlayerPrefsKey, value);
            PlayerPrefs.Save();
            
            _bgAudioSource.volume = value;
            _soundEffectAudioSource.volume = value;
        }

    }
}