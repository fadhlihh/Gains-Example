using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gains
{
    public class ObjectRotater : MonoBehaviour
    {
        [SerializeField] GameObject nutrimon;
       private Touch touch;
       private Vector2 touchPosition;
       private Quaternion rotationY;
       private float rotateSpeedModifier = 0.3f;

        // Start is called before the first frame update
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        void OnMouseDrag()
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("jalan");
                touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Moved)
                {
                    rotationY = Quaternion.Euler(0f,- touch.deltaPosition.x * rotateSpeedModifier, 0f);
                     nutrimon.transform.rotation = rotationY * nutrimon.transform.rotation;
                }
            }
        }
    }
}
