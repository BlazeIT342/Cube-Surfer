using System.Collections.Generic;
using TZ.Control;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField] Cube cubePrefab = null;
    [SerializeField] Transform cubeHolderTransform = null;
    [SerializeField] List<Cube> cubeList = new List<Cube>();

    public void AddCube()
    {
        transform.position += new Vector3 (0, 1, 0);
        Cube instance = Instantiate(cubePrefab, cubeHolderTransform);
        instance.transform.position = new Vector3 (cubeList[0].transform.position.x, cubeList[cubeList.Count-1].transform.position.y-1, cubeList[0].transform.position.z);
        
        print(cubeList.Count);
        cubeList.Add(instance);
    }

    public void RemoveCube(Cube cube)
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetGameStatus()) return;
        cube.transform.SetParent(GameObject.FindGameObjectWithTag("Respawn").transform);
        cubeList.Remove(cube);
        Destroy(cube.gameObject, 2f);
    }
}