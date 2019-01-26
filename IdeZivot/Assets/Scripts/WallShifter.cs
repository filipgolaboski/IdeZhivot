using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallShifter : MonoBehaviour
{
    private const float animDuration = 20;
    public GameObject[] walls;
    public int currentWall;
    public Image blackoutImage;

    private void Awake()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].SetActive(false);
        }
        walls[currentWall].SetActive(true);
    }

    public void ShiftLeft()
    {
        GameObject oldWall = walls[currentWall];
        if (currentWall - 1 < 0) {
            currentWall = walls.Length - 1;
        } else {
            currentWall--;
        }
        GameObject leftWall = walls[currentWall];
        StartCoroutine(ChangeWall(leftWall, oldWall));
    }

    public void ShiftRight()
    {
        GameObject oldWall = walls[currentWall];
        currentWall = (currentWall + 1) % walls.Length;
        GameObject rightWall = walls[currentWall];
        StartCoroutine(ChangeWall(rightWall, oldWall));
    }

    private IEnumerator ChangeWall(GameObject wallToBeShown, GameObject wallToBeHidden)
    {
        yield return StartCoroutine(ChangeAlpha(0, 1));
        wallToBeShown.SetActive(true);
        wallToBeHidden.SetActive(false);
        yield return StartCoroutine(ChangeAlpha(1, 0));
    }

    private IEnumerator ChangeAlpha(float startAlpha, float endAlpha)
    {
        Color color = blackoutImage.color;
        for (float i = 1; i <= animDuration; i++)
        {
            color.a = Mathf.Lerp(startAlpha, endAlpha, i / animDuration);
            blackoutImage.color = color;
            yield return null;
        }
    }
}
