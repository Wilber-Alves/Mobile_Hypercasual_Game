using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick()
        { 
            ScreenManager.Instance.ShowByType(screenType);
        }
    }
}