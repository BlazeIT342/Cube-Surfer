using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] GameObject playerBody;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerRagdol;

    public void DieAction()
    {
        player.GetComponent<Rigidbody>().mass = 1.0f;
        player.GetComponent<Animator>().enabled = false;
        playerRagdol.SetActive(true);
        player.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000, ForceMode.Impulse);
    }
}
