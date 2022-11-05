using System.Collections;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan.Combat {
    public class BloodFlashUI : MonoBehaviour {
        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private GameObject bloodFlash;
        private bool flashing;

        public void OnHealthChanged() {
            if (flashing)
                return;
            flashing = true;
        }

        private IEnumerator Flash_Co() {
            bloodFlash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            bloodFlash.SetActive(false);
        }
    }
}