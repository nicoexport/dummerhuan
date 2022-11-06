using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

namespace Dummerhuan 
{
    public class OWPlayerMovement : MonoBehaviour 
    {
        public UnityEvent onEncounter;
        public Transform target;
        public float speed=2f;
        public bool eventInvoke;

        void Start() 
        {
            eventInvoke = false;
        }

        void FixedUpdate() 
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);

            if (transform.position == target.position && eventInvoke == false) 
            { 
                Debug.Log("arrived");
                onEncounter.Invoke();
                eventInvoke = true;
            }
        }
        


    }    
      
          
      
}
