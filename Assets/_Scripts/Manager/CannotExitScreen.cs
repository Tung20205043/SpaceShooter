using UnityEngine;
public class CannotExitScreen : MonoBehaviour {
    private float minX, minY, maxX, maxY;
    private readonly float planeX = 0.7f;
    private readonly float planeY = 0.5f;
    private void Start() {
        SetScreenBounds();
    }
    public CannotExitScreen() {
        Delegate.cantExitDelegate = ClampPositionToBounds;
    }

    private void SetScreenBounds() {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bounds.x + planeX;
        maxX = bounds.x - planeX;
        maxY = bounds.y - planeY;
        minY = -bounds.y + planeY;
    }

    private void ClampPositionToBounds(Transform obj) {
        Vector3 clampedPosition = obj.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        obj.position = clampedPosition;
    }
}
