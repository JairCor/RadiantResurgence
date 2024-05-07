using UnityEngine;

public class TrackGameObject : MonoBehaviour
{
    public Transform targetObject; // Reference to the game object to track

    [SerializeField] private RectTransform borderRectTransform;
    [SerializeField] private RectTransform redRectTransform;
    [SerializeField] private RectTransform healthRectTransform;


    void Start()
    {
    }

    void Update()
    {
        if (targetObject != null)
        {
            Vector2 targetScreenPos = Camera.main.WorldToScreenPoint(targetObject.position);
            borderRectTransform.position = targetScreenPos;
            redRectTransform.position = targetScreenPos;
            healthRectTransform.position = targetScreenPos;
        }
    }
}
