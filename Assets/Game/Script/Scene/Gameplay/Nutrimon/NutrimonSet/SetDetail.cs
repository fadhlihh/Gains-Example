using UnityEngine;
using UnityEngine.UI;

namespace Gains.Module.NutrimonSet
{
    public class SetDetail : MonoBehaviour
    {
        [SerializeField]
        private Button _closeButton;

        public void Show()
        {
            _closeButton.onClick.RemoveAllListeners();
            _closeButton.onClick.AddListener(OnClose);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnClose()
        {
            Hide();
        }
    }
}
