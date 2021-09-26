using UnityEngine;

public class SmoothMoveRotateFollow: MonoBehaviour
{
    public Transform target;
    float smooth = 0.3f;
    float yVelocity = 0.0f;
    float xVelocity = 0.0f;

    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        //smooth move(camera delay movement)
        if (target.position != transform.position)
        { 
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        //smooth rotate(camera delay rotation)
        if (target.rotation != transform.rotation)
        {
            float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
            float xAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x, target.eulerAngles.x, ref xVelocity, smooth);
            transform.rotation = Quaternion.Euler(xAngle, yAngle, 0);
        }
    }
  }