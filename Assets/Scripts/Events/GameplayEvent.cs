using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using WEditor.Game.Player;

namespace WEditor.Events
{
    public class GameplayEvent : MonoBehaviour
    {
        public static GameplayEvent instance;
        public event Action<int> onKeyPickedUp;
        public event Action<string> onAmmoChanged;
        public event Action<InfoStatsUIText> onLevelCompeted;
        public event Action onTeasuresChanged, onKillsChanged;
        public event Action<int> onLivesChanged, onScoreChanged, onHealthChanged, onArmourhChanged;
        public event Action<List<KeyType>> onInteracted;
        private void OnEnable() => instance = this;
        public void LevelCompeted(InfoStatsUIText levelStats)
        {
            if (onLevelCompeted != null)
                onLevelCompeted(levelStats);
        }
        public void Interacted(List<KeyType> keyTrigger)
        {
            if (onInteracted != null)
                onInteracted(keyTrigger);
        }
        public void TeasuresChanged()
        {
            if (onTeasuresChanged != null)
                onTeasuresChanged();
        }
        public void KillsChanged()
        {
            if (onKillsChanged != null)
                onKillsChanged();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">0: golden, 1: platinum</param>
        public void KeyPickedUp(int key)
        {
            if (onKeyPickedUp != null)
                onKeyPickedUp(key);
        }
        public void HealthChanged(int amount)
        {
            if (onHealthChanged != null)
            {
                onHealthChanged(amount);
            }
        }
        public void ArmourhChanged(int amount)
        {
            if (onArmourhChanged != null)
            {
                onArmourhChanged(amount);
            }
        }
        public void LivesChanged(int amount)
        {
            if (onLivesChanged != null)
            {
                onLivesChanged(amount);
            }
        }
        public void AmmoChanged(string amount)
        {
            if (onAmmoChanged != null)
            {
                onAmmoChanged(amount);
            }
        }
        public void ScoreChanged(int amount)
        {
            if (onScoreChanged != null)
            {
                onScoreChanged(amount);
            }
        }
    }
}


