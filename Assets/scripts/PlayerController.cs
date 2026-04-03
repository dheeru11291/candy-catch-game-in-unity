using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxPosXOfPlayer;

    void Start()
    {

    }


    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }
    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x, -maxPosXOfPlayer, maxPosXOfPlayer);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

}


