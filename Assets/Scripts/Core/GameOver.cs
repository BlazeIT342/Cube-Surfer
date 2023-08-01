using TZ.EventController;
using UnityEngine;

namespace TZ.Core
{
    public class GameOver : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                GameEventManager.instance.EndGame();
            }
        }
    }
}