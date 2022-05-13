using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WEditor.Utils;

namespace WEditor.Game.Scriptables
{
    [CreateAssetMenu(fileName = "Scenario", menuName = "ScriptableObjects/Scenario")]
    public class ScenarioScriptable : ScriptableObject
    {
        [SerializeField] Sprite[] spritesCollection;
        public Sprite[] SpritesCollection { get => spritesCollection; }
        public Sprite GetSprite(string spriteName)
        {
            int index = spriteName.GetIndexFromAssetName();
            return spritesCollection[index];
        }
        public bool HasSprite(string spriteName)
        {
            int index = spriteName.GetIndexFromAssetName();
            return spritesCollection[index] != null;
        }
    }
}
