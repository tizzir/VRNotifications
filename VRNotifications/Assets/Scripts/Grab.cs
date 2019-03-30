/*--------------------------------------------
 * 
   Kevin Hoang
   7778036
   Final Project
   
   Controller Grab Object: This script provides the functionallity of 
   a HTC Vive controller grabbing objects.
   The code is based off the link below, with minor adjustments:
   https://www.raywenderlich.com/149239/htc-vive-tutorial-unity
*/

using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    public class Grab : MonoBehaviour
    {
        public SteamVR_Input_Sources handType;
        public SteamVR_Behaviour_Pose controllerPose;
        public SteamVR_Action_Boolean grabAction;
        
        private GameObject collidingObject;
        private GameObject objectInHand;

        // Set up as potential grab target
        public void OnTriggerEnter(Collider other)
        {
            SetCollidingObject(other);
        }

        // Set up as potential grab target
        public void OnTriggerStay(Collider other)
        {
            SetCollidingObject(other);
        }

        // Controller out of object - Remove reference
        public void OnTriggerExit(Collider other)
        {
            if (!collidingObject)
            {
                return;
            }

            collidingObject = null;
        }

        private void SetCollidingObject(Collider col)
        {
            // If already holding something, cannot hold something else
            if (collidingObject || !col.GetComponent<Rigidbody>())
            {
                return;
            }

            // Assign object as potential grab target
            collidingObject = col.gameObject;
        }

        void Update()
        {
            if (grabAction.GetLastStateDown(handType))
            {
                if (collidingObject)
                {
                    GrabObject();
                }
            }

            if (grabAction.GetLastStateUp(handType))
            {
                if (objectInHand)
                {
                    ReleaseObject();
                }
            }
        }

        // Grabbing an object
        private void GrabObject()
        {
            // Put object into hand
            objectInHand = collidingObject;
            collidingObject = null;

            // Add joint to it so it won't disconnect from hand
            var joint = AddFixedJoint();
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        }

        // Add fixed joint so it doesn't break easily, return object
        private FixedJoint AddFixedJoint()
        {
            FixedJoint fx = gameObject.AddComponent<FixedJoint>();
            fx.breakForce = 20000;
            fx.breakTorque = 20000;
            return fx;
        }

        // Release object
        private void ReleaseObject()
        {
            // Make sure fixed joint is attached
            if (GetComponent<FixedJoint>())
            {
                // Remove connection / joint
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());

                Debug.Log("Velocity: " + controllerPose.GetVelocity());
                Debug.Log("AngularVelocity: "+ controllerPose.GetAngularVelocity());
                if ((controllerPose.GetVelocity().x < -0.4 || controllerPose.GetVelocity().x > 0.4 || controllerPose.GetVelocity().y < -0.4 || controllerPose.GetVelocity().y > 0.4 || controllerPose.GetVelocity().z < -0.4 || controllerPose.GetVelocity().z > 0.4) && (controllerPose.GetAngularVelocity().x < -0.4 || controllerPose.GetAngularVelocity().x > 0.4 || controllerPose.GetAngularVelocity().y < -0.4 || controllerPose.GetAngularVelocity().y > 0.4 || controllerPose.GetAngularVelocity().z < -0.4 || controllerPose.GetAngularVelocity().z > 0.4) && objectInHand.tag == "notificationDetailed")
                {
                    objectInHand.GetComponent<Rigidbody>().mass = 1;
                    objectInHand.GetComponent<Rigidbody>().drag= 0;
                    objectInHand.GetComponent<Rigidbody>().angularDrag = 0.05f;
                    Destroy(objectInHand, 2.0f);
                } 

                // Add velocity and angle when releasing
                objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
                objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
            }

            objectInHand = null;
        }
    }
}
