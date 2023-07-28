using System.Collections.Generic;
using UnityEngine;

namespace TZ.Ground
{
    public class GroundMoover : MonoBehaviour
    {
        [SerializeField] int distanceToNextGround = 30;
        [SerializeField] GameObject groundPrefab;
        [SerializeField] List<GameObject> grounds = new List<GameObject>();

        public void RespawnGround()
        {
            Destroy(grounds[0]);
            grounds.RemoveAt(0);
            GameObject newGround = Instantiate(groundPrefab, transform.position, Quaternion.identity, transform);
            newGround.transform.position = new Vector3(0, grounds[grounds.Count - 1].transform.position.y, grounds[grounds.Count - 1].transform.position.z + distanceToNextGround);
            grounds.Add(newGround);    
        }
    }
}