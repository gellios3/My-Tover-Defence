using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace Views
{
    public class CameraControllerView : EventView
    {
        [SerializeField] private float _panSpeed = 30f;
        [SerializeField] private float _panBorderThickness = 10f;
        [SerializeField] private float _scrollSpeed = 5f;
        [SerializeField] private float _minY = 10f;
        [SerializeField] private float _maxY = 60f;


        /// <summary>
        /// Player starts service
        /// </summary>
        [Inject]
        public PlayerStartsService PlayerStartsService { get; set; }


        private void Update()
        {
            if (PlayerStartsService.HasPaused)
                return;

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var scroll = Input.GetAxis("Mouse ScrollWheel");

            // move camera forward
            if (vertical < 0)
            {
                transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
            }

            // move camera back
            if (vertical > 0)
            {
                transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
            }

            // move camera right
            if (horizontal < 0)
            {
                transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
            }

            // move camera left
            if (horizontal > 0)
            {
                transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
            }

            // zoom in or out
            var pos = transform.position;
            pos.y -= scroll * 1000 * _scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
            transform.position = pos;
        }
    }
}