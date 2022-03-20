using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WEditor.Events;
using WEditor.Game.Guns;

namespace WEditor.Game.Player.Guns
{
    public class Gun : GunBase
    {
        [SerializeField] protected int maxAmmo;
        protected int currentAmmo;
        public bool hasAmmo { get => currentAmmo > 0; }
        private bool isInitialized;
        public bool isShooting { get; private set; }
        protected bool isHolding;
        protected Animator animator;
        public Action onGunStoppedFire;
        public Action onEmptyAmmo;
        private new void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            GameEvent.instance.AmmoChanged(currentAmmo);
        }
        private void OnDisable()
        {
            StopCoroutine(nameof(QueueShooting));
            onGunStoppedFire = null;
            onEmptyAmmo = null;
        }
        public void FireCanceled()
        {
            isHolding = false;
            StopCoroutine(nameof(QueueShooting));
        }
        public void FirePerformed()
        {
            isHolding = true;
            StartCoroutine(nameof(QueueShooting));
        }
        public void Init(bool enable)
        {
            if (!isInitialized)
            {
                currentAmmo = maxAmmo;
                isInitialized = true;
            }

            gameObject.SetActive(enable);
        }

        private void LateUpdate()
        {
            animator.SetBool("isShooting", isShooting);
        }
        private IEnumerator QueueShooting()
        {
            while (isHolding)
            {
                Fire();
                yield return new WaitForSeconds(.5f);
            }
        }
        public void Fire()
        {
            if (currentAmmo == 0) return;

            currentAmmo--;
            GameEvent.instance.AmmoChanged(currentAmmo);
            ShootRay();
            isShooting = true;
            animator.SetTrigger("Shoot");
        }
        public void AnimationEvent_StopShooting()
        {
            if (!isHolding) isShooting = false;

            if (onGunStoppedFire != null)
            {
                onGunStoppedFire();
            }
        }
        private new void ShootRay()
        {
            Tuple<bool, RaycastHit> values = base.ShootRay();

            if (values.Item1)
            {
                HealthBase<float> enemyHealth = values.Item2.collider.GetComponent<HealthBase<float>>();
                enemyHealth.Take(damage);
            }
        }

        public void Add(int amount)
        {
            currentAmmo += amount;
            currentAmmo = currentAmmo >= maxAmmo ? maxAmmo : currentAmmo;
        }
    }
}