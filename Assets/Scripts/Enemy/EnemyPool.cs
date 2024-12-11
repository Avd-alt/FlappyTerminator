public class EnemyPool : Pool<Enemy>
{
    public override void ReleaseObjects(Enemy enemy)
    {
        base.ReleaseObjects(enemy);
        enemy.Release();
    }
}