using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Transform variable")]
public class TransformVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public Transform Value;

    public void SetValue(Transform value)
    {
        Value = value;
    }
}
