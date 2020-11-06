using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;
using Vuforia;
using HoloToolkit.Unity;

public class StartFlightScript : MonoBehaviour, IInputClickHandler, IInputHandler
{

  public static GameObject HUD;
  public static GameObject StartManager;
  public static GameObject QuizManager;
  public static GameObject DoneManager;
  public static DataListener dataListener;

  public GameObject Help;

  public void Start()
  {

    Help.SetActive(false);

    HUD = GameObject.Find("HUD");
    StartManager = GameObject.Find("StartManager");
    QuizManager = GameObject.Find("Quiz_Canvas");
    DoneManager = GameObject.Find("DoneManager");
    HUD.SetActive(false);
    QuizManager.SetActive(false);
    DoneManager.SetActive(false);
    WorldAnchorManager.Instance.AttachAnchor(HUD);
    WorldAnchorManager.Instance.AttachAnchor(StartManager);
    WorldAnchorManager.Instance.AttachAnchor(QuizManager);
    WorldAnchorManager.Instance.AttachAnchor(DoneManager);

    dataListener = new DataListener();
  }

  public void StartSession()
  {
    StartManager.SetActive(false);
    HUD.SetActive(true);
#if WINDOWS_UWP
    DataListener list = HUD.GetComponent<DataListener>();
    list.StartConnection();
#endif
  }

  public static void CallStart()
  {
    StartManager.SetActive(false);
    HUD.SetActive(true);
#if WINDOWS_UWP
    DataListener list = HUD.GetComponent<DataListener>();
    list.StartConnection();
#endif
  }

  public void OnInputClicked(InputClickedEventData eventData)
  {
    StartManager.SetActive(false);
    HUD.SetActive(true);
#if WINDOWS_UWP
    DataListener list = HUD.GetComponent<DataListener>();
    list.StartConnection();
#endif
  }

  public void OnInputDown(InputEventData eventData)
  {
    // throw new System.NotImplementedException();
  }

  public void OnInputUp(InputEventData eventData)
  {
    //throw new System.NotImplementedException();
  }
}