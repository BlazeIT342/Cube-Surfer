using System.Collections;
using System.Collections.Generic;
using TZ.EventController;
using UnityEngine;

namespace TZ.Cubes
{
    public class CubeHolder : MonoBehaviour
    {
        [SerializeField] ParticleSystem cubeEffect;
        [SerializeField] Cube cubePrefab;
        [SerializeField] GameObject collectText;
        [SerializeField] Transform cubeHolderTransform;
        [SerializeField] Transform collectTextTransform;
        [SerializeField] Transform cubeRemoverTransform;
        [SerializeField] List<Cube> cubeList = new List<Cube>();
        bool isGameRunning = true;

        private void OnEnable()
        {
            GameEventManager.instance.onAddNewCube.AddListener(OnAddNewCube);
            GameEventManager.instance.onGameEnd.AddListener(OnGameEnd);
        }

        private void OnDisable()
        {
            GameEventManager.instance.onAddNewCube.RemoveListener(OnAddNewCube);
            GameEventManager.instance.onGameEnd.RemoveListener(OnGameEnd);
        }

        private void OnGameEnd(bool isGameRunning)
        {
            this.isGameRunning = isGameRunning;
        }

        private void OnAddNewCube(bool isGameRunning)
        {
            transform.position += Vector3.up;
            Cube cubeInstance = Instantiate(cubePrefab, cubeHolderTransform);
            cubeInstance.transform.position = new Vector3(cubeList[0].transform.position.x, cubeList[cubeList.Count - 1].transform.position.y - 1, cubeList[0].transform.position.z);
            GameObject textInstance = Instantiate(collectText, collectTextTransform);
            cubeEffect.Play();
            GetComponentInChildren<Animator>().SetTrigger("Jump");
            Destroy(textInstance, 5f);
            cubeList.Add(cubeInstance);
        }

        public IEnumerator RemoveCube(Cube cube)
        {
            cube.transform.SetParent(cubeRemoverTransform);
            yield return new WaitForSecondsRealtime(2);
            if (!isGameRunning) yield break;
            cubeList.Remove(cube);
            Destroy(cube.gameObject, 2f);
        }
    }
}