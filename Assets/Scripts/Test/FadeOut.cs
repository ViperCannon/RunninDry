using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    Image imageComponent;
    float fadeDuration = 3f;  // Duration to fade out
    float currentTime = 0f;
    bool fading = false;

    void OnEnable()
    {
        // Get the Image component attached to this GameObject
        imageComponent = GetComponent<Image>();

        // Ensure the image is fully opaque when the object is enabled
        Color color = imageComponent.color;
        color.a = 1f;  // Fully opaque
        imageComponent.color = color;

        // Reset fade time to start the fade-out process
        currentTime = 0f;
        fading = true;
    }

    void Update()
    {
        // Fade the image out over time
        if (imageComponent != null && fading && currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);

            // Apply the new alpha value to the image's color
            Color color = imageComponent.color;
            color.a = alpha;
            imageComponent.color = color;
        }
        
        if(imageComponent.color.a < 0.001f)
        {
            fading = false;
            gameObject.SetActive(false);
        }
    }
}
