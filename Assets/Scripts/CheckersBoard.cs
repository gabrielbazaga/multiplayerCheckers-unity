using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersBoard : MonoBehaviour
{
    public Piece[,] pieces = new Piece[8,8];
    public GameObject whitePiecePrefab;
    public GameObject blackPiecePrefab;

    private Vector3 boardOffset = new Vector3(-4.0f, 0,-4.0f);
    private Vector3 pieceOffset = new Vector3(0.5f, 0, 0.5f);

    private void Start()
    {
        GenerateBoard();
    }
    private void GenerateBoard()
    {
        // Generate white team
        for(int y=0; y <3; y++)
        {
            bool oddRow = (y % 2 == 0);
            for (int x=0; x<8; x+=2)
            {
                // Generate pieces
                GeneratePiece((oddRow)?x:x+1,y);
            }
        }

        // Generate black team
        for (int y = 7; y > 4; y--)
        {
            bool oddRow = (y % 2 == 0);
            for (int x = 0; x < 8; x += 2)
            {
                // Generate pieces
                GeneratePiece((oddRow) ? x : x+1, y);
            }
        }
    }

    public void GeneratePiece(int x, int y)
    {
        bool isWhite = (y > 3) ? false : true;

        GameObject go = Instantiate((isWhite) ? whitePiecePrefab : blackPiecePrefab) as GameObject;
        go.transform.SetParent(transform);
        Piece p = go.GetComponent<Piece>();
        pieces[x,y] = p;
        MovePiece(p, x, y);
        
    }

    private void MovePiece(Piece p, int x, int y)
    {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y) + boardOffset + pieceOffset;
    }
}