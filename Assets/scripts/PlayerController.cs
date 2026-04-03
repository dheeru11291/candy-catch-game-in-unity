using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField]float moveSpeed;
    [SerializeField] float maxPosXOfPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        float inputX = 0f;

        // Desktop (keyboard/controller)
        inputX = Input.GetAxis("Horizontal");

        // Mobile (touch)
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Example: move based on touch position relative to screen center
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (touch.position.x < Screen.width / 2)
                    {
                        inputX = -1f; // move left
                    }
                    else
                    {
                        inputX = 1f; // move right
                    }
                }
            }
        }

        // Apply movement
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;

        // Clamp position
        float xPos = Mathf.Clamp(transform.position.x, -maxPosXOfPlayer, maxPosXOfPlayer);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    //private void Move()
    //{
    //    float intpuX= Input.GetAxis("Horizontal");
    //    transform.position += Vector3.right * intpuX *moveSpeed*Time.deltaTime;
    //    float xPos=Mathf.Clamp(transform.position.x, -maxPosXOfPlayer, maxPosXOfPlayer);
    //    transform.position=new Vector3(xPos,transform.position.y,transform.position.z);
    //}
}
