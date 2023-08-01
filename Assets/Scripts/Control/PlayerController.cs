using TZ.EventController;
using UnityEngine;

namespace TZ.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] DynamicJoystick joystick;
        [SerializeField] GameObject playerBody;
        [SerializeField] GameObject playerRagdoll;
        [SerializeField] GameObject playerObject;
        [SerializeField] TrailRenderer trailRenderer;
        [SerializeField] float speed = 8f;
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