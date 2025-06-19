using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static float Horizontal { get; private set; }
    public static bool JumpPressed { get; private set; }

    public void OnLeftButtonDown() => Horizontal = -1f;
    public void OnLeftButtonUp() => Horizontal = 0f;

    public void OnRightButtonDown() => Horizontal = 1f;
    public void OnRightButtonUp() => Horizontal = 0f;

    public void OnJumpButtonDown() => JumpPressed = true;
    public void OnJumpButtonUp() => JumpPressed = false;

}
