using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ProgressionData;

namespace Gains.Module.NutrimonResult
{
    public class NutrimonResultPopUp : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _elementText;
        [SerializeField]
        private TextMeshProUGUI _levelText;
        [SerializeField]
        private Image _nutrimonImage;
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private List<Image> _monsterStars = new List<Image>();
        // [SerializeField]
        // private TextMeshProUGUI _descriptionText;

        public void Show()
        {
            CheckMonsterStar();
            ProgressData.Instance.AddCoin(100);
            _nutrimonImage.sprite = Resources.Load<Sprite>($"Sprites/Monster/{ProgressData.Instance.Progress.NewNutrimon.Name}");
            _nameText.text = ProgressData.Instance.Progress.NewNutrimon.Name;
            _elementText.text = ProgressData.Instance.Progress.NewNutrimon.Element;
            _levelText.text = ProgressData.Instance.Progress.NewNutrimon.Level.ToString();
            _closeButton.onClick.RemoveAllListeners();
            _closeButton.onClick.AddListener(Hide);
            GetComponent<Canvas>().enabled = true;
        }

        private void Awake()
        {
            if (ProgressData.Instance.Progress.NewNutrimon != null)
            {
                Show();
            }
        }

        private void CheckMonsterStar()
        {
            float monsterStars = ProgressData.Instance.Progress.NewNutrimon.Star;
            int index = 0;
            while (index < Mathf.FloorToInt(monsterStars))
            {
                _monsterStars[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star");
                index++;
            }
            if ((monsterStars % 1) != 0)
            {
                _monsterStars[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star_half");
            }
        }

        public void Hide()
        {
            GetComponent<Canvas>().enabled = false;
            ProgressData.Instance.ResetNewNutrimon();
        }
    }
}
