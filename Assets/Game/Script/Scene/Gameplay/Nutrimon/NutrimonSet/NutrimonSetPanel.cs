using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gains.Module.NutrimonSet
{
    public class NutrimonSetPanel : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
