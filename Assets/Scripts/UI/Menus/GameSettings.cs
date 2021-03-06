using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using WEditor.CameraUtils;
using WEditor.Game.Player;
using WEditor.Input;

namespace WEditor
{
    public class GameSettings : MonoBehaviour
    {
        [Range(0, 5)]
        [SerializeField] float defaultAimSensibility;
        [Range(0.0001f, 1)]
        [SerializeField] float defaultFxVolume, defaultMusicVolume;
        [SerializeField] Slider aimSlider, fxSlider, musicSlider;
        [SerializeField] AudioMixerGroup fxGroup, musicGroup;
        private void Start()
        {
            aimSlider.value = PlayerPrefs.HasKey("aim") ? PlayerPrefs.GetFloat("aim") : defaultAimSensibility;
            fxSlider.value = PlayerPrefs.HasKey("fx") ? PlayerPrefs.GetFloat("fx") : defaultFxVolume;
            musicSlider.value = PlayerPrefs.HasKey("music") ? PlayerPrefs.GetFloat("music") : defaultMusicVolume;
        }
        /// <summary>
        /// Set the mouse aim sensibility.
        /// </summary>
        /// <param name="aim">amount of sensibility</param>
        public void SetAimSensibility(float aim)
        {
            PlayerController.currentRotationSpeed = aim;
            PlayerPrefs.SetFloat("aim", aim);
        }
        /// <summary>
        /// Set the editor camera speed.
        /// </summary>
        /// <param name="speed">amount of speed</param>/
        public void SetCameraSpeed(float speed)
        {
            EditorCamera.currentSpeed = speed;
            PlayerPrefs.SetFloat("camSpeed", speed);
        }
        public void SetSoundEffectsVolume(float amount)
        {
            float correctValue = Mathf.Log10(amount) * 20;
            PlayerPrefs.SetFloat("fx", amount);
            fxGroup.audioMixer.SetFloat("fx", correctValue);
        }
        public void SetMusicVolume(float amount)
        {
            float correctValue = Mathf.Log10(amount) * 20;
            PlayerPrefs.SetFloat("music", amount);
            musicGroup.audioMixer.SetFloat("music", correctValue);
        }
    }
}
