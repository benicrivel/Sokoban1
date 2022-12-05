using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SoundEffect Slide, Stop;
    AudioSource audio;
    PathCheck checkPath;

    bool isWalking, SavePositionOnEnd;
    Vector3 Destination;

    // Start is called before the first frame update
    void Start(){
        audio = GetComponent<AudioSource>();
        checkPath = GetComponent<PathCheck>();
        Destination = transform.position;
        UndoSystem.SavePosition(gameObject, transform.position, transform.eulerAngles.y, true);
    }

    // Update is called once per frame
    void Update()
    {         
        int moveStepsLength = PlayerMovement.moveSteps.Length;

        if (moveStepsLength > 0 && isWalking == false)
        {
            PlayerMovement.MoveStep moveStep = PlayerMovement.GetMove();
            if(checkPath.CheckPathIsPossible(moveStep.Direction) == true)
            {
                MoveAndSave(transform.position + moveStep.Direction);
                audio.clip = Slide.GetAudioClip();
                audio.volume = SaveSystem.LoadValue.SoundEffectsVolume();
                audio.Play();
            }
            else{
                audio.clip = Stop.GetAudioClip();
                audio.volume = SaveSystem.LoadValue.SoundEffectsVolume();
                audio.Play();
            }
            PlayerMovement.DeleteMoveStep();
        }

        if (isWalking == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Destination, 5.0f * Time.deltaTime);
            if (transform.position == Destination)
            {
                isWalking = false;
            }
        }
    }

    public void MoveAndSave(Vector3 destination){
        UndoSystem.SavePosition(gameObject, transform.position, transform.eulerAngles.y, true);
        Destination = destination;
        SavePositionOnEnd = true;
        isWalking = true;
    }

    public void UndoMove(Vector3 destination){
        Destination = destination;
        SavePositionOnEnd = false;
        isWalking = true;
    }
}
