using UnityEngine;

namespace TZ.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] FloatingJoystick joystick = null;
        [SerializeField] GameObject playerBody = null;
        [SerializeField] float speed = 5f;
        int border = 2;
        Vector2 moveInput;
        bool isStopped = true;

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
            isStopped = false;
        }

        private void OnGameEnd(bool isGameRunning)
        {
            isStopped = true;
        }

        private void Update()
        {
            if (isStopped) return;
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            playerBody.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            moveInput = new Vector2(joystick.Horizontal, 0);
            if ((transform.position.x <= -border && moveInput.x < 0) || (transform.position.x >= border && moveInput.x > 0)) return;
            transform.Translate(-moveInput.normalized * speed * Time.deltaTime);
        }

        public bool GetGameStatus()
        {
            if (!isStopped) return true;
            else return false;
        }
    }
}