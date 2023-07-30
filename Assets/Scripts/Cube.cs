using TZ.Control;
using TZ.Ground;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] bool firstCube = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (firstCube)
            {
                FindObjectOfType<Menu>().GameOver();
                player.GetComponent<PlayerController>().SetIsStopped(true);
                GameObject.FindGameObjectWithTag("Core").GetComponent<Mover>().SetIsStopped(true);
                
                return;
            }
            player.GetComponentInChildren<CubeHolder>().RemoveCube(this);
            FindObjectOfType<GroundMoover>().RespawnGround();
            GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CameraShake>().ShakeCamera(0.2f);
        }
        if (collision.gameObject.CompareTag("CubePickup"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<CubeHolder>().AddCube();
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CameraShake>().ShakeCamera(0.2f);
        }
    }
}