using UnityEngine;
using UnityEngine.Events;

public class EraserScript : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second
    public UnityEvent onFullRotation;

    private float currentRotation = 0f;
    private bool rotating { get; set; }

    void Update()
    {
        if (rotating)
        {
            float delta = rotationSpeed * Time.deltaTime;
            currentRotation += delta;
            this.transform.localEulerAngles = new Vector3(0f, currentRotation, 0f);

            if (currentRotation >= 360f)
            {
                this.StopRotating();
                onFullRotation.Invoke();
            }
        }
    }

    public void StartRotating()
    {
        rotating = true;
        currentRotation = 0f; 
        this.transform.localEulerAngles = new Vector3(0f, currentRotation, 0f);        
    }

    public void StopRotating()
    {
        rotating = false;
        currentRotation = 0f;
        this.transform.localEulerAngles = new Vector3(0f, currentRotation, 0f);
    }
}
