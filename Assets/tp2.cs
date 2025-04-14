using UnityEngine;

public class tp2 : MonoBehaviour
{    private Vector3 moffset;
private float mZCoord;

   private Vector3 GetMouseWorldPos()
   {
       Vector3 mousePoint = Input.mousePosition;
       mousePoint.z = mZCoord;
       return Camera.main.ScreenToWorldPoint(mousePoint);
   }
   private void OnMouseDown()
   {   Vector3 mousePoint = Input.mousePosition;
       mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
       mousePoint.z = mZCoord;
       moffset = gameObject.transform.position - GetMouseWorldPos();
     
   }
    private void OnMouseDrag()
    {   gameObject.transform.position = GetMouseWorldPos() + moffset;
    }
}
