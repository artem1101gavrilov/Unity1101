using System.Reflection;
using UnityEngine;

public class ExampleReflection : MonoBehaviour {

    public bool example1;
    private bool example2;
    public bool Example3 { get; private set; }

    private void Start () {
        example1 = true;
        example2 = false;
        Example3 = false;
        var e1 = GetType().GetField("example1");
        var e2 = GetType().GetField("example2");
        var e3 = GetType().GetProperty("Example3");
        var e4 = GetType().GetField("Example4");
        Debug.Log(e1 == null ? "Переменной example1 в классе нет" : "example1 = " + e1.GetValue(this).ToString());
        Debug.Log(e2 == null ? "Переменной example2 в классе нет" : "example2 = " + e2.GetValue(this).ToString());
        Debug.Log(e3 == null ? "Example3 в классе нет" : "Example3 = " + e3.GetValue(this, null).ToString());
        Debug.Log(e4 == null ? "Переменной example3 в классе нет" : "example3 = " + e4.GetValue(this).ToString());
        e3.SetValue(this, true, null);
        Debug.Log(e3 == null ? "Example3 в классе нет" : "Example3 = " + e3.GetValue(this, null).ToString());
    }
}