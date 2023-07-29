using System.Collections.Generic;
using TZ.Control;
using UnityEngine;

namespace TZ.Ground
{
    public class GroundMoover : MonoBehaviour
    {
        [SerializeField] int distanceToNextGround = 30;
        [SerializeField] List<GameObject> groundPrefabs = new List<GameObject>();
        [SerializeField] List<GameObject> grounds = new List<GameObject>();

        public void RespawnGround()
        {
            if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetGameStatus()) return;
            Destroy(grounds[0]);
            grounds.RemoveAt(0);
            GameObject newGround = Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Count)], transform.position, Quaternion.identity, transform);
            newGround.transform.position = new Vector3(0, grounds[grounds.Count - 1].transform.position.y, grounds[grounds.Count - 1].transform.position.z + distanceToNextGround);
            grounds.Add(newGround);    
        }

        public void StartRespawningGround()
        {
            Time.timeScale = 1.5f;
            InvokeRepeating("RespawnGround", 3, 4);
        }
    }
}