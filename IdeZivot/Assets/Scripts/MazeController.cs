﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MazeController : MonoBehaviour
{ 
    public int[,] maze = new int[,] { { 10, 11, 12 }, 
                                        { 13, 14 ,15} ,
                                        { 1, 16, 17 } };
    public MazePiece[] mazePiece;
    public MazeFinish[] mazeFinish;
    public MazeMoveSpot mazeMoveSpot;
    public GameObject obstacle;

    public MazePiece currentPiece;

    public UnityEvent gameFinished;
    public bool finished = false;
    public bool spawnFinished;
    int finishedIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        float step = 1f / maze.GetLength(0);
        Vector2 aMin = Vector2.zero;
        Vector2 aMax = Vector2.zero;
        aMax.y = step;
        for(int i=0;i<maze.GetLength(0);i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                aMax.x += step;

                GameObject obj = null;
                if (maze[i, j] != 2 && maze[i, j] < 10)
                {
                    obj = Instantiate(mazeMoveSpot.gameObject, transform);
                    obj.SetActive(true);
                    obj.GetComponent<MazeMoveSpot>().pos = new Vector2(i, j);
                    obj.GetComponent<MazeMoveSpot>().NotifyPointerEnter.AddListener(OnMoveSpotEnter);
                }

                if(maze[i,j] >= 10 && maze[i, j] < 100)
                {
                    MazePiece mp = mazePiece[maze[i, j] - 10];
                    mp.pos = new Vector2(i, j);
                    mp.selectedMaizePiece.AddListener(OnSelectMaizePiece);
                    mp.gameObject.SetActive(true);
                    if (spawnFinished) {
                        MazeFinish mf = mazeFinish[finishedIndex];
                        mf.gameObject.SetActive(true);
                        finishedIndex++;
                        mf.pos = new Vector2(i, j);
                        mf.NotifyPointerEnter.AddListener(EnteredFinish);
                        obj = mf.gameObject;
                        obj.SetActive(true);
                    }
                    mp.transform.SetParent(obj.transform);
                }

                if (maze[i, j] >= 100)
                {
                    MazeFinish mp = mazeFinish[maze[i, j] - 100];
                    mp.gameObject.SetActive(true);
                    mp.pos = new Vector2(i, j);
                    mp.NotifyPointerEnter.AddListener(EnteredFinish);
                    obj = mp.gameObject;
                    obj.SetActive(true);
                }

                if (maze[i,j] == 2)
                {
                    obj = Instantiate(obstacle, transform);
                    obj.SetActive(true);
                }
               
                obj.GetComponent<RectTransform>().anchorMax = aMax;
                obj.GetComponent<RectTransform>().anchorMin = aMin;
                obj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                obj.GetComponent<RectTransform>().offsetMax = Vector2.zero;
                obj.GetComponent<RectTransform>().offsetMin = Vector2.zero;
                aMin.x += step;
            }
            aMax.x = 0;
            aMin.x = 0;
            aMax.y += step;
            aMin.y += step;
        }

    }

    public void OnSelectMaizePiece(MazePiece m)
    {
        currentPiece = m;
    }

    public void OnMoveSpotEnter(MazeMoveSpot moveSpot)
    {
        if(currentPiece != null)
        {
            Vector2 offset = new Vector2(Mathf.Abs(currentPiece.pos.x - moveSpot.pos.x), Mathf.Abs(currentPiece.pos.y - moveSpot.pos.y));
            if ((offset.x == 1 || offset.y == 1) && offset.x != offset.y)
            {
                currentPiece.transform.SetParent(moveSpot.transform);
                currentPiece.transform.localPosition = Vector2.zero;
                currentPiece.pos = moveSpot.pos;
            }
        }
    }


    private void Update()
    {
        if(Input.GetMouseButtonUp(0) || finished)
        {
            currentPiece = null;
        }
    }

    public void EnteredFinish(MazeFinish mazeFin) {
        if (currentPiece != null)
        {
            Vector2 offset = new Vector2(Mathf.Abs(currentPiece.pos.x - mazeFin.pos.x), Mathf.Abs(currentPiece.pos.y - mazeFin.pos.y));
            if ((offset.x == 1 || offset.y == 1) && offset.x != offset.y)
            {
                currentPiece.transform.SetParent(mazeFin.transform);
                currentPiece.transform.localPosition = Vector2.zero;
                currentPiece.pos = mazeFin.pos;
            }

            if(mazeFin.mazePiece.Equals(currentPiece))
            {
                mazeFin.finished = true;
            }

            bool done = true;

            for(int i=0;i<mazeFinish.Length;i++)
            {
                if (!mazeFinish[i].finished)
                {
                    done = false;
                }
            }

            if(done)
            {
                gameFinished.Invoke();
                currentPiece = null;
                finished = true;
            }
        }
    }
}
