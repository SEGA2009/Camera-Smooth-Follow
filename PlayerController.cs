using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public bool CanMove = false;
    float MoveSpeed = 5.0f;
    float RotateSpeed = 200.0f;
    private void FixedUpdate()
    {
        if (CanMove)
        {
            transform.position += Time.deltaTime * MoveSpeed * (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += Time.deltaTime * RotateSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
    }
}
