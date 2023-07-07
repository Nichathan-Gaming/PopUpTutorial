namespace PopUpTutorial
{
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneNameEnum
{
    PopUpScene
}

public class PopUpController : MonoBehaviour
{
    public void OnLocalVerifyClick()
    {
        //show a local verification
        LocalNotificationController.instance.SetLocalNotificationController("Verification", "Can you click Yes?", (bool value) =>
        {
            print($"They clicked {(value ? "Yes" : "No")}");
        });
    }

    public void OnRemoteNotifyClick()
    {
        PopUpData.SetData("Hello", "World");
        SceneManager.LoadScene(SceneNameEnum.PopUpScene.ToString(), LoadSceneMode.Additive);
    }
}
}

