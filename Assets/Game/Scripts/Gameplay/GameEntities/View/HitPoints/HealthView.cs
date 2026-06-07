using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField]
        private Image _progress;

        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private float _showTime = 2;

        public void SetText(string text)
        {
            _text.text = text;
        }

        public void SetProgress(float progress)
        {
            _progress.fillAmount = progress;
        }

        public void SetColor(Color color)
        {
            _progress.color = color;
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
            this.StartCoroutine(this.HideWithDelay());
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        private IEnumerator HideWithDelay()
        {
            yield return new WaitForSeconds(_showTime);
            this.gameObject.SetActive(false);
        }
    }
}