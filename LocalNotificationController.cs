namespace PopUpTutorial
{
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LocalNotificationController : MonoBehaviour
{
    internal static LocalNotificationController instance;

    [SerializeField] GameObject backgroundObject;

    [SerializeField] TMP_Text notificationTitle;
    [SerializeField] TMP_Text notificationContent;

    [SerializeField] GameObject notificationButtonHolder;
    [SerializeField] GameObject verificationButtonHolder;

    [SerializeField] UnityEvent<bool> onAccept = new UnityEvent<bool>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// A simple notification
    /// </summary>
    /// <param name="content">The message of the notification</param>
    internal void SetLocalNotificationController(string content)
    {
        backgroundObject.SetActive(true);
        notificationContent.text = content;

        notificationButtonHolder.SetActive(true);
        verificationButtonHolder.SetActive(false);
    }

    /// <summary>
    /// A simple notification that closes on its own
    /// </summary>
    /// <param name="title">The title message of this notification</param>
    /// <param name="content">The message of the notification</param>
    /// <param name="secondsToClose">The time until it closes</param>
    internal void SetLocalNotificationController(string title, string content, float secondsToClose)
    {
        backgroundObject.SetActive(true);
        notificationContent.text = content;
        notificationTitle.text = title;

        notificationButtonHolder.SetActive(true);
        verificationButtonHolder.SetActive(false);

        StartCoroutine(CloseAfterSeconds(secondsToClose));
    }

    /// <summary>
    /// A simple notification that runs a function when it is closed
    /// </summary>
    /// <param name="title">The title message of this notification</param>
    /// <param name="content">The message of the notification</param>
    /// <param name="onAccept">The function called when it is closed</param>
    internal void SetLocalNotificationController(string title, string content, UnityAction<bool> onAccept)
    {
        backgroundObject.SetActive(true);
        notificationContent.text = content;
        notificationTitle.text = title;

        notificationButtonHolder.SetActive(false);
        verificationButtonHolder.SetActive(true);

        if (onAccept != null)
        {
            this.onAccept.AddListener(onAccept);
        }
    }

    IEnumerator CloseAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        backgroundObject.SetActive(false);
    }

    /// <summary>
    /// Ran when Okay, Yes or No buttons are pressed
    /// </summary>
    /// <param name="isAccept">Was Okay or Yes clicked</param>
    public void OnAccept(bool isAccept)
    {
        backgroundObject.SetActive(false);
        onAccept?.Invoke(isAccept);
        onAccept?.RemoveAllListeners();
    }
}
}
