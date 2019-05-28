using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public AbstractFactory Factory;

    private static ObjectSpawner instance;

    private void Awake()
    {
        aa = new GameObject("AA");
        aa.transform.parent = transform;
        aa.transform.localPosition = new Vector3(-5, 0, -5);
        
        bb = new GameObject("BB");
        bb.transform.parent = transform;
        bb.transform.localPosition = new Vector3(5, 0, 5);

        instance = this;

        ObjectPrefabs = Factory.GetProducts().ToArray();
    }

    public static ObjectSpawner GetInstance()
    {
        return instance;
    }

    public Product[] ObjectPrefabs;

    public void SpawnRandom()
    {
        int index = Random.Range(0, ObjectPrefabs.Length);
        Product goToSpawn = ObjectPrefabs[index];

        Vector3 aaPos = aa.transform.position;
        Vector3 bbPos = bb.transform.position;
        Vector3 pos = new Vector3(Random.Range(aaPos.x, bbPos.x), Random.Range(aaPos.y, bbPos.y), Random.Range(aaPos.z, bbPos.z));
        Instantiate(goToSpawn, pos, Quaternion.identity);
    }

    private GameObject aa;
    private GameObject bb;
    private Line[] lines = new Line[12];

    internal struct Line
    {
        public Vector3 A;
        public Vector3 B;
    }

    private void OnDrawGizmos()
    {
        if (aa == null || bb == null)
        {
            return;
        }
        Vector3 aaPos = aa.transform.position;
        Vector3 bbPos = bb.transform.position;

        lines[0].A = aaPos;
        lines[0].B = aaPos;
        lines[0].B.x = bbPos.x;

        lines[1].A = aaPos;
        lines[1].B = aaPos;
        lines[1].B.y = bbPos.y;

        lines[2].A = aaPos;
        lines[2].B = aaPos;
        lines[2].B.z = bbPos.z;

        lines[3].A = lines[0].B;
        lines[3].B = lines[3].A;
        lines[3].B.y = bbPos.y;

        lines[4].A = lines[0].B;
        lines[4].B = lines[4].A;
        lines[4].B.z = bbPos.z;

        lines[5].A = lines[1].B;
        lines[5].B = lines[5].A;
        lines[5].B.x = bbPos.x;

        lines[6].A = lines[1].B;
        lines[6].B = lines[6].A;
        lines[6].B.z = bbPos.z;

        lines[7].A = lines[2].B;
        lines[7].B = lines[7].A;
        lines[7].B.x = bbPos.x;

        lines[8].A = lines[2].B;
        lines[8].B = lines[8].A;
        lines[8].B.y = bbPos.y;

        lines[9].A = bbPos;
        lines[9].B = bbPos;
        lines[9].B.x = aaPos.x;

        lines[10].A = bbPos;
        lines[10].B = bbPos;
        lines[10].B.y = aaPos.y;

        lines[11].A = bbPos;
        lines[11].B = bbPos;
        lines[11].B.z = aaPos.z;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aaPos, 0.1f);
        Gizmos.DrawSphere(bbPos, 0.1f);
        Gizmos.color = Color.magenta;

        foreach (Line line in lines)
        {
            Gizmos.DrawLine(line.A, line.B);
        }
    }
}