namespace PopUpTutorial
{
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject onHoverPopUp;

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHoverPopUp.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onHoverPopUp.SetActive(false);
    }
}
}
