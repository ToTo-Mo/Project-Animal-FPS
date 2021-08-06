using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunSystem : MonoBehaviour
{
    // Gun Data
    public GunData gunData;

    public bool allowButtonHold;

    bool shooting, readyToShoot, reloading;

    int ammoShot;

    public Camera camera;
    public Transform muzzlePosition;

    public bool allowInvoke = true;

    private void Awake() {
        gunData.numberOfAmmoInMagazine = gunData.magazineSize;
        readyToShoot = true;
    }

    private void Update() {
        TryFire();
        TryReload();
    }

    private void TryReload()
    {
        // 재장전 확인
        if(Input.GetButtonDown("Reload") &&
            gunData.numberOfAmmoInMagazine < gunData.magazineSize &&
            !reloading){
            Reload();        
        }

        // 총알을 모두 사용했으면 자동 재장전
        if(readyToShoot &&
            shooting&&
            !reloading &&
            gunData.numberOfAmmoInMagazine <= 0){
            
            Reload();
        }
    }

    private void TryFire() 
    {
        if(allowButtonHold) shooting = Input.GetButton("Fire");
        else shooting = Input.GetButtonDown("Fire");

        if(readyToShoot && 
            shooting &&
            !reloading &&
            gunData.numberOfAmmoInMagazine > 0){

                ammoShot = 0;

                Shoot();
        }
    }

    private void Shoot(){
        readyToShoot = false;

        // 1. Raycast로 hit 지점 찾기
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPosition;

        // 2. Ray가 맞은 지점을 대상으로 지정
        if(Physics.Raycast(ray, out hit))
            targetPosition = hit.point;
        else
            targetPosition = ray.GetPoint(75);

        // 3. 방향 벡터 구하기   A - B
        Vector3 targetDirection = targetPosition - muzzlePosition.position;


        // 4. 반동 계산
        float horizontalRecoil = Random.Range(-gunData.recoil.x, gunData.recoil.x);
        float verticalRecoil = Random.Range(-gunData.recoil.y, gunData.recoil.y);
        targetDirection += new Vector3(horizontalRecoil, verticalRecoil, 0);

        // 3-1. 거리에 따라 총알의 속력이 일정하도록  정규화 벡터로 변경
        targetDirection = targetDirection.normalized;

        // 5. 총알 생성
        GameObject ammo = Instantiate(gunData.ammo, muzzlePosition.position, Quaternion.identity);
        ammo.transform.forward = targetDirection;

        // 6. 총알 발사
        ammo.GetComponent<Rigidbody>().AddForce(targetDirection * gunData.muzzleVelocity, ForceMode.Impulse);
        // ammo.GetComponent<Rigidbody>().Addforce(camera.transform.up * )

        gunData.numberOfAmmoInMagazine--;
        ammoShot++;

        // 7. 총의 연사 속도
        float timeRatePerShooting = 60 / gunData.rateOfFire ;
        if(allowInvoke){
            Invoke("ResetShoot", timeRatePerShooting);
            allowInvoke = false;
        }

        // 8. 한번에 발사하는 총알의 수가 여러개 라면 Shoot 함수를 반복
        if(ammoShot < gunData.ammoPerFire && gunData.numberOfAmmoInMagazine > 0){
            Invoke("Shoot", gunData.timeBetweenFire);
        }
    }

    private void ResetShoot(){
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload(){
        reloading = true;
        Invoke("ReloadFinished", gunData.reloadTime);
    }

    private void ReloadFinished(){
        gunData.numberOfAmmo += gunData.numberOfAmmoInMagazine;
        gunData.numberOfAmmo -= gunData.magazineSize;
        gunData.numberOfAmmoInMagazine = gunData.magazineSize;
        reloading = false;
    }
}