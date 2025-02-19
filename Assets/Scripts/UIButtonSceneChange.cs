using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonSceneChange : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar, asignar en el Inspector

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("El nombre de la escena a cargar no está asignado en el Inspector");
        }
    }
}
