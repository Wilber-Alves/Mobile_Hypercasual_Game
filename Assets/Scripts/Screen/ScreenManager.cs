using EDGEE.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Main_Menu_Panel;

        private ScreenBase _currentScreen;

        private void Start()
        {
            Hide();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if(_currentScreen != null)
            {
                _currentScreen.Hide();
            }

            var nexteScreen = screenBases.Find(i => i.screenType == type);

            nexteScreen.Show();
            _currentScreen = nexteScreen;

        }

        public void Hide()
        { 
            screenBases.ForEach(i => i.Hide());
        }

    }
}
