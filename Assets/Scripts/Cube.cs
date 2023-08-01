using UnityEngine;

public class Cube : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameEventManager.instance.CollisionWall();
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.GetComponentInChildren<CubeHolder>().RemoveCube(this);          
        }
        if (collision.gameObject.CompareTag("CubePickup"))
        {
            GameEventManager.instance.AddNewCube();
            Destroy(collision.gameObject);
        }
    }
}