using UnityEngine;
using System.Collections;

public class SpinWithMouse : MonoBehaviour
{
    private Vector3 mousePos;

    IEnumerator OnMouseDown()
    {
        while (Input.GetMouseButton(0))
        {
            Vector3 offset = mousePos - Input.mousePosition;
            transform.Rotate(Vector3.up * offset.x, Space.World); 
            //transform.Rotate(Vector3.right * offset.y, Space.World);
            mousePos = Input.mousePosition; 
            yield return null;
        }
    }


    //public float speed = 10f;
    //void OnMouseDrag()
    //{
    //    float mouseX = Input.GetAxis("Mouse X");
    //    if (mouseX != 0)
    //    {
    //        transform.localRotation = Quaternion.Euler(0f, -0.5f * mouseX * speed, 0f) * transform.localRotation;
    //    }
    //}

}