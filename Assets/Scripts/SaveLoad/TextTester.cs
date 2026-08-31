using UnityEngine;
using UnityEngine.UI;

public class TextTester : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Update()
    {
        GameData currentData = DataManager.instance.GetGameData();

        if(currentData == null)
        {
            text.text = "No data";
        }

        string jsonText = JsonUtility.ToJson(currentData);

        text.text = jsonText;
    }
}
