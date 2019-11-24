using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public bool photon;
        private PhotonView myPhotonView;
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            photon = false;
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void Start()
        {
            myPhotonView = GetComponent<PhotonView>();
        }


        private void FixedUpdate()
        {
            if (photon)
            {
                if (myPhotonView.IsMine)
                {
                    // pass the input to the car!
                    float h = CrossPlatformInputManager.GetAxis("Horizontal");
                    float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
                    float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                    m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
                }
            }
            else
            {

                // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
            }
        }
    
  
    }
}
