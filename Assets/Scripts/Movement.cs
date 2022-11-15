using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidBody;
   
    AudioSource audioSource;
    [SerializeField] float thrustForce;
    [SerializeField] float rotationForce;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem mainBooster;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    void ProcessInput()
    {
        ApplyThrust();
        RotateRocket();
    }

    private void RotateRocket()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationForce);
            if (!rightBooster.isPlaying)
                rightBooster.Play();

            // Debug.Log("Rotating to the left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationForce);
            if (!leftBooster.isPlaying)
                leftBooster.Play();

            // Debug.Log("Rotating to the right");
        }
        else
        {
            leftBooster.Stop();
            rightBooster.Stop();
        }
    }

    private void ApplyThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Holding space - to thrust");
            rigidBody.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
            if (!mainBooster.isPlaying)
                mainBooster.Play();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
        {
            audioSource.Stop();
            mainBooster.Stop();
        }
    }

    private void ApplyRotation(float rotationForce)
    {
        rigidBody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        rigidBody.freezeRotation = false;
    }
}
