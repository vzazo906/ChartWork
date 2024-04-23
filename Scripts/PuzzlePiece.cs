using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzlePiece : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 initialPosition;
    private float snapDistance = 0.5f;
    public string attachTag = "Slot";
    public NewPuzzleManager puzzleManager;
    private bool isPlaced = false;
    public AudioClip correct;
    public AudioClip incorrect;
    private AudioSource audiosource;
    private int originalSortingOrder;
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        originalSortingOrder = GetComponent<Renderer>().sortingOrder;
    }
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
            GetComponent<Renderer>().sortingOrder = 9999;
        }
    }
    private void OnMouseDown()
    {
        if (!isPlaced)
        {
            isDragging = true;
            initialPosition = transform.position;
            GetComponent<Renderer>().sortingOrder = 9999;
        }
    }
    private void OnMouseUp()
    {
        if (isDragging && !isPlaced) // Ensure dragging and not already placed
        {
            isDragging = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, snapDistance);
            bool piecePlaced = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag(attachTag))
                {
                    transform.position = collider.transform.position;
                    piecePlaced = true;
                    isPlaced = true;
                    puzzleManager.PiecePlaced();
                    audiosource.PlayOneShot(correct);
                    break;
                }
            }
            if (!piecePlaced)
            {
                transform.position = initialPosition;
                audiosource.PlayOneShot(incorrect);
            }
            GetComponent<Renderer>().sortingOrder = originalSortingOrder;
        }
    }
}
