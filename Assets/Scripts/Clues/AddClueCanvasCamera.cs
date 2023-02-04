using UnityEngine;

namespace ClueBoxes
{
    public class AddClueCanvasCamera : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
    }
}