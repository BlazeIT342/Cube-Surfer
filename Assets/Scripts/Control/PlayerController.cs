using UnityEngine;

namespace TZ.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] FloatingJoystick joystick;
        [SerializeField] GameObject playerBody;
        [SerializeField] GameObject playerRagdoll;
        [SerializeField] GameObject playerObject;
        [SerializeField] TrailRenderer trailRenderer;
        [SerializeField] float speed = 5f;
        private bool isGameRunning;
        int border = 2;
        float moveInputHorizontal;

        private void OnEnable()
        {
            GameEventManager.instance.onGameStart.AddListener(OnGameStart);
            GameEventManager.instance.onGameEnd.AddListener(OnGameEnd);
        }

        private void OnDisable()
        {
            GameEventManager.instance.onGameStart.RemoveListener(OnGameStart);
            GameEventManager.instance.onGameEnd.RemoveListener(OnGameEnd);
        }

        private void OnGameStart(bool isGameRunning)
        {
            this.isGameRunning = isGameRunning;
        }

        private void OnGameEnd(bool isGameRunning)
        {
            this.isGameRunning = isGameRunning;
            RagdollAnimation();
            TrailAnimation();
        }

        private void Update()
        {
            if (!isGameRunning) return;
            PlayerMovement();

        }

        private void PlayerMovement()
        {
            playerBody.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            moveInputHorizontal = joystick.Horizontal * border;
            //if ((transform.position.x <= -border && moveInputHorizontal < 0) || (transform.position.x >= border && moveInputHorizontal > 0)) return;
            transform.position = new Vector3(moveInputHorizontal, transform.position.y, transform.position.z);
        }

        private void RagdollAnimation()
        {
            playerObject.GetComponent<Rigidbody>().mass = 1.0f;
            playerObject.GetComponent<Animator>().enabled = false;
            playerRagdoll.SetActive(true);
            playerObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000, ForceMode.Impulse);
        }

        private void TrailAnimation()
        {
            trailRenderer.time = 100;
        }
    }
}