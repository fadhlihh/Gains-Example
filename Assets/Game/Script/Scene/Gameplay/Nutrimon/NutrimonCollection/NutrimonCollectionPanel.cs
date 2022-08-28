using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gains.Module.NutrimonsData;
using Gains.Module.ProgressionData;

namespace Gains.Module.NutrimonCollection
{
    public class NutrimonCollectionPanel : MonoBehaviour
    {
        [SerializeField]
        private Transform _collectionListContainer;
        [SerializeField]
        private NutrimonCollectionItem _collectionItemPrefab;

        private List<NutrimonCollectionItem> _collectionList = new List<NutrimonCollectionItem>();
        public void Show()
        {
            GenerateCollectionList();
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            Show();
        }

        private void GenerateCollectionList()
        {
            ClearList();
            int counter = 0;
            foreach (Nutrimon item in ProgressData.Instance.Progress.Nutrimons)
            {
                NutrimonCollectionItem collectionItem = Instantiate<NutrimonCollectionItem>(_collectionItemPrefab, _collectionListContainer);
                collectionItem.Init(item.Name, item.Level, counter == 0);
                _collectionList.Add(collectionItem);
                counter++;
            }
        }

        private void ClearList()
        {
            if (ProgressData.Instance.Progress.Nutrimons.Count > 0)
            {
                foreach (NutrimonCollectionItem item in _collectionList)
                {
                    Destroy(item.gameObject);
                }
                _collectionList.Clear();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}