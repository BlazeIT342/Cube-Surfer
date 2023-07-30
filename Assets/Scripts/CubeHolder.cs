using System.Collections.Generic;
using TZ.Control;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField] ParticleSystem cubeEffect = null;
    [SerializeField] Cube cubePrefab = null;
    [SerializeField] GameObject collectText = null;
    [SerializeField] Transform cubeHolderTransform = null;
    [SerializeField] List<Cube> cubeList = new List<Cube>();

    public void AddCube()
    {
        transform.position += new Vector3 (0, 1f, 0);
        Cube cubeInstance = Instantiate(cubePrefab, cubeHolderTransform);
        cubeInstance.transform.position = new Vector3(cubeList[0].transform.position.x, cubeList[cubeList.Count - 1].transform.position.y - 1, cubeList[0].transform.position.z);
        GameObject textInstance = Instantiate(collectText, transform);
        cubeEffect.Play();  
        GetComponentInChildren<Animator>().SetTrigger("Jump");
        Destroy(textInstance,5f);
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