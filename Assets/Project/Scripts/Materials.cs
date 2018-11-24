using UnityEngine;

public enum Material { Earth, Grass, Sticky };

public static class Materials
{
    public static Color getColorByMaterial(Material material)
    {
        switch (material)
        {
            case Material.Earth:
                return new Color(.55f, .3f, .1f);
            case Material.Grass:
                return new Color(0, .5f, 0);
            case Material.Sticky:
                return new Color(.8f, .8f, 0);
            default:
                return Color.black;
        }
    }
}
