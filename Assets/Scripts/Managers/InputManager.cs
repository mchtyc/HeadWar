using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InputManager : MonoBehaviour
{
	private Rigidbody2D playerRB;
	private Player player;
    
	private Vector2 centrePos, dir;
    private float maxSpeed, maxDist;
    public Transform cam;
    
    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        playerRB = player.gameObject.GetComponent<Rigidbody2D>();
        maxDist = 200f;
    }

    void FixedUpdate()
    {
        maxSpeed = Time.fixedDeltaTime * player.maxSpeed;
        Vector3 diff_ = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * maxSpeed;
        Debug.Log("diff_ : " + diff_);
        //playerRB.MovePosition(playerRB.position + diff_);
        //player.transform.position += diff_;
        playerRB.linearVelocity = diff_;
        Vector3 target_pos = new Vector3(player.transform.position.x, player.transform.position.y, cam.position.z);
        cam.position = Vector3.Lerp(cam.position, target_pos, 0.1f);

#if UNITY_ANDROID || !UNITY_EDITOR
        //Getting Input with TOUCH
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                centrePos = t.position;
            }
            else if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
            {
                dir = (t.position - centrePos).normalized;

                float dist = Vector2.Distance(centrePos, t.position);                
                dist = Mathf.Clamp(dist, 0f, maxDist);
                
                playerRB.AddForce(dir * dist * maxSpeed / 10000);
            }
        }
#endif

#if UNITY_EDITOR

        ////Getting Input with MOUSE
        //Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    centrePos = mousePos;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    dir = (mousePos - centrePos).normalized;

        //    float dist = Vector2.Distance(mousePos, centrePos);
        //    dist = Mathf.Clamp(dist, 0f, maxDist);
            
        //    playerRB.AddForce(dir * dist * maxSpeed / 10000);
        //}
#endif
    }
}