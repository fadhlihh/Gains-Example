using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public void Init(string name, int level, bool isSelected)
        {
            _nutrimonImage.sprite = Resources.Load<Sprite>($"Sprites/Monster/{name}");
            _levelText.text = level.ToString();
            _selectedFrame.gameObject.SetActive(isSelected);
        }
    }
}
