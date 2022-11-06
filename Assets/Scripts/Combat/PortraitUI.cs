using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dummerhuan.Combat {
    public class PortraitUI : MonoBehaviour {
        [SerializeField] private Image image;
        private Sprite lastSprite;
        private bool spriteCoroutineIsRunning;

        public void SetSpriteTempForSeconds(Sprite sprite, float timeInSeconds) {
            if (spriteCoroutineIsRunning) {
                return;
            }
            spriteCoroutineIsRunning = true;
            StartCoroutine(SetSpriteTempForSeconds_Co(sprite, timeInSeconds));
        }
        
        private IEnumerator SetSpriteTempForSeconds_Co(Sprite sprite, float timeInSeconds) {
            lastSprite = image.sprite;
            image.sprite = sprite;
            yield return new WaitForSeconds(timeInSeconds);
            image.sprite = lastSprite;
            spriteCoroutineIsRunning = false;
        }

    }
}