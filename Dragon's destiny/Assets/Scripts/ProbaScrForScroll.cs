using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProbaScrForScroll : MonoBehaviour
{


    public RectTransform element;
    public RectTransform content;
    public RectTransform scrollbar;
    public RectTransform scrollRect;

    public string[] list;

    private Vector2 delta;
    private Vector2 e_Pos;
    private bool open;
    private static int id = -1; // по умолчанию, не один из элементов - не выбран

    public static int currentID
    {
        get { return id; }
    }

    void Awake()
    {
        delta = element.sizeDelta;
        scrollRect.gameObject.SetActive(true);
        scrollbar.gameObject.SetActive(true);
    }

    void Start()
    {
        BuildList(); // запуск создания списка
    }

    public void SetElement(int e)
    {
        open = !open;
        scrollRect.gameObject.SetActive(open);
        scrollbar.gameObject.SetActive(open);
        if (e != id && e >= 0)
        {
            id = e;
            element.GetComponentInChildren<Text>().text = list[e];
        }
    }

    void ButtonSetup(Button button, int value)
    {
        button.onClick.AddListener(() => SetElement(value)); // установка функции onclick кнопки
    }

    void LateUpdate()
    {
        if (open)
        {
            if (!EventSystem.current.currentSelectedGameObject)
            {
                SetElement(-1);
            }
            else if (!EventSystem.current.currentSelectedGameObject.GetComponentInParent<ProbaScrForScroll>())
            {
                SetElement(-1);
            }
        }
    }

    void BuildList()
    {
        BuildWindow();
        float tmp = delta.y;
        bool start = true;

        for (int j = 0; j < list.Length; j++)
        {
            RectTransform clone = Instantiate(element) as RectTransform;
            clone.SetParent(content);
            if (start)
            {
                clone.anchoredPosition = new Vector2(e_Pos.x, e_Pos.y);
                start = false;
            }
            else
            {
                clone.anchoredPosition = new Vector2(e_Pos.x, e_Pos.y - tmp);
                tmp += delta.y;
            }
            clone.GetComponentInChildren<Text>().text = list[j];
            ButtonSetup(clone.GetComponent<Button>(), j);
        }

        ButtonSetup(element.GetComponent<Button>(), id);
        scrollRect.gameObject.SetActive(false);
        scrollbar.gameObject.SetActive(false);
    }

    void BuildWindow()
    {
        float height = delta.y * list.Length;
        content.sizeDelta = new Vector2(delta.x, height);
        content.anchoredPosition = new Vector2(0, -height / 2);
        e_Pos = new Vector2(0, (height / 2) - (delta.y / 2));
    }
}
