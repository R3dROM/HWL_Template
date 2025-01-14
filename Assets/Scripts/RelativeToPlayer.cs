using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class RelativeToPlayer : MonoBehaviour
    {
        [SerializeField]
        public float m_FollowDistance;

        [SerializeField]
        public float m_HeightPosition;

        [SerializeField]
        public float m_followSpeed;

        [SerializeField]
        public Transform m_TargetTransform;

        [SerializeField]
        public bool m_FollowEnabled = false;
        public float minDistancePosition
        {
            get => m_FollowDistance;
            set => m_FollowDistance = value;
        }
        public float heightPosition
        {
            get => m_HeightPosition;
            set => m_HeightPosition = value;
        }
        public float followSpeed
        {
            get => m_followSpeed;
            set => m_followSpeed = value;
        }
        public Transform targetTransform
        {
            get => m_TargetTransform;
            set => m_TargetTransform = value;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        protected virtual void LateUpdate()
        {
            if (m_TargetTransform == null) return;

            // Solo actualiza posición si está habilitada y la distancia es significativa
            if (m_FollowEnabled && NeedsPositionUpdate())
                UpdatePosition();
        }

        /// <summary>
        /// Verifica si la posición necesita actualizarse.
        /// </summary>
        private bool NeedsPositionUpdate()
        {
            Vector3 targetPos = m_TargetTransform.position + m_TargetTransform.forward * m_FollowDistance;
            targetPos.y = m_TargetTransform.position.y + m_HeightPosition;

            return Vector3.Distance(transform.position, targetPos) > Mathf.Epsilon;
        }
        private void UpdatePosition()
        {
            Vector3 targetPosition = m_TargetTransform.position + m_TargetTransform.forward * m_FollowDistance;
            
            targetPosition.y += m_HeightPosition;
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * m_followSpeed);
        }
    }
}
