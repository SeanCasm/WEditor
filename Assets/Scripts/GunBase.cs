using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WEditor.Game
{
    public class GunBase<T> : MonoBehaviour
    {
        [SerializeField] protected float checkDistance;
        [SerializeField] protected LayerMask hitLayer;
        [SerializeField] protected T damage;
        [SerializeField] AudioClip shootClip;
        protected Transform shootPoint;
        private AudioSource audioSource;
        protected void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = shootClip;
            // checks if is a player gun
            if (hitLayer.value == 256)
                shootPoint = transform.GetChild(0);
        }
        public void PlayShootClip()
        {
            audioSource.Play();
        }
        public (bool, RaycastHit) ShootRay()
        {
            RaycastHit raycastHit = new RaycastHit();
            Ray ray = new Ray(shootPoint.position, transform.root.forward);

            bool hit = Physics.Raycast(ray, out raycastHit, checkDistance, hitLayer);
            Debug.DrawLine(shootPoint.position, transform.root.forward * checkDistance, Color.green, 1000);
            return (hit, raycastHit);
        }
    }
}
