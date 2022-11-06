using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using TMPro;


namespace Dummerhuan
{
    public class OnEncounterUI : MonoBehaviour 
    {
       
        public GameObject bottomPanel;
        public TextMeshProUGUI bottomTextBox;
        
        public void UIListener()
        {
            bottomPanel.SetActive(true);
            InvokeRepeating("ChangeMock", 0.1f, 5f);           
        }

        void ChangeMock()
        {            
            bottomTextBox.text = "HUAN!";
            Debug.Log("Huan!");
        }

    }
}
