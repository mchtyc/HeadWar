using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
	private Rigidbody2D playerRB;
    
	private Vector2 centrePos, dir;
    private float maxSpeed, maxDist;
    
    private void Start()
    {
        playerRB = FindObjectOfType<Player>().gameObject.GetComponent<Rigidbody2D>();
        maxDist = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        maxSpeed = Time.fixedDeltaTime * playerRB.gameObject.GetComponent<Player>().maxSpeed;

        playerRB.MovePosition(playerRB.position + (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * maxSpeed/8));

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

        //Getting Input with MOUSE
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (Input.GetMouseButtonDown(0))
        {
            centrePos = mousePos;
        }
        else if (Input.GetMouseButton(0))
        {
            dir = (mousePos - centrePos).normalized;

            float dist = Vector2.Distance(mousePos, centrePos);
            dist = Mathf.Clamp(dist, 0f, maxDist);
            
            playerRB.AddForce(dir * dist * maxSpeed / 10000);
        }
#endif
    }
}