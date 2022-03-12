using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WEditor.UI
{
    public class TextMessageHandler : MonoBehaviour
    {
        public static TextMessageHandler instance;
        [SerializeField] GameObject errorPanel;
        [SerializeField] TMPro.TextMeshProUGUI errorMessage;
        [SerializeField] float messageTime;
        [SerializeField] string errorsPath;
        private Dictionary<string, string> errors = new Dictionary<string, string>();
        private const string dg_ge = "dg_ge";
        private const string pp = "pp";
        private const string sp_pl = "sp_pl";
        private void Awake()
        {
            instance = this;
            TextReader();
        }
        public void DB_GE()
        {
            SetError(dg_ge);
        }
        public void PP()
        {
            SetError(pp);
        }
        public void SP_PL()
        {
            SetError(sp_pl);
        }
        private void SetError(string id)
        {
            errorPanel.SetActive(true);
            errorMessage.text = errors[id];
            Invoke(nameof(ClearMessage), messageTime);
        }
        private void ClearMessage()
        {
            errorPanel.SetActive(false);
            errorMessage.text = "";
        }
        private void TextReader()
        {
            string[] lines = System.IO.File.ReadAllLines(errorsPath);
            foreach (var line in lines)
            {
                (string key, string value) = GetErrorTextKeyAndValue(line);
                errors.Add(key, value);
            }
        }
        private Tuple<string, string> GetErrorTextKeyAndValue(string line)
        {
            string[] words = line.Split(':');
            return Tuple.Create(words[0], words[1]);
        }
    }
}