using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
