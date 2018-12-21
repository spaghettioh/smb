using UnityEngine;

public class AnimationEventListener : MonoBehaviour {
    public IntVariable Score;

    void AnimAdjustScore(int amount)
    {
        Score.ApplyChange(amount);
    }

    void AnimDestroyThis()
    {
        Destroy(gameObject);
    }
}
