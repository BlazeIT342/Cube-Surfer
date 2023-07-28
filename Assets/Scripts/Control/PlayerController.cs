using System.Collections;
using TZ.Ground;
using UnityEngine;

namespace TZ.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] FloatingJoystick joystick = null;
        [SerializeField] float speed = 20f;
        int border = 2;
        bool collided = false;
        Vector2 moveInput;

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            moveInput = new Vector2(joystick.Horizontal, 0);
            if ((transform.position.x <= -border && moveInput.x < 0) || (transform.position.x >= border && moveInput.x > 0)) return;
            transform.Translate(-moveInput.normalized * speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collided && collision.gameObject.CompareTag("Wall"))
            {
                collision.gameObject.GetComponentInParent<GroundMoover>().RespawnGround();
                StartCoroutine(CollisionTimer());
            }
        }

        private IEnumerator CollisionTimer()
        {
            collided = true;
            yield return new WaitForSecondsRealtime(1);
            collided = false;
        }
    }
}