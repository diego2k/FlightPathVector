using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System;

public class InputHandler1 : MonoBehaviour, IInputClickHandler, IInputHandler
{
  public void ButtonCalled()
  {
    try
    {
      var _button = GameObject.Find("Choice 1").GetComponent<Button>();

      Image image = _button.GetComponent<Image>();
      string hexCode = "#84D0FF";
      Color lightblue;
      ColorUtility.TryParseHtmlString(hexCode, out lightblue);

      if (image != null)
      {
        if ((int)(image.color.r * 1000) == (int)(lightblue.r * 1000))

        {
          image.color = Color.yellow;
        }
        else
        {
          image.color = lightblue;
        }
      }
    }
    catch (Exception e)
    {

    }

  }


  public void OnInputClicked(InputClickedEventData eventData)
  {
    try
    {
      var _button = GameObject.Find("Choice 1").GetComponent<Button>();

      Image image = _button.GetComponent<Image>();
      string hexCode = "#84D0FF";
      Color lightblue;
      ColorUtility.TryParseHtmlString(hexCode, out lightblue);

      if (image != null)
      {
        if ((int)(image.color.r * 1000) == (int)(lightblue.r * 1000))

        {
          image.color = Color.yellow;
        }
        else
        {
          image.color = lightblue;
        }
      }
    }
    catch (Exception e)
    {

    }

  }

  public void OnInputDown(InputEventData eventData)
  {
    //throw new System.NotImplementedException();
  }

  public void OnInputUp(InputEventData eventData)
  {
    // throw new System.NotImplementedException();
  }
}