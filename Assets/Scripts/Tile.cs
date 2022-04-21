using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.EventSystems;
using static Game.GamePlay;
using static Game.Globals;

public class Tile : MonoBehaviour{  

    [SerializeField] private Color baseColor, offsetColor;
   // [SerializeField] private SpriteRenderer theRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] public TextMesh proba = null;
    [SerializeField] private new SpriteRenderer Srenderer;

    [SerializeField] public TextMesh busting; 

    private int clickCount = 0;

    public void Init(bool isOffset) {
        Srenderer = GetComponent<SpriteRenderer>();
        Srenderer.color = isOffset ? offsetColor : baseColor;
    }
 
    public void OnMouseEnter() {
        highlight.SetActive(true);
    }
 
    public void OnMouseExit(){
        highlight.SetActive(false);
    }

    public void OnMouseDown(){
        //change tile color based on probabilities
        clickCount++;
        if(clickCount == 1){
            highlight.SetActive(false);
            Srenderer.color = Color.yellow;
            Debug.Log(Srenderer.transform.position);
            UpdatePosteriorProbabilities(Srenderer.transform.position, this);
        }
        else if(clickCount == 2){
            Debug.Log("You have busted tile " + Srenderer.transform.position);
            bool res = Bust(Srenderer.transform.position);
            if(res){
                Srenderer.color = Color.red;
                this.busting = UtilsClass.CreateWorldText("YOU HAVE BUSTED THE GHOST! :)", null, new Vector3(10.0f, 8.0f, 0.0f), 20, Color.blue, TextAnchor.MiddleCenter);
                this.busting.transform.localScale = new Vector3((float)0.4,(float)0.4,(float)0.4);
            }
            else{
                this.busting = UtilsClass.CreateWorldText("GAME OVER!", null, new Vector3(10.0f, 8.0f, 0.0f), 20, Color.red, TextAnchor.MiddleCenter);
                this.busting.transform.localScale = new Vector3((float)0.4,(float)0.4,(float)0.4);
            }
            //UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void SetProba(double proba){

        if(this.proba != null){
            // Update the probability
            this.proba.text = proba.ToString("0.00000");;
        }
        else{
            Debug.Log(Srenderer.transform.position);
            //init
            this.proba = UtilsClass.CreateWorldText(proba.ToString("0.00000"), null, Srenderer.transform.position, 25, Color.black, TextAnchor.MiddleCenter);
            this.proba.transform.localScale = new Vector3((float)0.1,(float)0.1,(float)0.1);
        }
    }

    public void SetColor(DisplayedColor c){
        switch(c){
            case DisplayedColor.Red:
                Srenderer.color = Color.red;
                break;
            case DisplayedColor.Yellow:
                Srenderer.color = Color.yellow;
                break;
            case DisplayedColor.Green:
                Srenderer.color = Color.green;
                break;
            case DisplayedColor.Orange:
                Srenderer.color = new Color(0.93f,0.32f,0.09f,0.99f);
                break;
        }
    }
}

