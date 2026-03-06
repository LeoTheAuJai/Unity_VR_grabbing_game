using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRRayInteractor))]
public class ColorChangingRay : MonoBehaviour
{
    public Color defaultColor = Color.white;
    public Color hoverColor = Color.green;

    private XRRayInteractor rayInteractor;
    private XRInteractorLineVisual lineVisual; // Reference to the line visual component

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        lineVisual = GetComponent<XRInteractorLineVisual>(); // Get the line visual

        // Set initial color
        if (lineVisual != null)
            lineVisual.invalidColorGradient = CreateGradient(defaultColor);
    }

    void Update()
    {
        if (lineVisual == null) return;

        // Check if hovering a grabbable object
        bool isHoveringGrabbable = rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit) &&
                                  hit.collider.CompareTag("Clickable");

        // Change line color
        lineVisual.invalidColorGradient = CreateGradient(
            isHoveringGrabbable ? hoverColor : defaultColor
        );
    }

    // Helper to create a simple color gradient
    private Gradient CreateGradient(Color color)
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f) }
        );
        return gradient;
    }
}