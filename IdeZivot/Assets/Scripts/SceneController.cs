﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private Stack<SceneView> stack;
    public SceneView startingScene;
    public Image blackoutImage;
    public InventoryController inventoryController;
    private const float animDuration = 20;

    private void Awake()
    {
        stack = new Stack<SceneView>();
        LoadScene(startingScene);
    }

    public void LoadScene(SceneView scene)
    {
        StartCoroutine(ChangeWall(scene));
    }

    private IEnumerator ChangeWall(SceneView scene)
    {
        yield return StartCoroutine(ChangeAlpha(0, 1));
        if (stack.Count > 0)
        {
            stack.Peek().HideScene();
        }
        scene.ShowScene();
        stack.Push(scene);
        inventoryController.ListenForPickUpsOnScene(startingScene);
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
