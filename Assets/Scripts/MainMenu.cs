using System.Collections;
using System.Collections.Generic;
using Dummerhuan.References;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Continue() {
            SceneManager.LoadScene(1);
        }

        public void NewGame() {
            playerCurrentHealth.Value = playerMaxHealth.Value;
            currentEnemy.Value = null;
            paladinState.Value = false;
            aasimarState.Value = false;
            elfState.Value = false;

            SceneManager.LoadScene(1);
        }

        public void Credits() {

        }

        public void Exit() {
            Application.Quit();
        }
    }
}
