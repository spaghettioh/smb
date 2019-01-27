using UnityEngine;
using UnityEngine.Events;

public class ItemGet : MonoBehaviour
{
    public UnityEvent collect;

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.name == "Player")
        {
            collect.Invoke();
        }
    }

    public void ItemDestroyNow()
    {
        Destroy(gameObject);
    }
}
