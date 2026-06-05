using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheels")]
    [SerializeField]
    private List<WheelCollider> frontWheels;
    [SerializeField]
    private List<WheelCollider> rearWheels;

    [Header("Wheel Meshes")]
    [SerializeField]
    private List<Transform> frontWheelMeshes;
    [SerializeField]
    private List<Transform> rearWheelMeshes;

    [Header("Car Settings")]
    [SerializeField]
    private float motorTorque = 400f;
    [SerializeField]
    private float maxSteerAngle = 25f;
    [SerializeField]
    private float brakeForce = 200f;
    [SerializeField]
    private float maxSpeed = 120f;
    [SerializeField]
    private float idleBrake = 50f;

    [Header("References")]
    [SerializeField]
    private Rigidbody rb;

    private float currentForce;
    private float currentTurn;

    private bool hasForceThisFrame;
    private bool hasTurnThisFrame;

    private bool carStarted = false;
    public bool CarStarted => carStarted;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void Update()
    {
        UpdateWheelMeshes();
    }

    private void FixedUpdate()
    {
        if (!carStarted)
        {
            ApplyBrakes(brakeForce);
            return;
        }

        Move();
        Steer();

        hasForceThisFrame = false;
        hasTurnThisFrame = false;
    }

    public void ApplyForce(float force)
    {
        currentForce = Mathf.Clamp(force, -1f, 1f);
        hasForceThisFrame = true;
    }

    public void ApplyTurn(float turn)
    {
        currentTurn = Mathf.Clamp(turn, -1f, 1f);
        hasTurnThisFrame = true;
    }

    public void StartCar()
    {
        carStarted = true;
        rb.constraints = RigidbodyConstraints.None;
    }

    public void StopCar()
    {
        carStarted = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        ApplyBrakes(brakeForce);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Move()
    {
        float speed = rb.linearVelocity.magnitude * 3.6f;

        float torque = hasForceThisFrame ? currentForce * motorTorque : 0f;
        float brake = hasForceThisFrame ? 0f : idleBrake;

        foreach (var wheel in rearWheels)
        {
            wheel.motorTorque = speed < maxSpeed ? torque : 0f;
        }

        ApplyBrakes(brake);
    }

    private void Steer()
    {
        float steer = hasTurnThisFrame ? currentTurn * maxSteerAngle : 0f;

        foreach (var wheel in frontWheels)
        {
            wheel.steerAngle = steer;
        }
    }

    private void ApplyBrakes(float brake)
    {
        foreach (var wheel in frontWheels)
            wheel.brakeTorque = brake;

        foreach (var wheel in rearWheels)
            wheel.brakeTorque = brake;
    }

    private void UpdateWheelMeshes()
    {
        UpdateWheels(frontWheels, frontWheelMeshes);
        UpdateWheels(rearWheels, rearWheelMeshes);
    }

    private void UpdateWheels(List<WheelCollider> colliders, List<Transform> meshes)
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            if (i >= meshes.Count) continue;

            colliders[i].GetWorldPose(out var pos, out var rot);

            meshes[i].position = pos;
            meshes[i].rotation = rot;
        }
    }
}