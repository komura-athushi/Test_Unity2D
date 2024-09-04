using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using UnityEngine;

namespace PlayerController{
    abstract public class IController
    {
        protected Player player;
        protected PlayerInput input;
        public  virtual void Enter(Player player, PlayerInput input) { this.player = player; this.input = input; }
        public abstract void Execute();
        public virtual IController ChangeState()
        {   

            Vector2 inputVector = input.InputVector;
            if( Mathf.Abs(inputVector.x) > 0.1f ) { return new MoveController(); }

            return new IdleController();
        }

        public abstract void Exit();
    }

    public class IdleController: IController
    {
        public override IController ChangeState() 
        {


            return base.ChangeState();
        }
        public override void Execute()
        {

        }

        public override void Exit()
        {

        }
    }

        public class MoveController: IController
    {
        float moveSpeed;
        float gravity;
        public override void Enter(Player player, PlayerInput input) 
        {   
            this.player = player; 
            this.input = input; 
            moveSpeed = player.GetMoveSpeed();
            gravity = player.GetGravity();
        }
        public override IController ChangeState() 
        {
            return base.ChangeState();
        }
        public override void Execute()
        {
            Move();
        }
        void Move()
        {
            Vector2 inputVector = input.InputVector;
            inputVector.x *= moveSpeed;
            Vector2 velocity = player.GetVelocity();
            velocity.x = inputVector.x;
            velocity.y -= gravity;
            if(player.IsGrounded())
            {
                velocity.y = 0.0f;
            }
            player.MovePlayer(velocity);
        }
        public override void Exit()
        {

        }
    }
}
