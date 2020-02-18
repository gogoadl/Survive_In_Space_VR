using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    public class GrabObject : MonoBehaviour
    {
        [EnumFlags]
        [Tooltip("The flags used to attach this object to the hand.")]
        public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

        [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
        public Transform attachmentOffset;

        [Tooltip("When detaching the object, should it return to its original parent?")]
        public bool restoreOriginalParent = false;

        public HandEvent onHeldUpdate;
        
        protected virtual void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();

            if (startingGrabType != GrabTypes.None)
            {
                hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
                ShowController();
            }
        }

        protected virtual void HandAttachedUpdate(Hand hand)
        {
            if (hand.IsGrabEnding(this.gameObject))
            {
                hand.DetachObject(gameObject, restoreOriginalParent);
                ShowController();
            }
        }

        public void ShowController()
        {
            for (int handIndex = 0; handIndex < Player.instance.hands.Length; handIndex++)
            {
                Hand hand = Player.instance.hands[handIndex];
                if (hand != null)
                {
                    hand.ShowController(true);
                }
            }
        }
    }
}