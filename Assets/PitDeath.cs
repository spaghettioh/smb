using UnityEngine;

public class PitDeath : MonoBehaviour
{
    public FloatVariable playerSize;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerSize.ApplyChange(-5);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
