using UnityEngine;

public class CandyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //increament score
            GameManeger.Instance.IncrementScore();
            Destroy(gameObject);
        }
        else if(collider.gameObject.tag == "Boundry")
        {
            //descrese life
            GameManeger.Instance.DecrementLife();
            Destroy(gameObject);
        }
    }
}
