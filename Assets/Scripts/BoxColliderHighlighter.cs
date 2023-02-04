using UnityEngine;
using TMPro;

public class BoxColliderHighlighter : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
        // add label with name of game object
    }
}