using UnityEngine;

namespace Dummerhuan.BulletHell {
    public class Spawner : MonoBehaviour {
        public Rigidbody2D bulletPrefab;
        public Transform target;

        public float force;
        public float speed;

        public float fireRate = 1f;
        private float nextFire;

        // Update is called once per frame
        void Update() {
            SpinSpawner();

            if (Time.time > nextFire) {
                Fire();
            }
        }

        private void SpinSpawner() {
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }

        private void Fire() {
            Rigidbody2D bulletInstance = Instantiate(bulletPrefab, target.position, transform.rotation);
            bulletInstance.AddForce(target.position * force);

            nextFire = Time.time + fireRate;
        }
    }
}
