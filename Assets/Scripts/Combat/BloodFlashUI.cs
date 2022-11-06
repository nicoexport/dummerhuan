using System;
using System.Collections;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan.Combat {
    public class BloodFlashUI : MonoBehaviour {
        [SerializeField] private GameObject bloodFlashImage;
        [SerializeField] private FloatReference playerMaxHealth;
        [SerializeField] private FloatReference playerCurrentHealth;
        private bool flashing;

        protected void OnEnable() {
           bloodFlashImage.SetActive(false); 
        }
        
        public void OnHealthChanged() {
            if (Math.Abs(playerCurrentHealth.Value - playerMaxHealth.Value) < 0.1f) {
                return;
            }
            if (flashing) {
                return;
            }
            flashing = true;
            StartCoroutine(Flash_Co());
        }

        private IEnumerator Flash_Co() {
            bloodFlashImage.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            bloodFlashImage.SetActive(false);
            flashing = false;
        }
    }
}