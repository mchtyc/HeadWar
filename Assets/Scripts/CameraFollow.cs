using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private float xPos, yPos;
  
    // Update is called once per frame
    void LateUpdate()
    {
        xPos = Player.currentPos.x;
        yPos = Player.currentPos.y;

        xPos = Mathf.Clamp(xPos, -32.7f, 32.7f);
        yPos = Mathf.Clamp(yPos, -16.5f, 16.5f);

        transform.position = new Vector3 (xPos, yPos, -10f);
    }
}
