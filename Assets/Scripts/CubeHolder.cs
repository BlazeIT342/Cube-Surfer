using System.Collections.Generic;
using TZ.Control;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField] ParticleSystem cubeEffect = null;
    [SerializeField] Cube cubePrefab = null;
    [SerializeField] GameObject collectText = null;
    [SerializeField] Transform cubeHolderTransform = null;
    [SerializeField] Transform collectTextTransform = null;
    [SerializeField] List<Cube> cubeList = new List<Cube>();

    private void OnEnable()
    {
        GameEventManager.instance.onAddNewCube.AddListener(OnAddNewCube);
    }

    private void OnDisable()
    {
        GameEventManager.instance.onAddNewCube.RemoveListener(OnAddNewCube);
    }

    private void OnAddNewCube(bool isGameRunning)
    {
        transform.position += new Vector3(0, 1f, 0);
        Cube cubeInstance = Instantiate(cubePrefab, cubeHolderTransform);
        cubeInstance.transform.position = new Vector3(cubeList[0].transform.position.x, cubeList[cubeList.Count - 1].transform.position.y - 1, cubeList[0].transform.position.z);
        GameObject textInstance = Instantiate(collectText, collectTextTransform);
        cubeEffect.Play();
        GetComponentInChildren<Animator>().SetTrigger("Jump");
        Destroy(textInstance, 5f);
        cubeList.Add(cubeInstance);
    }

    public void RemoveCube(Cube cube)
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetGameStatus()) return;
        cube.transform.SetParent(GameObject.FindGameObjectWithTag("Respawn").transform);
        cubeList.Remove(cube);
        Destroy(cube.gameObject, 2f);
    }
}