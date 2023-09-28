using System;
using System.Security.Cryptography.X509Certificates;
using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        //Happy flow
        //Move to player --> lock --> attack --> cooldown --> move --> repeat
        public enum EnemyState
        {
            Idle,
            Hunt,
        } 
        
        [SerializeField] private Transform player;
        [SerializeField] private float movementSpeed;
        [SerializeField] private int pictureAmountBeforeHunt;
        private Rigidbody _enemyRb;
        private EnemyState _enemyState;
        private Pickup _pickupScript;
        
        private void Start()
        {
            _enemyRb = GetComponent<Rigidbody>();
            _pickupScript = player.GetComponent<Pickup>();
            SwitchState(EnemyState.Idle);
        }

        private void SwitchState(EnemyState enemyState)
        {
            _enemyState = enemyState;
            switch (enemyState)
            {
                case EnemyState.Idle:
                    OnIdleEnter();
                    break;
                case EnemyState.Hunt:
                    OnHuntEnter();
                    break;
            }
        }

        private void OnIdleEnter() { OnIdleUpdate(); }
        
        private void OnIdleUpdate()
        {
            print(_pickupScript.amountOfPictures.ToString());
            if (_pickupScript.amountOfPictures >= pictureAmountBeforeHunt)
            {
                print("Test");
                OnIdleExit();
            }
        }
        
        private void OnIdleExit() { SwitchState(EnemyState.Hunt); }
        
        private void OnHuntEnter() { OnHuntUpdate(); }

        private void OnHuntUpdate()
        {
            
        }
        
        //No way to exit hunting state for now
        private void OnHuntExit() { SwitchState(EnemyState.Idle); }

        
        private void Update()
        {
            OnIdleUpdate();
        }


        private void FixedUpdate()
        {
            var positionDifference = new Vector3(player.position.x, 0.0f, player.position.z) - 
                                     new Vector3(transform.position.x, 0.0f, transform.position.z);
            var angle = Quaternion.LookRotation(positionDifference * Time.deltaTime);
            
            //Rotate to player
            _enemyRb.MoveRotation(angle);
            
            if (_enemyState == EnemyState.Hunt)
            {
                MoveToPlayer(positionDifference);
            }
        }

        private void MoveToPlayer(Vector3 positionDifference)
        {
            _enemyRb.MovePosition(transform.position +
                positionDifference.normalized * (Time.deltaTime * movementSpeed));
        }

        public EnemyState GetEnemyState => _enemyState;
    }
}
