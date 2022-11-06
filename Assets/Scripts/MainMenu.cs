using Dummerhuan.References;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dummerhuan
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private FloatReference playerCurrentHealth;
        [SerializeField] private FloatReference playerMaxHealth;
        [SerializeField] private EnemySOReference currentEnemy;
        [SerializeField] private BoolReference paladinState;
        [SerializeField] private BoolReference aasimarState;
        [SerializeField] private BoolReference elfState;

        private bool onCredits;
        [SerializeField] private GameObject creditsScreen;
        [SerializeField] private Image portraitImage;

        [SerializeField] private Sprite[] portraits;


        public void Continue() {
            SceneManager.LoadScene(2);
        }

        public void NewGame() {
            playerCurrentHealth.Value = playerMaxHealth.Value;
            currentEnemy.Value = null;
            paladinState.Value = false;
            aasimarState.Value = false;
            elfState.Value = false;

            SceneManager.LoadScene(2);
        }

        public void Credits() {
            onCredits = !onCredits;

            if (onCredits) {
                creditsScreen.SetActive(true);
            } else {
                creditsScreen.SetActive(false);
            }
        }

        public void Exit() {
            Application.Quit();
        }
    }
}
