# ByteVault-Library
My complete Library for unity. It is ever expanding.. (I usually strip it down for the games purpose to keep clutter away.)

## Bellow is an example of implementing one of the benefits
``` C# example
using Bytevaultstudio.Utils; // Include the library

public static Manager instance = null; // Reference the object

void Awake() => nUtils.CreateSingleton<Manager>(ref instance, this, this.gameObject); // Create a singleton.
```

### Preview of the method used above + description of what it does.
``` C# method
public static void CreateSingleton<T>(ref T instance, T _this, GameObject obj)
{
    if (instance == null) instance = _this; // If there is no instance, set it to current instance.
    if (!EqualityComparer<T>.Default.Equals(instance, _this)) MonoBehaviour.Destroy(obj); // If this instance is a new instance, destroy object.

    MonoBehaviour.DontDestroyOnLoad(obj); // If this instance was not destroyed it should persist.
}
```

## This includes a lot more stuff. I will add to this readme doc at a later time
