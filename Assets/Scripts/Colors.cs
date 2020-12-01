using UnityEngine;
using System.Collections.Generic;

public enum ColorScheme { Blue, DarkBlue };

public class Colors : MonoBehaviour
{

  public static List<ColorScheme> colorSchemeList = new List<ColorScheme> { ColorScheme.Blue, ColorScheme.DarkBlue };

  public static Color[] GetBlueScheme()
  {
    return new Color[] { Color.blue, Color.green, Color.black };
  }

  public static Color[] GetDarkBlueScheme()
  {
    return new Color[] { Color.red, Color.green, Color.black };
  }

  public static Color[] GetColorScheme(ColorScheme colorScheme)
  {
    switch (colorScheme)
    {
      case ColorScheme.Blue:
        return GetBlueScheme();
      case ColorScheme.DarkBlue:
        return GetDarkBlueScheme();
      default:
        return GetBlueScheme();
    }
  }

}
