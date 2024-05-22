using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStats.main.UpdateHealth(10);
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, transform.position.y + 4f ) * 10f,ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }

    

}
