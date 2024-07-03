using UnityEngine;

public class ObjectZoom : MonoBehaviour
{
    public float zoomSpeed = 0.5f; // Speed of zooming
    public float minZoom = 1f; // Minimum zoom level
    public float maxZoom = 5f; // Maximum zoom level

    private Vector2 touchStartPos; // Initial touch position
    private float initialDistance; // Initial distance between touches

    void Update()
    {
        // Check for touch input
        if (Input.touchCount == 2)
        {
            // Get touch positions
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Calculate the distance between touches
            float distance = Vector2.Distance(touch0.position, touch1.position);

            // If it's the beginning of the touch, store initial values
            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                touchStartPos = (touch0.position + touch1.position) / 2f;
                initialDistance = distance;
            }
            // If the fingers are moving (not stationary)
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                // Calculate zoom amount based on the change in distance
                float zoomAmount = (distance - initialDistance) * zoomSpeed * Time.deltaTime;

                // Adjust zoom amount based on the current zoom level
                zoomAmount = Mathf.Clamp(zoomAmount, -maxZoom + transform.localScale.x, maxZoom - transform.localScale.x);

                // Apply the zoom
                transform.localScale += Vector3.one * zoomAmount;
                transform.localScale = Vector3.Max(transform.localScale, Vector3.one * minZoom);
                transform.localScale = Vector3.Min(transform.localScale, Vector3.one * maxZoom);

                // Update initial distance for the next frame
                initialDistance = distance;
            }
        }
    }
}
