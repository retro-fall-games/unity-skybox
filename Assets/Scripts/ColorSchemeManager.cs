using UnityEngine;

public class ColorSchemeManager : MonoBehaviour
{
  public static ColorSchemeManager Instance { get; private set; }

  public ColorScheme prevColorScheme = ColorScheme.Blue;
  public ColorScheme colorScheme = ColorScheme.Blue;

  public Color topColor;
  public Color middleColor;
  public Color bottomColor;
  public bool changeColor = false;
  float elapsed = 0f;
  float changeColorSpeed = .1f;
  float t = 0f;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    ColorSetup();
  }

  void ColorSetup()
  {
    prevColorScheme = ColorScheme.Blue;
    colorScheme = ColorScheme.Blue;
    Color[] colors = Colors.GetColorScheme(colorScheme);
    topColor = colors[0];
    middleColor = colors[1];
    bottomColor = colors[2];
  }

  void ColorLerp()
  {
    Color[] prevColors = Colors.GetColorScheme(prevColorScheme);
    Color[] colors = Colors.GetColorScheme(colorScheme);
    topColor = Color.Lerp(prevColors[0], colors[0], t);
    middleColor = Color.Lerp(prevColors[1], colors[1], t);
    bottomColor = Color.Lerp(prevColors[2], colors[2], t);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      prevColorScheme = colorScheme;
      colorScheme = ColorScheme.DarkBlue;
      changeColor = true;
    }
    elapsed += Time.deltaTime;
    if (elapsed >= changeColorSpeed)
    {
      elapsed = 0;
      if (changeColor)
      {
        t += .01f;
        ColorLerp();
        SkyboxManager.Instance.SetSkyboxColor();
        if (t >= 1)
        {
          changeColor = false;
          t = 0;
        }
      }
    }
  }

}
