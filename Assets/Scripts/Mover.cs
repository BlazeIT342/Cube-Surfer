using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    bool isStopped = true;

    private void Update()
    {
        if (isStopped) return;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetIsStopped(bool isStopped)
    {
        this.isStopped = isStopped;
    }
}
