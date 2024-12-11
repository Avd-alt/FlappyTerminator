using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.Shooting += Shoot;
    }

    private void OnDisable()
    {
        _playerInput.Shooting -= Shoot;
    }

    private void Shoot()
    {
        PlayerBullet bullet = _bulletPool.GetObjects() as PlayerBullet;
        bullet.Killed += ReleaseBullet;
        bullet.transform.position = transform.position;
        bullet.ChangeDirection(transform.right);
    }

    private void ReleaseBullet(PlayerBullet bullet)
    {
        bullet.Killed -= ReleaseBullet;
        _bulletPool.ReleaseObjects(bullet);
    }
}