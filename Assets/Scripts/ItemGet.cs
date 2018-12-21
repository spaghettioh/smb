using UnityEngine;
using UnityEngine.Events;

public class ItemGet : MonoBehaviour
{
    public UnityEvent collect;

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collect.Invoke();
        }
    }
}
