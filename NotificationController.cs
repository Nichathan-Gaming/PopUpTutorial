namespace PopUpTutorial
{
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NotificationController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text notificationTitle;
    [SerializeField] TMP_Text notificationContent;

    private void Start()
    {
        notificationTitle.text = PopUpData.title;
        notificationContent.text = PopUpData.content;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.UnloadSceneAsync(SceneNameEnum.PopUpScene.ToString());
    }
}
}

