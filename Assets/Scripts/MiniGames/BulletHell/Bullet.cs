using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan.BulletHell {
    public class Bullet : MonoBehaviour {
        [SerializeField] private GameObjectCollection collection;
        public float damage = 1f;

        protected void OnEnable() {
            collection.Add(gameObject);
        }
    }
}
