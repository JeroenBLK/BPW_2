using UnityEngine;

public class shipManueverController : MonoBehaviour
{
    private Rigidbody2D rb;
    float maxVelocity = 2;
    public float rotationSpeed = 3;
    public GameObject gameOverText, restartButton, explosion;
    public float strenth=20f;


    #region Monobehaviour

    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }


    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);
        Rotate(transform, xAxis * -rotationSpeed);
    }

    #endregion

    #region Manuevering API

    private void ClampVelocity() {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);


        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }

    #endregion
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            SoundManager.PlaySound("Explosion");
            SoundManager.PlaySound("Defeat");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "BlackHole")
        {
            Vector2 pos = other.transform.position;
            float dist = Vector2.Distance(pos, transform.position);
            Vector2 dir = ((Vector2)(transform.position) - pos).normalized;
            rb.velocity += -1*((dir * strenth)/(dist+0.001f));
        }
    }
}
