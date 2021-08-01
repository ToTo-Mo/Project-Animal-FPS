using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct KeyboardInputComponent : IComponentData
{   
    [HideInInspector]
    public float mouseX;
    [HideInInspector]
    public float mouseY;
    public float mouseSensitivity;

    [HideInInspector]
    public float horizontal;// 수평 이동
    [HideInInspector]
    public float vertical;	// 수직 이동

    [HideInInspector]
    public bool jump;   	// 점프

    [HideInInspector]
    public bool sprint; 	// 달리기

    [HideInInspector]
    public bool reload; 	// 재장전

    [HideInInspector]
    public bool prone;  	//앉기

	// ---- 계획중 ----
    [HideInInspector]
	public bool interact;	// 상호작용
    [HideInInspector]
    public bool melee;		// 근접 공격

    [HideInInspector]
	public bool primaryAttack;	// 주 공격, 좌클릭

    [HideInInspector]
	public bool secondaryAttack;	// 보조 공격 & 보조 행동, 우클릭

    [HideInInspector]
	public bool inventory;	// 인벤토리

    [HideInInspector]
	public bool map;		// 지도

    [HideInInspector]
	public bool itemSwitching;	// 아이템  스위칭

}
