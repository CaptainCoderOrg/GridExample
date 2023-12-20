using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGrid : MonoBehaviour
{
    // A reference to the container with all of the color selector buttons
    public Transform ColorOptionsContainer;
    // A reference to the container with all of the Tile buttons that can be clicked
    public Transform TileGridContainer;
    // The color that is currently selected
    public Color CurrentColor;

    public void Awake()
    {
        // When our scene is starting...
        
        // Register all of the color option buttons
        RegisterColorPickerButtons();
        // Register all of the TileGridButtons
        RegisterTileGridButtons();

    }

    private void RegisterColorPickerButtons()
    {
        foreach (Transform child in ColorOptionsContainer)
        {
            Button colorPickerButton = child.GetComponent<Button>();
            // Make sure we only have buttons in our ColorOptionsContainer
            Debug.Assert(colorPickerButton != null, "Discovered an object in the Color Options Container that was not a button.");
            // When the button is clicked, update CurrentColor to be this buttons normalColor
            colorPickerButton.onClick.AddListener(() => CurrentColor = colorPickerButton.colors.normalColor);
        }
    }

    private void RegisterTileGridButtons()
    {
        foreach (Transform child in TileGridContainer)
        {
            Button tileGridButton = child.GetComponent<Button>();
            // Make sure we only have buttons in our ColorOptionsContainer
            Debug.Assert(tileGridButton != null, "Discovered an object in the Tile Grid Container that was not a button.");
            // When the button is clicked, update the buttons color to be the current color
            tileGridButton.onClick.AddListener(() => {
                var colors = tileGridButton.colors;
                colors.normalColor = CurrentColor;
                colors.selectedColor = CurrentColor;
                tileGridButton.colors = colors;
            });
        }
    }
}
