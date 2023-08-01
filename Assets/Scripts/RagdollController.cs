using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerRagdol;

    private void OnEnable()
    {
        GameEventManager.instance.onGameEnd.AddListener(OnGameEnd);
    }

    private void OnDisable()
    {
        GameEventManager.instance.onGameEnd.RemoveListener(OnGameEnd);
    }

    private void OnGameEnd(bool isGameRunning)
    {
        player.GetComponent<Rigidbody>().mass = 1.0f;
        player.GetComponent<Animator>().enabled = false;
        playerRagdol.SetActive(true);
        player.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000, ForceMode.Impulse);
    }
}
