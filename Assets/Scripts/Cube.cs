using TZ.Control;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] bool firstCube = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (firstCube)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GameOver();
                return;
            }
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CubeHolder>().RemoveCube(this);
        }
        if (collision.gameObject.CompareTag("CubePickup"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CubeHolder>().AddCube();
            Destroy(collision.gameObject);
        }
    }
}