using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Window_QuestPointer : MonoBehaviour
{

    [SerializeField] private Camera uiCamera;
    [SerializeField] private Sprite arrowSprite;

    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;

    private void Awake()
    {
        targetPosition = GameObject.FindWithTag("Target").transform.position;
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
    }
    private void Update()
    {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        float borderSize = 40f;

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffscreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;
        Debug.Log(isOffscreen + " " + targetPositionScreenPoint);

        if (isOffscreen)
        {
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            cappedTargetScreenPosition.x = Mathf.Clamp(cappedTargetScreenPosition.x, borderSize, Screen.width - borderSize);
            cappedTargetScreenPosition.y = Mathf.Clamp(cappedTargetScreenPosition.y, borderSize, Screen.height - borderSize);

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);

        }
        else
        {
            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPositionScreenPoint);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);

        }

    }
    public QuestPointer CreatePointer(Vector3 targetPosition) {
        GameObject pointerGameObject = Instantiate(transform.Find("Pointer").gameObject);
        pointerGameObject.transform.SetParent(transform, false);       
        QuestPointer questPointer = new QuestPointer (targetPosition, pointerGameObject, arrowSprite);
        return questPointer;
    }

    public void DestroyPointer(QuestPointer questPointer)
    {
        questPointer.DestroySelf();
    }


    public class QuestPointer {

        private Vector3 targetPosition;
        private GameObject pointerGameObject;
        private Sprite ArrowSprite;

        public QuestPointer(Vector3 targetPosition, GameObject pointerGameObject, Sprite arrowSprite) {
            this.targetPosition = targetPosition;
            this.pointerGameObject = pointerGameObject;
            this.ArrowSprite = arrowSprite;
        }

        public void DestroySelf() {
            Destroy(pointerGameObject);
        }
    }
}