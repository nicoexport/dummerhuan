using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dummerhuan.BulletHell {
    public class PlayerMovement : MonoBehaviour {
        Rigidbody2D rb;
        public InputAction playerControls;
        Vector2 moveDirection = Vector2.zero;
        public float moveSpeed;
        [SerializeField] private FloatReference playerCurrentHealth;
        private BulletHellMinigame bulletHellMinigame;

        private void OnEnable() {
            playerControls.Enable();
        }

        private void OnDisable() {
            playerControls.Disable();
        }

        // Start is called before the first frame update
        void Start() {
            bulletHellMinigame = GetComponentInParent<BulletHellMinigame>();
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update() {
            moveDirection = playerControls.ReadValue<Vector2>();
        }

        protected void FixedUpdate() {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag("Bullet")) {
                if (collision.TryGetComponent(out Bullet bullet)) {
                    playerCurrentHealth.Value -= bullet.damage;
                    bulletHellMinigame.DamageTaken();
                }
                collision.gameObject.SetActive(false);
            }
        }
    }
}
