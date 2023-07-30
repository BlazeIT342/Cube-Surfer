using TZ.Control;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameOver : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetIsStopped(true);
                GameObject.FindGameObjectWithTag("Core").GetComponent<Mover>().SetIsStopped(true);
                return;
            }
        }
    }
}