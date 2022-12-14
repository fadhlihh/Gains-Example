using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Gains.Module.WIP;

namespace Gains.Module.NutrimonCollection
{
    public class NutrimonCollectionItem : MonoBehaviour
    {
        [SerializeField]
        private Image _nutrimonImage;
        [SerializeField]
        private Button _detailButton;
        [SerializeField]
        private TextMeshProUGUI _levelText;
        [SerializeField]
        private Transform _selectedFrame;
        
        private UnityAction _showWorkInProgressPopUp;

        public void Init(string name, int level, bool isSelected, UnityAction showWorkInProgressPopUp)
        {
            _showWorkInProgressPopUp = showWorkInProgressPopUp;
            _nutrimonImage.sprite = Resources.Load<Sprite>($"Sprites/Nutrimon/{name}");
            _levelText.text = level.ToString();
            _selectedFrame.gameObject.SetActive(isSelected);
            _detailButton.onClick.RemoveAllListeners();
            _detailButton.onClick.AddListener(OnDetail);
        }

        private void OnDetail(){
            _showWorkInProgressPopUp.Invoke();
        }
    }
}
