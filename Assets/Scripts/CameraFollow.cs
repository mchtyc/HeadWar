using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //private float xPos, yPos;
    Transform target;
  
    public void SetCamera(Transform player_)
    {
        target = player_;
    }

    void LateUpdate()
    {
        //xPos = Player.currentPos.x;
        //yPos = Player.currentPos.y;

        //xPos = Mathf.Clamp(xPos, -32.7f, 32.7f);
        //yPos = Mathf.Clamp(yPos, -16.5f, 16.5f);

        //Vector3 target_pos = new Vector3(target.position.x, target.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, target_pos, 0.2f);
        //transform.position = target_pos;
    }
}
