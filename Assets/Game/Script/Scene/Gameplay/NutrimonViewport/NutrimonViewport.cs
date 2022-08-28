using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Module.ProgressionData;

namespace Gains.Module.Viewport
{
    public class NutrimonViewport : MonoBehaviour
    {
        [SerializeField]
        private GameObject _viewportContainer;

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
            _nutrimon = Instantiate(nutrimonPrefabs, _viewportContainer.transform);
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
    }
}
