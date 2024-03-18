using UnityEngine;

public class GameCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D arrow;

    void Start()
    {
        Cursor.visible = true;

        Cursor.SetCursor(arrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
