using UnityEngine;

namespace TZ.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] FloatingJoystick joystick = null;
        [SerializeField] float speed = 20f;
        int border = 2;
        Vector2 moveInput;
        bool isStopped = false;

        private void Update()
        {
            if (isStopped) return;
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            moveInput = new Vector2(joystick.Horizontal, 0);
            if ((transform.position.x <= -border && moveInput.x < 0) || (transform.position.x >= border && moveInput.x > 0)) return;
            transform.Translate(-moveInput.normalized * speed * Time.deltaTime);
        }

        public void GameOver()
        {
            isStopped = true;
        }

        public bool GetGameStatus()
        {
            if (!isStopped) return true;
            else return false;
        }
    }
}