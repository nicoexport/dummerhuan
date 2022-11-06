using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

namespace Dummerhuan 
{
    public class OWEnemyMovement : MonoBehaviour 
    {
        public UnityEvent onEncounter;
        //public float moveSpeed = 0f;
        public Transform target;
        public float speed=2f;


        void FixedUpdate() 
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        


    }    
      

}
