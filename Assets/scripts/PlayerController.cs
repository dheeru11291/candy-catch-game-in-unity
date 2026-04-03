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
        float intpuX= Input.GetAxis("Horizontal");
        transform.position += Vector3.right * intpuX *moveSpeed*Time.deltaTime;
        float xPos=Mathf.Clamp(transform.position.x, -maxPosXOfPlayer, maxPosXOfPlayer);
        transform.position=new Vector3(xPos,transform.position.y,transform.position.z);
    }
}
