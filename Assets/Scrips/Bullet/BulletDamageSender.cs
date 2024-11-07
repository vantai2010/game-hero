using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [Header("Bullet Damage Sender")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
        this.LoadValueBullet();
    }
    protected virtual void LoadValueBullet()
    {
        string resPath = "Bullet/" + transform.parent.name;
        BulletSO bulletSO = Resources.Load<BulletSO>(resPath);
        this.damage = bulletSO.damage;
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    /*protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        this.Send(other.transform);
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }*/
    protected override void CreateEffect()
    {
        Transform newImpactFX = FXSpawner.Instance.Spawn(FXSpawner.ImpactFX, transform.parent.position, transform.parent.rotation);
        newImpactFX.gameObject.SetActive(true);

        Transform newFloatingDamageText = FXSpawner.Instance.Spawn(FXSpawner.FloatingDamageText, transform.parent.position, Quaternion.identity);
        FloatingTextCtrl floatingTextCtrl = newFloatingDamageText.GetComponent<FloatingTextCtrl>();
        if (floatingTextCtrl == null) return;
        floatingTextCtrl.Text.text = this.damage.ToString();
        newFloatingDamageText.gameObject.SetActive(true);
    }
}
