using UnityEngine;

public class Cube : MonoBehaviour
{ 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameEventManager.instance.CollisionWall();

            StartCoroutine(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<CubeHolder>().RemoveCube(this));          
        }
        if (collision.gameObject.CompareTag("CubePickup"))
        {
            GameEventManager.instance.AddNewCube();
            Destroy(collision.gameObject);
        }
    }
}