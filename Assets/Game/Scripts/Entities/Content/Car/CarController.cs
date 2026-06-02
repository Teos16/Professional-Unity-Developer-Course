using System.Collections.Generic;
using UnityEngine;

namespace Game
{
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

        [Header("References")]
        [SerializeField]
        private Rigidbody rb;

        private float forwardInput;
        private float turnInput;
        private float currentBrake;

        private bool carStarted = false;

        // =========================
        // UNITY
        // =========================

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
        }

        // =========================
        // PUBLIC CONTROL METHODS 🔥
        // =========================

        public void SetInput(float forward, float turn)
        {
            forwardInput = Mathf.Clamp(forward, -1f, 1f);
            turnInput = Mathf.Clamp(turn, -1f, 1f);
        }

        public void SetBrake(bool isBraking)
        {
            currentBrake = isBraking ? brakeForce : 0f;
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

        public void ToggleCar()
        {
            if (carStarted)
                StopCar();
            else
                StartCar();
        }

        public bool IsStarted()
        {
            return carStarted;
        }

        // =========================
        // MOVEMENT
        // =========================

        private void Move()
        {
            float speed = rb.linearVelocity.magnitude * 3.6f;

            foreach (var wheel in rearWheels)
            {
                if (speed < maxSpeed)
                    wheel.motorTorque = forwardInput * motorTorque;
                else
                    wheel.motorTorque = 0;
            }

            ApplyBrakes(currentBrake);
        }

        private void Steer()
        {
            foreach (var wheel in frontWheels)
            {
                wheel.steerAngle = turnInput * maxSteerAngle;
            }
        }

        private void ApplyBrakes(float brake)
        {
            foreach (var wheel in frontWheels)
                wheel.brakeTorque = brake;

            foreach (var wheel in rearWheels)
                wheel.brakeTorque = brake;
        }

        // =========================
        // VISUALS
        // =========================

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

                Vector3 pos;
                Quaternion rot;

                colliders[i].GetWorldPose(out pos, out rot);

                meshes[i].position = pos;
                meshes[i].rotation = rot;
            }
        }
    }
}