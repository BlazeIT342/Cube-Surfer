using UnityEngine;

public class EnhancedGravity : MonoBehaviour
{
    public Rigidbody otherRigidbody;
    public float gravitationalConstant = 6.674f; // Гравитационная постоянная (можно изменить по необходимости)

    private Rigidbody ownRigidbody;

    private void Start()
    {
        ownRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (otherRigidbody != null)
        {
            Vector3 direction = otherRigidbody.position - ownRigidbody.position;
            float distance = direction.magnitude;
            float forceMagnitude = gravitationalConstant * (ownRigidbody.mass * otherRigidbody.mass) / (distance * distance);

            Vector3 force = direction.normalized * forceMagnitude;
            ownRigidbody.AddForce(force);
        }
    }
}
