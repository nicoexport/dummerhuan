using System.Collections;
using Dummerhuan.Combat;
using Dummerhuan.MiniGames;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan.BulletHell {
    public class BulletHellMinigame : MonoBehaviour, IMiniGame {
        public GameObjectCollection bulletCollection;
        public BoxCollider2D col;
        private bool finished;

        public int damageBreakpoint = 10;
        int damageTaken;

        private void OnEnable() {
            bulletCollection.Clear();
        }

        private void OnDisable() {
            bulletCollection.Clear();
        }

        protected void Update() {
            CheckBoundries();
        }

        private void CheckBoundries() {
            if (!col || finished) {
                return;
            }
            var list = bulletCollection.List;

            foreach (GameObject bullet in list) {

                Debug.Log(bullet);
                if (bullet.TryGetComponent(out Collider2D bulletCollider)) {
                    var dist = Physics2D.Distance(col, bulletCollider);
                    if (dist.distance > 0) {
                        bulletCollider.gameObject.SetActive(false);
                    }
                }
            }
        }

        public void DamageTaken() {
            damageTaken++;

            if (damageTaken >= damageBreakpoint) {
                finished = true;
            }
        }

        public void Setup(Effectiveness effectiveness) => throw new System.NotImplementedException();
        public IEnumerator Execute() {
            yield return new WaitUntil(() => finished);
            End();
        }

        public void End() {
            foreach (var item in bulletCollection) {
                Destroy(item);
            }
            bulletCollection.Clear();
            Destroy(this);
        }
    }
}
