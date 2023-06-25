using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlightButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Button pb;

    void Start()
    {
        pb = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pb.GetComponent<Image>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pb.GetComponent<Image>().enabled = false;
    }
}