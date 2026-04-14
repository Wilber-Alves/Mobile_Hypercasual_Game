using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public enum ScreenType
    {
        Main_Menu_Panel,
        Facebook_Panel,
        Rankling_Panel,
        Shop_Panel,
        Settings_Panel,
        Profile_Panel,
        Win_Panel,
        Failed_Panel,
        Ribbon_1,
        Ribbon_2,
        Ribbon_3,
        Ribbon_4,
        Ribbon_5,
        Ribbon_6,
        Ribbon_7,
        Ribbon_8,
        Facebook_Button,
        Settings_Button,
        Mission_Button,
        Profile_Button,
        Inventory_Button,
        Shop_Button
    }

    public class ScreenBase : MonoBehaviour
    {

        public ScreenType screenType;

        public List<Transform> listOfObjects;

        public List<Typer> listOfPhrases;


        public Image uiBackground;

        public bool startHided = false;





        [Header("Animation")]
        public float delayBetweenObjects = 0.1f;
        public float animationDuration = 0.5f;  

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }


        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");

        }

        private void HideObjects()
        { 
        
            listOfObjects.ForEach(x => x.gameObject.SetActive(false)); // hide all objects in the list
            uiBackground.enabled = false; // hide the background image

        }

        private void ShowObjects()
        {

            for(int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true); // show the object
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects); // animate the scale from 0 to 1 with
                                                                                            // a delay based on the index

            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count); // start typing after all objects are shown and animated
            uiBackground.enabled = false; // hide the background image
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            { 
                listOfPhrases[i].StartType(); // start typing the phrase
            }


        }


        private void ForceShowObjects()
        {
           
            listOfObjects.ForEach(x => x.gameObject.SetActive(true)); // show all objects in the list

        }

    }
}
