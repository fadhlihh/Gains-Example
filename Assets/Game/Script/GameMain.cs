using UnityEngine;
using Gains.Utility;

namespace Gains.Boot
{
    public class GameMain : SingletonBehaviour<GameMain>
    {

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            DontDestroyOnLoad(this);
            GameObject globalContainer = new GameObject("[Container] Global");
            DontDestroyOnLoad(globalContainer);
        }
    }
}
