using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maxLength;

    private Ray rayMouse;
    private Vector2 pos;
    private Vector2 direction;
    private Quaternion rotation;

    private void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);

            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxLength))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                var pos = rayMouse.GetPoint(maxLength);
                RotateToMouseDirection(gameObject, pos);
            }
        }
        else
            Debug.Log("No camera");

    }

    void RotateToMouseDirection(GameObject obj, Vector2 destination)
    {

        direction = destination - new Vector2(obj.transform.position.x, obj.transform.position.y);
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}
