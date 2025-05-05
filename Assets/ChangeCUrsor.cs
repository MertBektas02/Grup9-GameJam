using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] private Texture2D newCursor;
    
    void Start()
    {

        Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.Auto);
    }
}