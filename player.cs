using System;
using UnityEngine;
using System.Collections;

using VRStandardAssets.Common;
using VRStandardAssets.Utils;

public class player : MonoBehaviour
{

    enum GameState { LevelStarting, Mammary, HandTouch, VoiceHand, Stats, Shoulder, Massage, Body, Patting, Physical,Personal, Whisper, End }
    public Animator anim;
    private GameState state;
    public AudioSource Audio_Source;
    //public Animation talking;

    //private VRInteractiveItem myInteractiveItem;

    //hello
    public AudioClip Voice_03;
    public AudioClip Droid_01;
    public AudioClip Voice_15;
    public AudioClip Voice_16;


    //breaking the barrier droid
    public AudioClip Droid_06;
    public AudioClip Droid_07;
    public AudioClip Droid_08;
    public AudioClip Droid_09;
    public AudioClip Droid_10;
    public AudioClip Droid_11;

    //breaking the barrier voice
    public AudioClip Voice_17;
    public AudioClip Voice_18;
    public AudioClip Voice_19;
    public AudioClip Voice_20;
    public AudioClip Voice_21;



    //public event Action OnClick;
/*
    public void Click()
    {

        if (OnClick != null)
            OnClick();
    }*/

    // Use this for initialization
    void Start()
    {
       // myInteractiveItem = GetComponent<VRInteractiveItem>();
        anim = GetComponent<Animator>();
        // MattAudioSource = GameObject.Find("Player2/Matt Audio").GetComponent<AudioSource>();
        Audio_Source = GetComponent<AudioSource>();
       // talking = GetComponent<Animation>();
        LoadGame();
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")) //change to a click to start scene? Or just call it in start?
        {
        NextStep();
        }
        // PointerClick();


        if (Input.GetButtonDown("OnClick")) {
            NextStep();
        }
            
    }

    void NextStep() //this is called from a space bar input, change to...click?
    {

        switch (state)
        {

            case GameState.LevelStarting:
                Starting();  
                break;

            case GameState.Mammary:
                Mammary();
                break;

            case GameState.HandTouch:
                Hand();
                break;

            case GameState.VoiceHand:
                VoiceHand();
                break;

            case GameState.Stats:
                Stats();
                break;

            case GameState.Shoulder:
                Shoulder();
                break;

            case GameState.Massage:
                Massage();
                break;

            case GameState.Body:
                Body();
                break;

            case GameState.Patting:
                Patting();
                break;

            case GameState.Physical:
                Physical();
                break;

            case GameState.Personal:
                Personal();
                break;

            case GameState.Whisper:
                Whisper();
                break;

            case GameState.End:
                End();
                break;

        }
    }


    void LoadGame()
    {

        Debug.Log("GameScript:LoadLevel");
        state = GameState.LevelStarting;
    }

    void Starting()//LevelStarting
    {
        Debug.Log("Starting Narrative");

        //play audio once
        
        Audio_Source.PlayOneShot(Droid_01, 1.0f);
        anim.Play("talking (1)", -1, 0f);

        //switch to next state
        state = GameState.Mammary;
    }

    void Mammary()//LevelStarting
    {
        Debug.Log("Mammary");

        Audio_Source.PlayOneShot(Voice_15, 1.0f);

        //switch to next state
        state = GameState.HandTouch;
    }
    void Hand()//Hand
    {
        Debug.Log("Hand");

        //get touch data
        /*
            if (touched()) //make this a function
            {
                //instantiate particle system
                anim.Play("happy", -1, 0f);
            }*/

        Audio_Source.PlayOneShot(Droid_06, 1.0f);
        anim.Play("talking", -1, 0f); //how do I get these to be simultaneous?
        
       
        state = GameState.VoiceHand;
    }

    void VoiceHand()
    {
        Debug.Log("VoiceHand");

        Audio_Source.PlayOneShot(Voice_17, 1.0f);

        state = GameState.Stats;
    }

    void Stats()
    {
        Debug.Log("Stats");

        //get touch data 

        /*
            if (touched()) //make this a function
            {
                //instantiate particle system
                anim.Play("happy", -1, 0f);
            }*/

        Audio_Source.PlayOneShot(Droid_07, 1.0f);
        anim.Play("talking", -1, 0f);
        state = GameState.Shoulder;
    }

    void Shoulder()//Shoulder
    {
        Debug.Log("Shoulder");

        Audio_Source.PlayOneShot(Voice_18, 1.0f);

        state = GameState.Massage;
    }

    void Massage()
    {
        Debug.Log("Massage");

        Audio_Source.PlayOneShot(Droid_08, 1.0f);
        anim.Play("talking", -1, 0f);

        state = GameState.Body;
    }

    void Body() //body
    {
        Debug.Log("Body");

        Audio_Source.PlayOneShot(Voice_19, 1.0f);

        state = GameState.Patting;
    }

    void Patting() //patting
    {
        Debug.Log("Patting");

        anim.Play("patting", -1, 0f);
        Audio_Source.PlayOneShot(Droid_09, 1.0f);
        //anim.Play("talking", -1, 0f);
       // state = GameState.Whisper;
        state = GameState.Physical ;
    }

  
    void Physical() 
    {
        Debug.Log("Physical");

        Audio_Source.PlayOneShot(Voice_20, 1.0f);

        state = GameState.Personal;
    }

    void Personal()
    {
        Debug.Log("Personal");

        
            //talking.wrapMode = WrapMode.Loop;
        anim.Play("talking", -1, 0f);
        Audio_Source.PlayOneShot(Droid_10, 1.0f);

        state = GameState.Whisper;
    }

    void Whisper() //whisper
    {
        Debug.Log("whisper");

        anim.Play("telling_a_secret", -1, 0f);
        Audio_Source.PlayOneShot(Droid_11, 1.0f);
       
        state = GameState.End;
    }

    void End()
    {
        Debug.Log("end");

        Audio_Source.PlayOneShot(Voice_21, 1.0f);
    }
/*
    private void OnEnable()
    {
        myInteractiveItem.OnClick += PointerClick;
    }

    private void PointerClick()
    {
        NextStep();
    }*/
}