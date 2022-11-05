using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan
{
    public class MarkerMinigame : MonoBehaviour
    {
        public Animator marker;
        public Transform markerPos;

        [Range(0f, 1f)]
        public float goodPartValue;

        [Range(0f, 1f)]
        public float perfectPartValue;

        public Transform goodPart;
        public Transform perfectPart;

        private bool isStopped;

        float goodPartEnd;
        float perfectPartEnd;
        float checkX;

        // Start is called before the first frame update
        void Start()
        {
            goodPartEnd = goodPart.localScale.x / 2;
            perfectPartEnd = perfectPart.localScale.x / 2;
        }

        // Update is called once per frame
        void Update()
        {
            AdjustBars();

            checkX = markerPos.localScale.x;

            var keyboard = Keyboard.current;
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                Evaluate();
            }
        }

        void Evaluate()
        {
            isStopped = !isStopped;

            if (!isStopped) 
            {
                marker.StopPlayback();
                CheckMarkerPos();
            }
            else 
            {
                marker.StartPlayback();
            }
        }

        void AdjustBars() 
        {
            var gScale = goodPart.localScale;
            gScale.x = goodPartValue;

            goodPart.localScale = gScale;

            var pScale = perfectPart.localScale;
            pScale.x = perfectPartValue;

            perfectPart.localScale = pScale;
        }

        void CheckMarkerPos() 
        {

            if (checkX >= -perfectPartEnd && checkX <= perfectPartEnd)
            {
                Debug.Log("PERFECT!");
                return;
            } 
            else if (checkX >= -goodPartEnd && checkX <= goodPartEnd)
            {
                Debug.Log("GOOD!");
                return;
            }
            else 
            {
                Debug.Log("BAD!");
                return;
            }
        }
    }
}
