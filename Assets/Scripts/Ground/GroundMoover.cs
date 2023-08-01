using System.Collections;
using System.Collections.Generic;
using TZ.EventController;
using UnityEngine;

namespace TZ.Ground
{
    public class GroundMoover : MonoBehaviour
    {
        [SerializeField] int distanceToNextGround = 30;
        [SerializeField] List<GameObject> groundPrefabs = new List<GameObject>();
        [SerializeField] List<GameObject> grounds = new List<GameObject>();
        bool readyToSpawn = true;

        private void OnEnable()
        {
            GameEventManager.instance.onCollisionWall.AddListener(OnCollisionWall);
        }

        private void OnDisable()
        {
            GameEventManager.instance.onCollisionWall.RemoveListener(OnCollisionWall);
        }

        private void OnCollisionWall(bool isGameRunning)
        {
            RespawnGround(isGameRunning);
        }
        public void RespawnGround(bool isGameRunning)
        {          
            if (!isGameRunning || !readyToSpawn) return;
            StartCoroutine(RespawnCooldown());
            Destroy(grounds[0]);
            grounds.RemoveAt(0);
            GameObject newGround = Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Count)], transform.position, Quaternion.identity, transform);
            newGround.transform.position = new Vector3(0, grounds[grounds.Count - 1].transform.position.y, grounds[grounds.Count - 1].transform.position.z + distanceToNextGround);
            grounds.Add(newGround);    
        }

        private IEnumerator RespawnCooldown()
        {
            readyToSpawn = false;
            yield return new WaitForSecondsRealtime(1);
            readyToSpawn = true;
        }
    }
}