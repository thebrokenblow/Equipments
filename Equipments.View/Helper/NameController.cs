namespace Equipments.View.Helper;

public class NameController
{
    public static string GetControllerName(string nameController)
    {
        return nameController.Replace("Controller", string.Empty);
    }
}