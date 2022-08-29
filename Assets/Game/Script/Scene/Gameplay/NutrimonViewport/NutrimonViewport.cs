using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Gains.Module.ProgressionData;
using Gains.Module.WIP;

namespace Gains.Module.Viewport
{
    public class NutrimonViewport : MonoBehaviour
    {
        [SerializeField]
        private GameObject _viewportContainer;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _levelText;
        [SerializeField]
        private Button _customizeButton;
        [SerializeField]
        private List<Image> _nutrimonStars = new List<Image>();
        [SerializeField]
        private WorkInProgress _workInProgressPopUp;

        private GameObject _nutrimon;
        private Touch _touch;
        private Vector2 _touchPosition;
        private Quaternion _rotationY;
        private float _rotateSpeedModifier = 0.3f;

        private void Awake()
        {
            SetNutrimonOnViewport();
        }

        private void SetNutrimonOnViewport()
        {
            GameObject nutrimonPrefabs = Resources.Load<GameObject>($"Prefabs/Nutrimon/{ProgressData.Instance.Progress.SelectedNutrimon.Name}");
            _nameText.text = ProgressData.Instance.Progress.SelectedNutrimon.Name;
            _levelText.text = ProgressData.Instance.Progress.SelectedNutrimon.Level.ToString();
            CheckNutrimonStar();
            _nutrimon = Instantiate(nutrimonPrefabs, _viewportContainer.transform);
            _customizeButton.onClick.RemoveAllListeners();
            _customizeButton.onClick.AddListener(OnCustomize);
        }

        private void CheckNutrimonStar(){
            float nutrimonStars = ProgressData.Instance.Progress.NewNutrimon.Star;
            int index = 0;
            while (index < Mathf.FloorToInt(nutrimonStars))
            {
                _nutrimonStars[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star");
                index++;
            }
            if ((nutrimonStars % 1) != 0)
            {
                _nutrimonStars[index].sprite = Resources.Load<Sprite>(@"Sprites/Stars/stage_character_star_half");
            }
        }

        private void OnMouseDrag()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);

                if (_touch.phase == TouchPhase.Moved)
                {
                    _rotationY = Quaternion.Euler(0f, -_touch.deltaPosition.x * _rotateSpeedModifier, 0f);
                    _viewportContainer.transform.rotation = _rotationY * _viewportContainer.transform.rotation;
                }
            }
        }

        private void OnCustomize(){
            _workInProgressPopUp.Show();
        }
    }
}
