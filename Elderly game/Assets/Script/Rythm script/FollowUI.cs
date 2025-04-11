using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    
        public Camera camera;
        public GameObject virtualMouse;

  

        // Update is called once per frame
        void Update()
        {
            
            Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z=0;
            Debug.Log(mouseWorldPosition);
            virtualMouse.transform.position = mouseWorldPosition;
        }
    }

