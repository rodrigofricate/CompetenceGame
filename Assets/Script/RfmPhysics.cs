using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    public static class RfmPhysics
    {
        /// <summary> Check if you are facingof one gameObject (Verifica se esta encarando um gameObject) </summary>
        public static bool IsFacinObject(Transform currentObject, Transform target)
        {
            float angle = 10.0f;
            if (Vector3.Angle(currentObject.forward, target.position - currentObject.position) < angle)
            {
                return true;
            }
            return false;
        }

        /// <summary> Check if you are facingof one gameObject ignoring height diference (Verifica se esta encarando um gameObject, ignorando a diferença de altura) </summary>
        public static bool IsFacinObjectIgnoringHeight(Transform currentObject, Transform target)
        {
            float angle = 10.0f;
            Vector3 fixedCurrentObjectYPos = currentObject.position;
            fixedCurrentObjectYPos.y = 0;
            Vector3 fixedTargetYPos = target.position;
            fixedTargetYPos.y = 0;
            if (Vector3.Angle(currentObject.forward, fixedTargetYPos - fixedCurrentObjectYPos) < angle)
            {
                return true;
            }
            return false;
        }

        /// <summary> Get a Vector3 with the direction of your target (Obtem um Vector3 com a direção do seu alvo) </summary>
        public static Vector3 GetTargetDirection(Transform currentObject, Transform target)
        {
            Vector3 direction = target.transform.position - currentObject.transform.position;
            return direction;
        }

        /// <summary> Rotate at you are look direct to one target by using Lerp (Rotaciona até estar olhando para seu alvo, usando o Lerp) </summary>
        public static void LookToTargetLerp(Transform currentObject, Transform target, float speed)
        {
            Vector3 direction = GetTargetDirection(currentObject, target);
            Quaternion diseredRot =  Quaternion.LookRotation(direction);
            currentObject.transform.rotation = Quaternion.Lerp(currentObject.rotation, diseredRot, speed);
        }

        /// <summary> Rotate in Y axis at you are look direct to one target by using Lerp (Rotaciona no eixo Y até estar olhando para seu alvo, usando o Lerp) </summary>
        public static void RotateToTarget(Transform currentObject, Transform target, float speed)
        {
            Vector3 direction = GetTargetDirection(currentObject, target);
            Quaternion diseredRot = Quaternion.LookRotation(direction);         
            diseredRot.x = 0;
            diseredRot.z = 0;
            Quaternion fixedCurrentRotation = currentObject.transform.rotation;
            currentObject.transform.rotation = Quaternion.Lerp(fixedCurrentRotation, diseredRot, speed);
        }



    }
}
