using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewPuzzleManager : MonoBehaviour
{
    public string nextSceneName;
    public int totalPieces;
    public int placedPieces = 0;

    private void Start()
    {
        // Find total puzzle pieces at start
        totalPieces = GameObject.FindGameObjectsWithTag("PuzzlePiece").Length;
    }
    public void PiecePlaced()
    {
        placedPieces++;

        // Check if all puzzle pieces are placed
        if (placedPieces >= totalPieces)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}