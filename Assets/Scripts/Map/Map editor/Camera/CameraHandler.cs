using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WEditor.Events;

namespace WEditor.CameraUtils
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] EditorCamera editorCamera;
        [SerializeField] GameObject player;
        private void OnEnable()
        {
            EditorEvent.instance.onPreviewModeEnter += OnPreviewModeEnter;
            EditorEvent.instance.onPreviewModeExit += OnPreviewModeExit;
        }
        private void OnDisable()
        {
            EditorEvent.instance.onPreviewModeEnter -= OnPreviewModeEnter;
            EditorEvent.instance.onPreviewModeExit -= OnPreviewModeExit;
        }
        private void OnPreviewModeEnter()
        {
            editorCamera.gameObject.SetActive(false);
            player.SetActive(true);
        }
        private void OnPreviewModeExit()
        {
            editorCamera.gameObject.SetActive(true);
            player.SetActive(false);
        }


    }
}