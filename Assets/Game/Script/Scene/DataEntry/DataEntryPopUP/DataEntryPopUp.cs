using UnityEngine;
using UnityEngine.SceneManagement;
using Gains.Utility;

namespace Gains.Module.DataEntry
{
    public class DataEntryPopUp : MonoBehaviour
    {
        [SerializeField]
        private GameObject _simpleDataEntryPopUp;

        private void Awake()
        {
            CheckScanCount();
        }

        public void CheckScanCount(){
            int playerScanCount = PlayerPrefs.GetInt("PlayerScanCount");
            if(playerScanCount == 1 || (playerScanCount % 2 == 0)){
                _simpleDataEntryPopUp.SetActive(true);
            }else{
                SceneManager.LoadScene(GameScene.Gameplay,LoadSceneMode.Single);
            }
        }        
    }
}
